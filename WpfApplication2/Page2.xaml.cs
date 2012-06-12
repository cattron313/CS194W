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
using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf;

namespace WpfApplication2
{
    public partial class Page2
    {
        public IStory del;
        public KinectSensor sensor;
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
            String path = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\" + del.getSettingPath();
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
                        string charPath = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\Meatwad_Images\\Meatwad.gif";
                        img.Source = new BitmapImage(new Uri(charPath, UriKind.Absolute));
                    }
                    else if (String.Compare(character.getName(), "OptimusPrime") == 0)
                    {
                        string charPath = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\Optimusg1_Images\\Optimusg1.png";
                        img.Source = new BitmapImage(new Uri(charPath, UriKind.Absolute));
                    }
                    else
                    {
                        string charPath = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\SMoon_Images\\SMoon.png";
                        img.Source = new BitmapImage(new Uri(charPath, UriKind.Absolute));
                    }
                    img.Height = 250;
                    img.Width = 250;
                    img.Name = "c"+count.ToString() + "character" + character.getName();
                    Console.WriteLine(img.Name);
                    Canvas.SetTop(img, del.getCharacterPositionY(count));//buildAScene.ActualHeight / 2);
                    Canvas.SetLeft(img, del.getCharacterPositionX(count));//buildAScene.ActualWidth / 2);
                    this.buildAScene.Children.Add(img);
                    ++count;
                }

            }
        }

        private void nui_SkeletonFrameReady2(object sender, SkeletonFrameReadyEventArgs e)
        {
              //get the first tracked skeleton
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }

            if (skeletons != null && skeletons.Length != 0)
            {
                if (skeletons[0].TrackingState == SkeletonTrackingState.Tracked)
                {
                    SetEllipsePosition(leftEllipse, skeletons[0].Joints[JointType.HandLeft]);
                    SetEllipsePosition(rightEllipse, skeletons[0].Joints[JointType.HandRight]);
                    currentController.processSkeletonFramePage2(skeletons[0], this.controls, this, this.buildAScene);
                }
            }
        }

          

        static public float k_xMaxJointScale = .3f;
        static public float k_yMaxJointScale = .3f;

        static private void SetEllipsePosition(Ellipse ellipse, Joint joint)
        {
            var scaledJoint = joint.ScaleTo(1366, 768, k_xMaxJointScale, k_yMaxJointScale);

            Canvas.SetLeft(ellipse, scaledJoint.Position.X - (double)ellipse.GetValue(Canvas.WidthProperty) / 2);
            Canvas.SetTop(ellipse, scaledJoint.Position.Y - (double)ellipse.GetValue(Canvas.WidthProperty) / 2);
            Canvas.SetZIndex(ellipse, (int)Math.Floor(scaledJoint.Position.Z * 100));
            /*if (joint.ID == JointID.HandLeft || joint.ID == JointID.HandRight)
            {
                byte val = (byte)(Math.Floor((joint.Position.Z - 0.8) * 255 / 2));
                ellipse.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(val, val, val));
            }*/


        }

        private void setUpKinect(object sender, RoutedEventArgs e)
        {
            sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady2);
        }

        private void removeNUIEventHandler(object sender, RoutedEventArgs e)
        {
            sensor.SkeletonFrameReady -= new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady2);
        }

    }
}