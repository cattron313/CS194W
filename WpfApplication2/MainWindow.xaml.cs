using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.Research.Kinect.Nui;
using Coding4Fun.Kinect.Wpf;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        static StoryTimeController st;
        static Runtime nui;
        static SkeletonController currentController;

        //Scaling constants
        public float k_xMaxJointScale = 1.5f;
        public float k_yMaxJointScale = 1.5f;

        public MainWindow()
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.
            SetUpNaviNotifications();
            SetupKinect();

            st = new StoryTimeController(this);
            currentController = new SkeletonController(this, st);
        }

        private void SetUpNaviNotifications()
        {
            this.frame1.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(NavigationService_LoadCompleted);
        }

        public static void NavigationService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (((Frame)sender).Source.ToString() == "WpfApplication2;component/Page1.xaml")
            {
                ((Page1)e.Content).del = st;
                ((Page1)e.Content).nui = nui;
                ((Page1)e.Content).currentController = currentController;
            }
            else if (((Frame)sender).Source.ToString() == "Page2.xaml")
            {
                ((Page2)e.Content).del = st;
                ((Page2)e.Content).nui = nui;
                ((Page2)e.Content).currentController = currentController;
            }
        }

        private void SetupKinect()
        {
            if (Runtime.Kinects.Count == 0)
            {
                this.Title = "No Kinect connected";
            }
            else
            {
                //use first Kinect
                nui = Runtime.Kinects[0];

                //Initialize to do skeletal tracking
                nui.Initialize(RuntimeOptions.UseSkeletalTracking | RuntimeOptions.UseColor | RuntimeOptions.UseDepthAndPlayerIndex);

                //add event to receive skeleton data
                //nui.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady);

                //add event to receive video data
                //nui.VideoFrameReady += new EventHandler<ImageFrameReadyEventArgs>(nui_VideoFrameReady);

                //to experiment, toggle TransformSmooth between true & false and play with parameters            
                nui.SkeletonEngine.TransformSmooth = true;
                TransformSmoothParameters parameters = new TransformSmoothParameters();
                // parameters used to smooth the skeleton data
                parameters.Smoothing = 0.3f;
                parameters.Correction = 0.3f;
                parameters.Prediction = 0.4f;
                parameters.JitterRadius = 0.7f;
                parameters.MaxDeviationRadius = 0.2f;
                nui.SkeletonEngine.SmoothParameters = parameters;

                //Open the video stream
                //nui.VideoStream.Open(ImageStreamType.Video, 2, ImageResolution.Resolution640x480, ImageType.Color);

                //Force video to the background
                //Canvas.SetZIndex(image1, -10000);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Cleanup
            nui.Uninitialize();
        }

    }
}