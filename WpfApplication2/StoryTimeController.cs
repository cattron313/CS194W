using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{

    public interface IStory
    {
        string addSettingToScene(string name);
        string getSettingPath();
    }

    public class StoryTimeController : IStory
    {
        private static MainWindow window;
        private static IStory del;
        private int currentScene;
        
        private Story story;

        public StoryTimeController(MainWindow win)
        {
            window = win;
            del = (IStory)this;
            story = new Story();
            currentScene = -1;
        }

        public StoryTimeController()
        {

        }

        public string addSettingToScene(string name)
        {
            Scene s = new Scene(name);
            story.addScene(s);
            currentScene++;
            return s.getSetting().getPath();
        }

        public static IStory getDelegate()
        {
            return del;
        }

        public string getSettingPath()
        {
            return story.getScene(currentScene).getSetting().getPath();
        }


    }
}
