﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PS2Configr
{
    public partial class FrmAddGame : Form
    {
        public string GamePath;
        public FrmAddGame(string Path)
        {
            InitializeComponent();

            GamePath = Path;
        }

        private void FrmAddGame_Load(object sender, EventArgs e)
        {
            txtGamePath.TextChanged += TxtGamePath_TextChanged; ; ;

            txtGamePath.Text = GamePath;
            //txtGameName.Text = Path.GetFileName(GamePath);

            chkNoGUI.Checked = Properties.Settings.Default.DefaultNoGUI;
            chkFull.Checked = Properties.Settings.Default.DefaultFullscreen;

            chkGPad.Checked = Properties.Settings.Default.DefaultUseGlobalPad;
        }

        private void TxtGamePath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGameName.Text = Path.GetFileNameWithoutExtension(Path.GetFullPath(txtGamePath.Text));
            }
            catch
            {

            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAddGame_Click(object sender, EventArgs e)
        {
            Program.frmMain.games.Add(new Game(PS2ConfigrFunctions.GetSafeGameName(txtGameName.Text), txtGamePath.Text, chkNoGUI.Checked, chkFull.Checked, chkGPad.Checked));
            Program.frmMain.games = Program.frmMain.games.OrderBy(q => q.Name).ToList();

            Program.frmMain.SaveGames();
            Program.frmMain.LoadGames();

            Close();
        }

        private void btGamePath_Click(object sender, EventArgs e)
        {
            try
            {
                oGamePath.InitialDirectory = Path.GetDirectoryName(Path.GetFullPath(txtGamePath.Text));
                oGamePath.FileName = Path.GetFileName(Path.GetFullPath(txtGamePath.Text));
            }
            catch { }

            if (oGamePath.ShowDialog() == DialogResult.OK)
                txtGamePath.Text = PS2ConfigrFunctions.GetRelativePath(oGamePath.FileName);
        }

    }
}
