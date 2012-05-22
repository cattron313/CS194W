
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;

namespace WpfApplication2
{
    class Scene
    {
        private int id;
        private Setting location;
        private List<Character> characterList;
        private List<Prop> propList;
        private RecordVideo sceneVid;
        private string curSelCharName;
 

        public Scene(string p)
        {
            location = new Setting(p);
            characterList = new List<Character>();
            propList = new List<Prop>();
            curSelCharName = "";
        }

        public Setting getSetting()
        {
            return location;
        }

        internal void addCharacter(Character name)
        {
            characterList.Add(name);
        }

        internal List<Character> getAllCharacters()
        {
            return characterList;
        }

        public void setCurSelCharName(string name)
        {
            curSelCharName = name;
        }

        public string getcurSelCharName()
        {
            return curSelCharName;
        }
    }
}
