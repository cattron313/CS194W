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
    public partial class Page7
    {
        public IStory del;
        public KinectSensor sensor;
        public SkeletonController currentController;

        public Page7()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void nui_SkeletonFrameReady7(object sender, SkeletonFrameReadyEventArgs e)
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
                    currentController.processSkeletonFramePage7(skeletons[0], this.controls, this);
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
            sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady7);
        }

        private void removeNUIEventHandler(object sender, RoutedEventArgs e)
        {
            sensor.SkeletonFrameReady -= new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady7);
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void Image_ImageFailed_1(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
