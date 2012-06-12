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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        bool charSelected = false;
        int curCharIndex = 0;
        public IStory del;
        public KinectSensor sensor;
        public SkeletonController currentController;

        public Page3()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String path = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\Meatwad_Images\\Meatwad.gif";
            curCharIndex = 0;
            //this.Layer_0.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
            charSelected = true;


            //ImageBrush bg = new ImageBrush();
            //bg.ImageSource = new BitmapImage(new Uri(path, UriKind.Absolute));


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String path = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\Optimusg1_Images\\Optimusg1.png";
            curCharIndex = 1;
            //this.Layer_0.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
            charSelected = true;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String path = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\SMoon_Images\\SMoon.png";
            curCharIndex = 2;
            //this.Layer_0.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
            charSelected = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Layer_0_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Console.Write("Image Failed");
            Console.WriteLine();
        }

        private void nui_SkeletonFrameReady3(object sender, SkeletonFrameReadyEventArgs e)
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
                    currentController.processSkeletonFramePage3(skeletons[0], this.characterSel, this);
                }
            }
        }

        static public float k_xMaxJointScale = .38f;
        static public float k_yMaxJointScale = .38f;

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
            sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady3);
        }

        private void removeNUIEventHandler(object sender, RoutedEventArgs e)
        {
            sensor.SkeletonFrameReady -= new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady3);
        }

	}
}