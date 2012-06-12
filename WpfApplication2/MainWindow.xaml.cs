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
using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf;
using System.IO;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        static StoryTimeController st;
        static KinectSensor sensor;
        static SkeletonController currentController;

        //Scaling constants
        public float k_xMaxJointScale = .3f;
        public float k_yMaxJointScale = .3f;

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
                ((Page1)e.Content).sensor = sensor;
                ((Page1)e.Content).currentController = currentController;
            }
            else if (((Frame)sender).Source.ToString() == "Page2.xaml")
            {
                ((Page2)e.Content).del = st;
                ((Page2)e.Content).sensor = sensor;
                ((Page2)e.Content).currentController = currentController;
            }
            else if (((Frame)sender).Source.ToString() == "Page3.xaml")
            {
                ((Page3)e.Content).del = st;
                ((Page3)e.Content).sensor = sensor;
                ((Page3)e.Content).currentController = currentController;
            }
            else if (((Frame)sender).Source.ToString() == "Page4.xaml")
            {
                ((Page4)e.Content).del = st;
                ((Page4)e.Content).sensor = sensor;
                ((Page4)e.Content).currentController = currentController;
            }
            else if (((Frame)sender).Source.ToString() == "WpfApplication2;component/Page5.xaml")
            {
                ((Page5)e.Content).del = st;
                ((Page5)e.Content).sensor = sensor;
                ((Page5)e.Content).currentController = currentController;
            }
            else if (((Frame)sender).Source.ToString() == "Page6.xaml")
            {
                ((Page6)e.Content).del = st;
                ((Page6)e.Content).sensor = sensor;
                ((Page6)e.Content).currentController = currentController;
            }
            else if (((Frame)sender).Source.ToString() == "Page7.xaml")
            {
                ((Page7)e.Content).del = st;
                ((Page7)e.Content).sensor = sensor;
                ((Page7)e.Content).currentController = currentController;
            }
            else if (((Frame)sender).Source.ToString() == "Page8.xaml")
            {
                ((Page8)e.Content).del = st;
                ((Page8)e.Content).sensor = sensor;
                ((Page8)e.Content).currentController = currentController;
            }
            else if (((Frame)sender).Source.ToString() == "WpfApplication2;component/Page9.xaml")
            {
                ((Page9)e.Content).del = st;
                ((Page9)e.Content).sensor = sensor;
                ((Page9)e.Content).currentController = currentController;
            }
        }

        private void SetupKinect()
        {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    sensor = potentialSensor;
                    break;
                }
            }

            if (null != sensor)
            {
                // Turn on the skeleton stream to receive skeleton frames
                sensor.SkeletonStream.Enable();

                // Add an event handler to be called whenever there is new color frame data
                //sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;
                sensor.SkeletonStream.Enable(new TransformSmoothParameters()
                {
                    Correction = 0.3f, JitterRadius = 0.7f, MaxDeviationRadius = 0.2f, Smoothing = 0.3f, Prediction = 0.4f
                });
                // Start the sensor!
                try
                {
                    sensor.Start();

                }
                catch (IOException)
                {
                    sensor = null;
                }
            }

            if (null == sensor)
            {
                this.Title = "No Kinect connected";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Cleanup
            if (null != sensor)
            {
                sensor.Stop();
            }
        }

        private void WindowCloseOnEsc_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            /*if (e.Key.ToString().Equals("Escape"))
            {
                this.Close();
                nui.Uninitialize();
            }*/
        }

    }
}