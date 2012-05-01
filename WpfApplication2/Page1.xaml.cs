using System;
using System.Collections.Generic;
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
	public partial class Page1
	{
        IStory del;
		public Page1()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
		}

        private void Jungle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StoryTimeController st = new StoryTimeController();
            Image i = (Image) sender;
            Frame recordAScene = new Frame();
            recordAScene.Source = new Uri("Page2.xaml", UriKind.Relative);
            Application.Current.MainWindow.Content = recordAScene;
            st.addSettingToScene(i.Name);
        }
	}
}