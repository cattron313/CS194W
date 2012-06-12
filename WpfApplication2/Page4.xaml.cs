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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
       public IStory del;
       public KinectSensor sensor;
       public SkeletonController currentController;

        List<Image> curCharImages;

        public Page4()
        {
            this.InitializeComponent();
        }

        private void nui_SkeletonFrameReady4(object sender, SkeletonFrameReadyEventArgs e)
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
                    currentController.processSkeletonFramePage4(skeletons[0], this.main, this, curCharImages);
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

        public void loadCharacterParts(Character character)
        {
            curCharImages = new List<Image>();
            for (int i = 0; i < 22; i++)
            {
                if (character == null)
                    break;
                if (CharacterList.getCharacter(character.getName()).getPart(i).Equals(""))
                {
                    curCharImages.Add(null);
                    continue;
                }
                Image img = new Image();
                string charPath = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\" + character.getPart(i);
                img.Source = new BitmapImage(new Uri(charPath, UriKind.Absolute));
                img.Name = "character" + i.ToString() + character.getName();
                Console.WriteLine(img.Name);
                Canvas.SetTop(img, main.ActualHeight * .15);
                Canvas.SetLeft(img, main.ActualWidth * .25);
                this.main.Children.Add(img);
                curCharImages.Add(img);
                //currentCharName = character.getName();
            }
        }

        private void setUp(object sender, RoutedEventArgs e)
        {
            loadCharacterParts(CharacterList.getCharacter(del.getSelectedCharacter()));
            sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady4);
        }

        private void removeNUIEventHandler(object sender, RoutedEventArgs e)
        {
            sensor.SkeletonFrameReady -= new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady4);
        }

	}
 }
