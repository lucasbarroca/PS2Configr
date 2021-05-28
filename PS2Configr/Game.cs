using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PS2Configr
{
    // Version: 1.1
    public class Game
    {
        public int UniqueID;
        public string Name;
        public string File;

        public bool NoGUI;
        public bool Fullscreen;

        public bool UseGlobalPad;

        public Game()
        {

        }

        public Game(string Name, string File, bool NoGUI, bool Fullscreen, bool UseGlobalPad)
        {
            this.Name = Name;
            this.File = File;

            this.NoGUI = NoGUI;
            this.Fullscreen = Fullscreen;

            this.UseGlobalPad = UseGlobalPad;
        }

        public string GetConfigDir()
        {
            return Program.GetFullPath("Configs") + Path.DirectorySeparatorChar + UniqueID;
    }

        public void Launch()
        {
            // Copy global pad configs to game config folder
            string gamepadFile = "LilyPad.ini";

            if (UseGlobalPad && System.IO.File.Exists(Program.GetFullPath(gamepadFile)))
            {
                System.IO.File.Copy(Program.GetFullPath(gamepadFile), Path.Combine(GetConfigDir(), gamepadFile), true);
            }

            // Start game and get it's process
            string emulatorFile = Program.GetFullPath(Properties.Settings.Default.PCSX2Path);
            string gameFile = Path.Combine(Properties.Settings.Default.DefaultDiskPath, File);

            Process p = Process.Start(emulatorFile,
                $"\"{gameFile}\"" +
                $" --cfgpath \"{Program.GetFullPath("Configs")}/{UniqueID}\"" +
                (NoGUI ? @" --nogui" : @" --console") +
                (Fullscreen ? @" --fullscreen" : @""));

            // Invisible when launch
            Program.frmMain.Hide();

            // Visible again when closed
            p.WaitForExit();
            Program.frmMain.Show();
        }

        public void LaunchConfig()
        {
            // Copy global pad configs to game config folder
            string gamepadFile = "LilyPad.ini";

            if (UseGlobalPad && System.IO.File.Exists(Program.GetFullPath(gamepadFile)))
            {
                System.IO.File.Copy(Program.GetFullPath(gamepadFile), Path.Combine(GetConfigDir(), gamepadFile), true);
            }

            // Start emulator with selected game for configuration purposes
            string emulatorFile = Program.GetFullPath(Properties.Settings.Default.PCSX2Path);
            string gameFile = Path.Combine(Properties.Settings.Default.DefaultDiskPath, File);

            Process p = Process.Start(emulatorFile,
                $"--cfgpath \"{Program.GetFullPath("Configs")}/{UniqueID}\"");
        }
    }

    // Version: 1.0
    public class GameV1
    {
        public string Name;
        public string File;

        public bool NoGUI;
        public bool Fullscreen;

        public bool UseGlobalPad;
    }
}
