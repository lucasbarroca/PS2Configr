using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PS2Configr
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public void RepopulateGamesList(int selectedId = -1)
        {
            // Fill list
            gList.Items.Clear();
            foreach (Game G in Program.Games)
            {
                gList.Items.Add("[" + Program.Games.IndexOf(G) + "] " + G.Name);
            }

            // Scroll to item
            if (selectedId > -1)
            {
                gList.Select();
                gList.Items[selectedId].Selected = true;
                gList.EnsureVisible(selectedId);
            }
        }

        public void SaveGames()
        {
            Program.SaveGamesList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Games list events
            gList.DoubleClick += GList_DoubleClick;
            gList.MouseClick += GList_MouseClick;

            gList.DragEnter += GList_DragEnter;
            gList.DragDrop += GList_DragDrop;
        
            // Populate games list
            RepopulateGamesList();
        }

    #region "Games List"
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
                new FrmAddGame(Program.GetRelativePath(s[i])).ShowDialog();
        }

        private void GList_DoubleClick(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
                Program.Games[gList.SelectedIndices[0]].Launch();
        }
        #endregion

    #region "Form Components"
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmSettings().ShowDialog();
        }

        private void launchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
                Program.Games[gList.SelectedIndices[0]].Launch();
        }

        private void configureInPCSX2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
                Program.Games[gList.SelectedIndices[0]].LaunchConfig();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.LoadGamesList();
            RepopulateGamesList();
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
                var idToRemove = gList.SelectedIndices[0];

                try
                {
                    Directory.Delete(@"Configs\" + Program.Games[idToRemove].UniqueID);
                }
                catch { }

                Program.Games.RemoveAt(idToRemove);
                SaveGames();
                RepopulateGamesList(idToRemove > 0 ? idToRemove - 1 : (Program.Games.Count > 1 ? 0 : -1));
            }
        }

        private void clearUnusedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string d in Directory.GetDirectories("Configs"))
            {
                var dir = d.Replace(@"Configs\", "");

                if (Program.Games.FindIndex(g => g.UniqueID.ToString() == dir) == -1)
                {
                    Directory.Delete(d, true);
                }
            }
        }

        private void addGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAddGame(Properties.Settings.Default.DefaultDiskPath).ShowDialog();
        }

        private void gList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void launchGamebyUniqueIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
            {
                Clipboard.SetText($"-id {Program.Games[gList.SelectedIndices[0]].UniqueID}");
            }
        }

        private void launchGamebyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
            {
                Clipboard.SetText($"-name \"{Program.Games[gList.SelectedIndices[0]].Name}\"");
            }
        }

        private void launchConfigbyUniqueIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
            {
                Clipboard.SetText($"-config {Program.Games[gList.SelectedIndices[0]].UniqueID}");
            }
        }

        private void launchConfigbyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
            {
                Clipboard.SetText($"-configname \"{Program.Games[gList.SelectedIndices[0]].Name}\"");
            }
        }
        #endregion

        private void rMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
