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
            oldName = Program.Games[gID].Name;
        }

        private void FrmEditGame_Load(object sender, EventArgs e)
        {
            txtGamePath.TextChanged += TxtGamePath_TextChanged;

            Text = "Game Options: [" + gID + "]";

            txtGamePath.Text = Program.Games[gID].File;
            txtGameName.Text = Program.Games[gID].Name;

            chkNoGUI.Checked = Program.Games[gID].NoGUI;
            chkFull.Checked = Program.Games[gID].Fullscreen;

            chkGPad.Checked = Program.Games[gID].UseGlobalPad;
        }

        private void TxtGamePath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGameName.Text = Path.GetFileNameWithoutExtension(Program.GetFullPath(txtGamePath.Text));
            }
            catch
            {

            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Program.Games[gID].File = txtGamePath.Text;
            Program.Games[gID].Name = Program.GetSafeGameName(txtGameName.Text);

            Program.Games[gID].NoGUI= chkNoGUI.Checked;
            Program.Games[gID].Fullscreen = chkFull.Checked;

            Program.Games[gID].UseGlobalPad = chkGPad.Checked;

            try
            {
                //Directory.Move(@"Configs\" + oldName, @"Configs\" + Program.frmMain.games[gID].Name);
            }
            catch
            {

            }

            var selectedId = Program.Games[gID].UniqueID;

            Program.Games = Program.Games.OrderBy(q => q.Name).ToList();

            Program.frmMain.SaveGames();

            Program.frmMain.RepopulateGamesList(Program.Games.FindIndex(g => g.UniqueID == selectedId));

            Close();
        }

        private void btGamePath_Click(object sender, EventArgs e)
        {
            try
            {
                oGamePath.InitialDirectory = Path.GetDirectoryName(Program.GetFullPath(txtGamePath.Text));
                oGamePath.FileName = Path.GetFileName(Program.GetFullPath(txtGamePath.Text));
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
