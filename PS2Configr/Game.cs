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

        public void Launch()
        {
            // Copy global pad configs to game config folder
            if (UseGlobalPad && System.IO.File.Exists("LilyPad.ini"))
                System.IO.File.Copy("LilyPad.ini", @"Configs\" + UniqueID + @"\LilyPad.ini", true);

            // Start game and get it's process
            Process p = Process.Start(Properties.Settings.Default.PCSX2Path,
                @"""" + Path.Combine(Properties.Settings.Default.DefaultDiskPath, File) + @"""" +
                @" --cfgpath """ + Path.Combine(Environment.CurrentDirectory, @"Configs\" + UniqueID) + @"""" +

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
            if (UseGlobalPad && System.IO.File.Exists("LilyPad.ini"))
                System.IO.File.Copy("LilyPad.ini", @"Configs\" + UniqueID + @"\LilyPad.ini", true);

            // Start emulator with selected game for configuration purposes
            Process.Start(Properties.Settings.Default.PCSX2Path,
                @"--cfgpath """ + Path.Combine(Environment.CurrentDirectory, @"Configs\" + UniqueID) + @"""");
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
