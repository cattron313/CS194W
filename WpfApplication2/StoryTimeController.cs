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

    public interface IStory
    {
        string addSettingToScene(string name);
        string getSettingPath();
        void addCharacterToScene(Character name);
        void removeCharacter(int id);
        List<Character> getAllCharactersInScene();
        void setSelectedCharacter(string name);
        string getSelectedCharacter();
        int getCurrentScene();
        void setAssistanceMode(bool flag);
        Boolean getAssitanceMode();
        void createANewStory();
        void removeCurrentScene();
        void setCharacterPosition(int id, double x, double y);
        double getCharacterPositionX(int id);
        double getCharacterPositionY(int id);
        String getPrompt();
    }

    public class StoryTimeController : IStory
    {
        private static MainWindow window;
        private static IStory del;
        private static List<String> prompts;
        private int currentScene;
        public static int MAX_SCENES = 3;
        private Boolean assistanceEnabled = false;
        private Story story;
        

        public StoryTimeController(MainWindow win)
        {
            window = win;
            del = (IStory)this;
            createANewStory();
            prompts = new List<String>();
            prompts.Add("Introduce your characters and the story setting. Tell us what they are doing here.");
            prompts.Add("This is the the scene of conflict or struggle. It's typically most exciting part of the story.");
            prompts.Add("How is the conflict resolved? How does your story end?");
        }

        public int getCurrentScene()
        {
            return currentScene;
        }

        public String getPrompt()
        {
            return prompts.ElementAt(currentScene +1);
        }

        public string addSettingToScene(string name)
        {
            Scene s = new Scene(name);
            story.addScene(s);
            currentScene++;
            Console.WriteLine("New Scene:" + currentScene);
            return s.getSetting().getPath();
        }

        public void addCharacterToScene(Character name)
        {
            Scene s = story.getScene(currentScene);
            s.addCharacter(name);
        }

        public void removeCharacter(int id)
        {
            Scene s = story.getScene(currentScene);
            s.removeCharacter(id);
        }

        public List<Character> getAllCharactersInScene()
        {

            return story.getScene(currentScene).getAllCharacters();
        }

        public static IStory getDelegate()
        {
            return del;
        }

        public string getSettingPath()
        {
            return story.getScene(currentScene).getSetting().getPath();
        }

        public void setSelectedCharacter(string name)
        {
            story.getScene(currentScene).setCurSelCharName(name);
        }

        public string getSelectedCharacter()
        {
            return story.getScene(currentScene).getcurSelCharName();
        }

        public void setAssistanceMode(bool flag)
        {
            assistanceEnabled = flag;
        }

        public Boolean getAssitanceMode()
        {
            return assistanceEnabled;
        }

        public void removeCurrentScene()
        {
            story.removeScene(currentScene);
            currentScene--;
        }

        public void createANewStory()
        {
            story = new Story();
            currentScene = -1;
        }

        public void setCharacterPosition(int id, double x, double y) 
        {
            story.getScene(currentScene).setCharacterPos(id, x, y);   
        }

        public double getCharacterPositionX(int id)
        {
            return story.getScene(currentScene).getCharacterX(id);
        }

        public double getCharacterPositionY(int id)
        {
            return story.getScene(currentScene).getCharacterY(id);
        }
    }
}
