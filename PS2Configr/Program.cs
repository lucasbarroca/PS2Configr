using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PS2Configr
{
    static class Program
    {
        public static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static List<Game> Games = new List<Game>();

        public static FrmMain frmMain;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check app core needed before anything
            bool settingsOK = false;
            while (!settingsOK)
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.PCSX2Path))
                    settingsOK = File.Exists(Path.GetFullPath(Properties.Settings.Default.PCSX2Path));

                if (!settingsOK)
                {
                    MessageBox.Show("You need to configure settings!", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new FrmSettings().ShowDialog();
                }
            }

            if (!Directory.Exists("Configs"))
            {
                Directory.CreateDirectory("Configs");
            }

            // Load Games list
            // Check for old format config file
            if (File.Exists("config.xml"))
            {
                ConvertOldConfigToNew();
            }
            else if (File.Exists("config.json")) // Load new configuration format
            {
                LoadConfig();
            }

            // Create games config folders if not exists
            foreach (Game g in Games)
            {
                if (!Directory.Exists(@"Configs\" + g.Name))
                {
                    Directory.CreateDirectory(@"Configs\" + g.Name);
                }
            }

            // Check for command line arguments
            List<string> arguments = new List<string>(Environment.GetCommandLineArgs());

            foreach (string arg in arguments)
            {
                if (arg == "-id" || arg == "-config")
                {
                    int nextId = arguments.FindIndex(a => a == arg) + 1;

                    // Prevent missing arguments errors
                    if (nextId < arguments.Count) {
                        // Get argument value
                        int uid = int.Parse(arguments[nextId]);
                        foreach (Game g in Games)
                        {
                            if (g.UniqueID == uid)
                            {
                                if (arg == "-id")
                                {
                                    g.Launch();
                                }
                                else
                                {
                                    g.LaunchConfig();
                                }
                            }
                        }

                        Environment.Exit(0);
                    }
                }
                else if (arg == "-name" || arg == "-configname")
                {
                    int nextId = arguments.FindIndex(a => a == arg) + 1;

                    // Prevent missing arguments errors
                    if (nextId < arguments.Count)
                    {
                        // Get argument value
                        string name = arguments[nextId];
                        foreach (Game g in Games)
                        {
                            if (g.Name == name)
                            {
                                if (arg == "-name")
                                {
                                    g.Launch();
                                }
                                else
                                {
                                    g.LaunchConfig();
                                }
                            }
                        }

                        Environment.Exit(0);
                    }
                }
            }

            // Start main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain = new FrmMain();
            Application.Run(frmMain);
        }

        public static void ConvertOldConfigToNew()
        {
            // Load old config and replace some things...
            var oldCfgData = File.ReadAllText("config.xml");
            oldCfgData = oldCfgData.Replace("ArrayOfGame", "ArrayOfGameV1");
            oldCfgData = oldCfgData.Replace("<Game>", "<GameV1>");
            oldCfgData = oldCfgData.Replace("</Game>", "</GameV1>");

            using (StringReader sr = new StringReader(oldCfgData))
            {            
                // Load old config
                var oldCfg = (List<GameV1>)new XmlSerializer(new List<GameV1>().GetType()).Deserialize(sr);

                // Populate new config
                var newCfg = new List<Game>();
                foreach (GameV1 v1Game in oldCfg)
                {
                    var newGame = new Game(v1Game.Name, v1Game.File, v1Game.NoGUI, v1Game.Fullscreen, v1Game.UseGlobalPad);
                    GenerateUniqueGameId(newCfg, newGame);
                    newCfg.Add(newGame);                
                }

                // Save the config
                Games = newCfg;
                SaveConfig();

                // Rename old config
                File.Move("config.xml", "config.old.xml");
            }
        }

        public static void SaveConfig()
        {
            SaveConfigFile(Games);
        }

        static void SaveConfigFile(List<Game> games)
        {
            string jsonData = JsonConvert.SerializeObject(games, Formatting.Indented);
            File.WriteAllText("config.json", jsonData);
        }

        public static void LoadConfig()
        {
            string jsonData = File.ReadAllText("config.json");
            Games = JsonConvert.DeserializeObject<List<Game>>(jsonData);
        }

        public static void GenerateUniqueGameId(List<Game> gameList, Game game)
        {
            bool NumberIsUnique = false;
            while (!NumberIsUnique)
            {
                // Generate new number
                var number = GenerateUniqueNumber(6);

                // Check if number is unique
                var found = gameList.Where(g => g.UniqueID == number);
                if (found.ToList().Count == 0)
                {
                    game.UniqueID = number;
                    NumberIsUnique = true;
                }
            }
        }

        static int GenerateUniqueNumber(int length) {
            const string chars = "0123456789";
            
            var random = new Random();
            string generated = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            // don't permit numbers started with 0
            if (generated.StartsWith("0"))
            {
                generated = chars[random.Next(1, chars.Length)] + generated.Substring(1, generated.Length -1);
            }

            int number = int.Parse(generated);

            return number;
        }

        public static string GetSafeGameName(string PathName)
        {
            foreach (char c in Path.GetInvalidPathChars())
                PathName = PathName.Replace(c.ToString(), string.Empty);

            foreach (char c in Path.GetInvalidFileNameChars())
                PathName = PathName.Replace(c.ToString(), string.Empty);

            return PathName;
        }

        public static string GetRelativePath(string filePath)
        {
            var fileUri = new Uri(filePath);
            var referenceUri = new Uri(Environment.CurrentDirectory + @"\");
            return referenceUri.MakeRelativeUri(fileUri).ToString().Replace("%20", " ").Replace("/", @"\");
        }
    }
}
