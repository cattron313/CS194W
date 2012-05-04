using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{
    class Setting
    {
        static private Dictionary<string, string> settingPaths;
        private string name;
        private string path;

        public Setting(string filename)
        {
            settingPaths = new Dictionary<string, string>();
            settingPaths.Add("Jungle", "Jungle[1].jpg");
            settingPaths.Add("Shipwreck", "Wreck on amangasette.jpg");
            settingPaths.Add("Temple", "B temple 1.jpg");
            name = filename;
            path = settingPaths[filename];
        }

        static Dictionary<string, string> getSettingPaths()
        {
            return settingPaths;
        }

        public string getName()
        {
            return name;
        }

        public string getPath()
        {
            return path;
        }
    }
}
