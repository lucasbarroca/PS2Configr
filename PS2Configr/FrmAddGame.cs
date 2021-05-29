using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PS2Configr
{
    public partial class FrmAddGame : Form
    {
        public string GamePath;

        public FrmAddGame(string path)
        {
            InitializeComponent();

            if (path.EndsWith("/") || path.EndsWith(@"\") || Path.GetExtension(path).Length > 0)
            {
                GamePath = path;
            }
            else
            {
                GamePath = path + @"/";
            }
        }

        private void FrmAddGame_Load(object sender, EventArgs e)
        {
            txtGamePath.TextChanged += TxtGamePath_TextChanged;

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
                txtGameName.Text = Path.GetFileNameWithoutExtension(Program.GetFullPath(txtGamePath.Text));
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
            var newGame = new Game(Program.GetSafeGameName(txtGameName.Text), txtGamePath.Text, chkNoGUI.Checked, chkFull.Checked, chkGPad.Checked);
            Program.GenerateUniqueGameId(Program.Games, newGame);
            Program.Games.Add(newGame);
            Program.Games = Program.Games.OrderBy(q => q.Name).ToList();

            Program.frmMain.SaveGames();
            Program.LoadGamesList();
            Program.frmMain.RepopulateGamesList(Program.Games.FindIndex(g => g.UniqueID == newGame.UniqueID));

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

        private void txtGamePath_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
