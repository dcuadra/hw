using Newtonsoft.Json;
using System;
using System.IO;

namespace Utilities
{
    public class Configuration
    {
        public class Conf
        {
            public string BD { get; set; }
        }
        private static Conf conf;

        public static Conf Config
        {
            get
            {
                if (conf == null)
                {
                    #region get file
                    var name = "config";
#if DEBUG
                    name += ".debug";
#endif

                    var file = $@"c:\config\{name}.json";
                    if (!File.Exists(file))
                        file = $@"d:\config\{name}.json";
                    if (!File.Exists(file))
                    {
                        var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                        while (!File.Exists(file))
                        {
                            dir = dir.Parent;
                            if (dir.Root.FullName == dir.FullName)
                                break;
                            file = $@"{dir.FullName}\{name}.json";
                        }
                    }
                    if (!File.Exists(file))
                        throw new Exception($"There is no configuration file, there must exist the file {name}");
                    #endregion
                    Console.WriteLine($@"Configuration file: {file}");
                    try
                    {
                        string Json = System.IO.File.ReadAllText(file);
                        conf = JsonConvert.DeserializeObject<Conf>(Json);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(@"The configuration file is wrong.
See if you have only put one \, your shoud put \\", ex);
                    }
                }
                return conf;
            }
            set
            {
                conf = value;
            }
        }

    }
}
