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
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            // PCSX2
            Properties.Settings.Default.PCSX2Path = txtEmuPath.Text;

            // Games
            Properties.Settings.Default.DefaultDiskPath = txtDiskPath.Text;
            Properties.Settings.Default.DefaultNoGUI = chkNoGUI.Checked;
            Properties.Settings.Default.DefaultFullscreen = chkFull.Checked;
            Properties.Settings.Default.DefaultUseGlobalPad = chkGPad.Checked;

            // SAVE
            Properties.Settings.Default.Save();
            Close();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            // PCSX2
            txtEmuPath.Text = Properties.Settings.Default.PCSX2Path;

            // Games
            txtDiskPath.Text = Properties.Settings.Default.DefaultDiskPath;
            chkNoGUI.Checked = Properties.Settings.Default.DefaultNoGUI;
            chkFull.Checked = Properties.Settings.Default.DefaultFullscreen;
            chkGPad.Checked = Properties.Settings.Default.DefaultUseGlobalPad;
        }

        private void btEmuPath_Click(object sender, EventArgs e)
        {
            try
            {
                oEmuPath.InitialDirectory = Path.GetDirectoryName(Path.GetFullPath(txtEmuPath.Text));
                oEmuPath.FileName = Path.GetFileName(Path.GetFullPath(txtEmuPath.Text));
            }
            catch { }

            if (oEmuPath.ShowDialog() == DialogResult.OK)
                txtEmuPath.Text = Program.GetRelativePath(oEmuPath.FileName);
        }

        private void btDiskPath_Click(object sender, EventArgs e)
        {
            try
            {
                fbDiskPath.SelectedPath = txtDiskPath.Text;
            }
            catch { }

            if (fbDiskPath.ShowDialog() == DialogResult.OK)
                txtDiskPath.Text = Program.GetRelativePath(fbDiskPath.SelectedPath);
        }

        private void txtDiskPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
