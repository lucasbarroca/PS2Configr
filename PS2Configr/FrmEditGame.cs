using System;
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
    public partial class FrmEditGame : Form
    {
        public int gID;
        public string oldName;
        public FrmEditGame(int GameID)
        {
            InitializeComponent();

            gID = GameID;
            oldName = Program.frmMain.games[gID].Name;
        }

        private void FrmEditGame_Load(object sender, EventArgs e)
        {
            txtGamePath.TextChanged += TxtGamePath_TextChanged;

            Text = "Game Options: [" + gID + "]";

            txtGamePath.Text = Program.frmMain.games[gID].File;
            txtGameName.Text = Program.frmMain.games[gID].Name;

            chkNoGUI.Checked = Program.frmMain.games[gID].NoGUI;
            chkFull.Checked = Program.frmMain.games[gID].Fullscreen;

            chkGPad.Checked = Program.frmMain.games[gID].UseGlobalPad;
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

        private void btSave_Click(object sender, EventArgs e)
        {
            Program.frmMain.games[gID].File = txtGamePath.Text;
            Program.frmMain.games[gID].Name = Program.GetSafeGameName(txtGameName.Text);

            Program.frmMain.games[gID].NoGUI= chkNoGUI.Checked;
            Program.frmMain.games[gID].Fullscreen = chkFull.Checked;

            Program.frmMain.games[gID].UseGlobalPad = chkGPad.Checked;

            try
            {
                //Directory.Move(@"Configs\" + oldName, @"Configs\" + Program.frmMain.games[gID].Name);
            }
            catch
            {

            }

            Program.frmMain.SaveGames();
            Program.frmMain.RepopulateGamesList();

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
                txtGamePath.Text = Program.GetRelativePath(oGamePath.FileName);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
