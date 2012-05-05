using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
