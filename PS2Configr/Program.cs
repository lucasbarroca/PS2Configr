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
        public static string BaseDirectory = AppContext.BaseDirectory;

        public static List<Game> Games = new List<Game>();

        public static FrmMain frmMain;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Needed before any forms calling
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check app core needed before anything
            bool settingsOK = false;
            while (!settingsOK)
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.PCSX2Path))
                {
                    settingsOK = File.Exists(GetFullPath(Properties.Settings.Default.PCSX2Path));
                }

                if (!settingsOK)
                {
                    MessageBox.Show("You need to configure settings!", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new FrmSettings().ShowDialog();
                }
            }

            // Create needed directories
            Directory.CreateDirectory(GetFullPath("configs"));
            Directory.CreateDirectory(GetFullPath("bios"));
            Directory.CreateDirectory(GetFullPath("snaps"));
            Directory.CreateDirectory(GetFullPath("sstates"));
            Directory.CreateDirectory(GetFullPath("memcards"));
            Directory.CreateDirectory(GetFullPath("cheats"));
            Directory.CreateDirectory(GetFullPath("cheats_ws"));

            // Load Games list
            // Check for old format config file
            if (File.Exists(GetFullPath("config.xml")))
            {
                ConvertOldConfigToNew();
            }
            else if (File.Exists(GetFullPath("config.json"))) // Load new configuration format
            {
                LoadGamesList();
            }

            // Check for command line arguments
            List<string> arguments = new List<string>(Environment.GetCommandLineArgs());

            foreach (string arg in arguments)
            {
                if (arg == "-id" || arg == "-config")
                {
                    int nextId = arguments.FindIndex(a => a == arg) + 1;

                    // Prevent missing arguments errors
                    if (nextId < arguments.Count)
                    {
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

            frmMain = new FrmMain();
            Application.Run(frmMain);
        }

        public static void SaveGamesList()
        {
            SaveGamesListFile(Games);
        }

        static void SaveGamesListFile(List<Game> games)
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.TypeNameHandling = TypeNameHandling.Auto;

            string jsonData = JsonConvert.SerializeObject(games, Formatting.Indented, jsonSettings);
            File.WriteAllText(GetFullPath("config.json"), jsonData);

            CreateNeededFolders();
        }
        public static void LoadGamesList()
        {
            Games = null;

            string jsonData = File.ReadAllText(GetFullPath("config.json"));
            Games = JsonConvert.DeserializeObject<List<Game>>(jsonData);

            Games = Games.OrderBy(q => q.Name).ToList();

            CreateNeededFolders();
        }

        static void CreateNeededFolders()
        {
            // Create games config folders if not exists
            foreach (Game g in Games)
            {
                string gameCfgDir =$@"{GetFullPath("configs")}\" + g.UniqueID;

                if (!Directory.Exists(gameCfgDir))
                {
                    Directory.CreateDirectory(gameCfgDir);
                }
            }
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
                generated = chars[random.Next(1, chars.Length)] + generated.Substring(1, generated.Length - 1);
            }

            int number = int.Parse(generated);

            return number;
        }

        
        public static string GetSafeGameName(string PathName)
        {
            return PathName;
        }

        public static string GetFullPath(string path)
        {
            return Path.GetFullPath(path, BaseDirectory);
        }

        // Get filename relative to app directory
        public static string GetRelativePath(string path)
        {
            return Path.GetRelativePath(BaseDirectory, path);
        }

        // Convert XML config to new JSON format
        public static void ConvertOldConfigToNew()
        {
            // Load old config and replace some things...
            var oldCfgData = File.ReadAllText(GetFullPath("config.xml"));
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
                    // Get game data
                    var newGame = new Game(v1Game.Name, v1Game.File, v1Game.NoGUI, v1Game.Fullscreen, v1Game.UseGlobalPad);

                    // Generate it a unique id
                    GenerateUniqueGameId(newCfg, newGame);

                    // Rename game name on list
                    newGame.Name = Path.GetFileNameWithoutExtension(newGame.ROM);

                    // Add to new game list
                    newCfg.Add(newGame);

                    // Rename game config folder
                    Directory.Move($"{GetFullPath("configs")}/{newGame.Name}", $"{GetFullPath("configs")}/{newGame.UniqueID}");
                }

                // Save the config
                Games = newCfg;
                SaveGamesList();

                // Rename old config
                File.Move(GetFullPath("config.xml"), GetFullPath("config.old.xml"));

                CreateNeededFolders();
            }
        }

    }
}
