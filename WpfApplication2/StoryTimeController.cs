using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{

    public interface IStory
    {
        void addSettingToScene(String name);

    }

    public class StoryTimeController : IStory
    {
        private static MainWindow window;
        private static IStory del;
        private Dictionary<String, String> settingPaths;

        public StoryTimeController(MainWindow win)
        {
            window = win;
            del = (IStory)this;

        }

        public StoryTimeController()
        {

        }

        public void addSettingToScene(String name)
        {

        }

        public static IStory getDelegate()
        {
            return del;
        }


    }
}
