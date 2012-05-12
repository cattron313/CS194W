using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{
    class Story
    {
        private List<Scene> sceneList;
        private string name;

        public Story()
        {
            sceneList = new List<Scene>();
        }

        public Scene getScene(int index)
        {
            Scene s = null;
            if (index < sceneList.Count)
            {
                s = sceneList[index];
            }
            return s;
        }

        public void addScene(Scene newScene)
        {
            sceneList.Add(newScene);
        }


    }
}
