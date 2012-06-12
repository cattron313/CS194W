
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

        public void setSetting(string p)
        {
            Setting newLoc = new Setting(p);
            location = newLoc;
            //return location;
        }

        public Setting getSetting()
        {
            return location;
        }

        internal void addCharacter(Character name)
        {
            characterList.Add(name);
        }

        internal void removeCharacter(int id)
        {
          /*  for (int i = 0; i < characterList.Count(); i++)
                if (characterList.ElementAt(i).getName().Equals(name.getName()))
                {
                    characterList.RemoveAt(i);
                    return;
                }*/
            characterList.RemoveAt(id - 1);
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

        public void setCharacterPos(int id, double x, double y)
        {
            characterList.ElementAt(id-1).setPosition(x, y);
        }

        public double getCharacterX(int id)
        {
            return characterList.ElementAt(id-1).getXPos();
        }
        public double getCharacterY(int id)
        {
            return characterList.ElementAt(id-1).getYPos();
        }
    }
}
