using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
        private int count = 1;
	
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
            setUpKinect(sender, e);
            List<Character> list = del.getAllCharactersInScene();
            
            
            foreach (Character character in list)
            {
                if (character != null)
                {
                    Image img = new Image();
                    if (String.Compare(character.getName(), "Meatwad") == 0)
                    {
                        string charPath = "C:\\Users\\Alexandria\\Documents\\Expression\\Blend 4\\Projects\\WpfApplication2\\WpfApplication2\\Meatwad_Images\\Meatwad.gif";
                        img.Source = new BitmapImage(new Uri(charPath, UriKind.Absolute));
                    }
                    else if (String.Compare(character.getName(), "OptimusPrime") == 0)
                    {
                        string charPath = "C:\\Users\\Alexandria\\Documents\\Expression\\Blend 4\\Projects\\WpfApplication2\\WpfApplication2\\Optimusg1_Images\\Optimusg1.png";
                        img.Source = new BitmapImage(new Uri(charPath, UriKind.Absolute));
                    }
                    else
                    {
                        string charPath = "C:\\Users\\Alexandria\\Documents\\Expression\\Blend 4\\Projects\\WpfApplication2\\WpfApplication2\\SMoon_Images\\SMoon.png";
                        img.Source = new BitmapImage(new Uri(charPath, UriKind.Absolute));
                    }
                    img.Height = 100;
                    img.Width = 100;
                    img.Name = "character" + character.getName() + count.ToString();
                    Console.WriteLine(img.Name);
                    Canvas.SetTop(img, buildAScene.ActualHeight / 2);
                    Canvas.SetLeft(img, buildAScene.ActualWidth / 2);
                    this.buildAScene.Children.Add(img);
                    ++count;
                }
                
            }
		}

        private void nui_SkeletonFrameReady2(object sender, SkeletonFrameReadyEventArgs e)
        {

            SkeletonFrame allSkeletons = e.SkeletonFrame;

            //get the first tracked skeleton
            SkeletonData skeleton = (from s in allSkeletons.Skeletons
                                     where s.TrackingState == SkeletonTrackingState.Tracked
                                     select s).FirstOrDefault();

            if (skeleton != null)
            {
                SetEllipsePosition(leftEllipse, skeleton.Joints[JointID.HandLeft]);
                SetEllipsePosition(rightEllipse, skeleton.Joints[JointID.HandRight]);
                currentController.processSkeletonFramePage2(skeleton, this.controls, this);
            }
        }

        static public float k_xMaxJointScale = .5f;
        static public float k_yMaxJointScale = .5f;

        static private void SetEllipsePosition(Ellipse ellipse, Joint joint)
        {
            var scaledJoint = joint.ScaleTo(640, 480, k_xMaxJointScale, k_yMaxJointScale);

            Canvas.SetLeft(ellipse, scaledJoint.Position.X - (double)ellipse.GetValue(Canvas.WidthProperty) / 2);
            Canvas.SetTop(ellipse, scaledJoint.Position.Y - (double)ellipse.GetValue(Canvas.WidthProperty) / 2);
            Canvas.SetZIndex(ellipse, (int)Math.Floor(scaledJoint.Position.Z * 100));
            if (joint.ID == JointID.HandLeft || joint.ID == JointID.HandRight)
            {
                byte val = (byte)(Math.Floor((joint.Position.Z - 0.8) * 255 / 2));
                ellipse.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(val, val, val));
            }

            
        }

        private void setUpKinect(object sender, RoutedEventArgs e)
        {
            nui.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady2);
        }

        private void removeNUIEventHandler(object sender, RoutedEventArgs e)
        {
            nui.SkeletonFrameReady -= new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady2);
        }

	}
}