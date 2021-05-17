using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PS2Configr
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public List<Game> games = Program.Games;
        public void LoadGames()
        {
            // Fill list
            gList.Items.Clear();
            foreach (Game G in games)
                gList.Items.Add("[" + games.IndexOf(G) + "] " + G.Name);
        }

        public void SaveGames()
        {
            using (FileStream fs = File.Open("config.xml", FileMode.Create))
                new XmlSerializer(games.GetType()).Serialize(fs, games);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gList.DoubleClick += GList_DoubleClick;
            gList.MouseClick += GList_MouseClick;

            gList.DragEnter += GList_DragEnter;
            gList.DragDrop += GList_DragDrop;

            // Check app needed
            if (!Directory.Exists("Configs"))
                Directory.CreateDirectory("Configs");

            bool settingsOK = false;
            while (!settingsOK) {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.PCSX2Path))
                    settingsOK = File.Exists(Path.GetFullPath(Properties.Settings.Default.PCSX2Path));

                if (!settingsOK)
                {
                    MessageBox.Show("You need to configure settings!", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new FrmSettings().ShowDialog();
                }
            }

            // LoadGames
            LoadGames();

            // Check command line
            List<string> arguments = new List<string>(Environment.GetCommandLineArgs());

            foreach (string arg in arguments)
            {
                if (arg == "-id")
                {
                    int gid;
                    if (int.TryParse(arg, out gid))
                        games[gid].Launch();

                    Environment.Exit(0);
                }
                else if (arg == "-name" || arg == "-config")
                {
                    foreach (Game g in games)
                    {
                        if (g.Name == arg)
                        {
                            if (arg == "-name")
                            {
                                g.Launch();
                            }
                            else
                            {
                                g.LaunchConfig();
                            }
                        }
                    }

                    Environment.Exit(0);
                }

            }          
        }

        private void GList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                if (gList.SelectedIndices.Count > 0)
                    rMenu.Show(Cursor.Position);
        }

        private void GList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void GList_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                new FrmAddGame(PS2ConfigrFunctions.GetRelativePath(s[i])).ShowDialog();
        }

        private void GList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
                games[gList.SelectedIndices[0]].Launch();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmSettings().ShowDialog();
        }

        private void launchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
                games[gList.SelectedIndices[0]].Launch();
        }

        private void configureInPCSX2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
                games[gList.SelectedIndices[0]].LaunchConfig();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGames();
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
                new FrmEditGame(gList.SelectedIndices[0]).ShowDialog();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
            {
                try
                {
                    Directory.Delete(@"Configs\" + games[gList.SelectedIndices[0]].Name);
                }
                catch { }

                games.RemoveAt(gList.SelectedIndices[0]);
                SaveGames();
                LoadGames();
            }
        }

        private void clearUnusedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string d in Directory.GetDirectories("Configs"))
                if (games.Find(g => g.Name == d.Replace(@"Configs\", "")) == null)
                    Directory.Delete(d);
        }

        private void addGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAddGame(Properties.Settings.Default.DefaultDiskPath).ShowDialog();
        }

        private void gList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public static class PS2ConfigrFunctions
    {
        public static string GetSafeGameName(string PathName)
        {
            foreach (char c in Path.GetInvalidPathChars())
                PathName = PathName.Replace(c.ToString(), string.Empty);

            foreach (char c in Path.GetInvalidFileNameChars())
                PathName = PathName.Replace(c.ToString(), string.Empty);

            return PathName;
        }

        public static string GetRelativePath(string filePath)
        {
            var fileUri = new Uri(filePath);
            var referenceUri = new Uri(Environment.CurrentDirectory + @"\");
            return referenceUri.MakeRelativeUri(fileUri).ToString().Replace("%20", " ").Replace("/", @"\");
        }

    }

}
