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
using Microsoft.Research.Kinect.Nui;
using Coding4Fun.Kinect.Wpf;

namespace WpfApplication2
{
	public partial class Page2
    {
        public IStory del;
        public Runtime nui;
        public SkeletonController currentController;
	
		public Page2()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
		}

		private void setBackground(object sender, System.Windows.RoutedEventArgs e)
		{
            Frame f = this.frame1;
            String path = "C:\\Users\\Alexandria\\Documents\\Expression\\Blend 4\\Projects\\WpfApplication2\\WpfApplication2\\" + del.getSettingPath();
            ImageBrush bg = new ImageBrush();
            bg.ImageSource = new BitmapImage(new Uri(path, UriKind.Absolute));
            f.Background = bg;
		}

	}
}