using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
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
        public string ROM;

        public bool NoGUI;
        public bool Fullscreen;

        public bool UseGlobalPad;

        public Game()
        {

        }

        public Game(string Name, string ROM, bool NoGUI, bool Fullscreen, bool UseGlobalPad)
        {
            this.Name = Name;
            this.ROM = ROM;

            this.NoGUI = NoGUI;
            this.Fullscreen = Fullscreen;

            this.UseGlobalPad = UseGlobalPad;
        }

        public string GetConfigDir()
        {
            return Program.GetFullPath("configs") + Path.DirectorySeparatorChar + UniqueID;
    }

        public void Launch()
        {
            // Prepare game configs before
            PrepareConfigFiles();

            // Start game and get it's process
            string emulatorFile = Program.GetFullPath(Properties.Settings.Default.PCSX2Path);
            string gameFile = Path.Combine(Properties.Settings.Default.DefaultDiskPath, ROM);

            Process p = Process.Start(emulatorFile,
                $"\"{gameFile}\"" +
                $" --cfgpath \"{Program.GetFullPath("configs")}/{UniqueID}\"" +
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
            // Prepare game configs before
            PrepareConfigFiles();

            // Start emulator with selected game for configuration purposes
            string emulatorFile = Program.GetFullPath(Properties.Settings.Default.PCSX2Path);

            Process.Start(emulatorFile,
                $"--cfgpath \"{Program.GetFullPath("configs")}/{UniqueID}\"");
        }

        public void PrepareConfigFiles()
        {
            // Get folders ini file
            string iniFilename = Program.GetFullPath($"{Program.GetFullPath("configs")}/{UniqueID}/PCSX2_ui.ini");

            if (File.Exists(iniFilename))
            {
                var iniParser = new FileIniDataParser();
                IniData foldersIni = iniParser.ReadFile(iniFilename);

                // Configure PCSX2 Folders
                foldersIni["Folders"]["Bios"] = EscapePathString(Program.GetFullPath("bios"));
                foldersIni["Folders"]["Snapshots"] = EscapePathString(Program.GetFullPath("snaps"));
                foldersIni["Folders"]["Savestates"] = EscapePathString(Program.GetFullPath("sstates"));
                foldersIni["Folders"]["MemoryCards"] = EscapePathString(Program.GetFullPath("memcards"));
                foldersIni["Folders"]["Cheats"] = EscapePathString(Program.GetFullPath("cheats"));
                foldersIni["Folders"]["CheatsWS"] = EscapePathString(Program.GetFullPath("cheats_ws"));               

                // Save folders ini file
                iniParser.WriteFile(iniFilename, foldersIni);
            }

            // Copy global pad configs to game config folder
            string gamepadFile = "LilyPad.ini";

            if (UseGlobalPad && File.Exists(Program.GetFullPath(gamepadFile)))
            {
                File.Copy(Program.GetFullPath(gamepadFile), Path.Combine(GetConfigDir(), gamepadFile), true);
            }
        }

        string EscapePathString(string path)
        {
            return JsonConvert.ToString(path);
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
