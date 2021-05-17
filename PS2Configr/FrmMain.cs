﻿using System;
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
        public void RepopulateGamesList()
        {
            // Fill list
            gList.Items.Clear();
            foreach (Game G in games)
                gList.Items.Add("[" + games.IndexOf(G) + "] " + G.Name);
        }

        public void SaveGames()
        {
            Program.SaveConfig();
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
                games[gList.SelectedIndices[0]].Launch();
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
                games[gList.SelectedIndices[0]].Launch();
        }

        private void configureInPCSX2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
                games[gList.SelectedIndices[0]].LaunchConfig();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.LoadConfig();
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
                try
                {
                    Directory.Delete(@"Configs\" + games[gList.SelectedIndices[0]].Name);
                }
                catch { }

                games.RemoveAt(gList.SelectedIndices[0]);
                SaveGames();
                RepopulateGamesList();
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
        #endregion

        private void launchGamebyUniqueIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
            {
                Clipboard.SetText($"-id {games[gList.SelectedIndices[0]].UniqueID}");
            }
        }

        private void launchGamebyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
            {
                Clipboard.SetText($"-name {games[gList.SelectedIndices[0]].Name}");
            }
        }

        private void launchConfigbyUniqueIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
            {
                Clipboard.SetText($"-config {games[gList.SelectedIndices[0]].UniqueID}");
            }
        }

        private void launchConfigbyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gList.SelectedIndices.Count > 0)
            {
                Clipboard.SetText($"-configname {games[gList.SelectedIndices[0]].Name}");
            }
        }
    }
}
