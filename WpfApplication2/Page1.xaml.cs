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
	public partial class Page1
	{
        public IStory del;
        public Runtime nui;
        public SkeletonController currentController;

		public Page1()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
            
		}

        private void selectSetting(object sender, MouseButtonEventArgs e)
        {
            Image i = (Image) sender;
            Frame recordAScene = new Frame();
            recordAScene.Source = new Uri("Page2.xaml", UriKind.Relative);
            recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
            Application.Current.MainWindow.Content = recordAScene;
            del.addSettingToScene(i.Name);
        }
    
        private void nui_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
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
                currentController.processSkeletonFramePage1(skeleton, this.MainCanvas);
            }
        }

        static public float k_xMaxJointScale = 1.5f;
        static public float k_yMaxJointScale = 1.5f;

        static private void SetEllipsePosition(Ellipse ellipse, Joint joint)
        {
            var scaledJoint = joint.ScaleTo(640, 480, k_xMaxJointScale, k_yMaxJointScale);

            Canvas.SetLeft(ellipse, scaledJoint.Position.X - (double)ellipse.GetValue(Canvas.WidthProperty) / 2);
            Canvas.SetTop(ellipse, scaledJoint.Position.Y - (double)ellipse.GetValue(Canvas.WidthProperty) / 2);
            Canvas.SetZIndex(ellipse, (int)-Math.Floor(scaledJoint.Position.Z * 100));
            if (joint.ID == JointID.HandLeft || joint.ID == JointID.HandRight)
            {
                byte val = (byte)(Math.Floor((joint.Position.Z - 0.8) * 255 / 2));
                ellipse.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(val, val, val));
            }
        }

        private void setUpKinect(object sender, RoutedEventArgs e)
        {
            nui.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady);
        }

        private void removeNUIEventHandler(object sender, RoutedEventArgs e)
        {
            nui.SkeletonFrameReady -= new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady);
        }


	}
}