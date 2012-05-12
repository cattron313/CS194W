using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using Microsoft.Research.Kinect.Nui;
using Coding4Fun.Kinect.Wpf;
using System.Timers;
using System.Threading;

namespace WpfApplication2
{
    public class SkeletonController
    {
        private MainWindow window;
        private IStory del;

        public SkeletonController(MainWindow win, IStory stDelegate)
        {
            window = win;
            del = stDelegate;
        }

        //This function will be implemented by you in the subclass files provided.
        //A simple example of highlighting targets when hovered over has been provided below

        //Note: targets is a dictionary that allows you to retrieve the corresponding target on screen
        //and manipulate its state and position, as well as hide/show it (see class defn. below).
        //It is indexed from 1, thus you can retrieve an individual target with the expression
        //targets[3], which would retrieve the target labeled "3" on screen.
        public virtual void processSkeletonFramePage1(SkeletonData skeleton, Canvas canvas)
        {
            Joint leftHand = skeleton.Joints[JointID.HandLeft].ScaleTo(640, 480, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointID.HandRight].ScaleTo(640, 480, window.k_xMaxJointScale, window.k_yMaxJointScale);

            /*Example implementation*/

            foreach (object uiElm in canvas.Children) 
            {
                if (uiElm is Border)
                {
                    if (eitherHandIsOverImage((Border)uiElm, canvas, leftHand, rightHand)) 
                    {
                        selectSetting(((Image)((Border)uiElm).Child).Name);
                        break;
                    }
                }
            }
        }

        private bool eitherHandIsOverImage(Border img, Canvas c, Joint lh, Joint rh)
        {
            bool isAHandOverImage = (lh.Position.Y > Canvas.GetTop(img) && lh.Position.Y < Canvas.GetTop(img) + img.ActualHeight && 
                lh.Position.X > Canvas.GetLeft(img) && lh.Position.X < Canvas.GetLeft(img) + img.ActualWidth);
            if (!isAHandOverImage) isAHandOverImage = rh.Position.Y > Canvas.GetTop(img) && rh.Position.Y < Canvas.GetTop(img) + img.ActualHeight &&
                rh.Position.X > Canvas.GetLeft(img) && rh.Position.X < Canvas.GetLeft(img) + img.ActualWidth;
            return isAHandOverImage;
        }

        private void selectSetting(String name)
        {
            Frame recordAScene = new Frame();
            recordAScene.Source = new Uri("Page2.xaml", UriKind.Relative);
            recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
            Application.Current.MainWindow.Content = recordAScene;
            del.addSettingToScene(name);
        }

        public virtual void processSkeletonFramePage2(SkeletonData skeleton, Canvas canvas)
        {
            Joint leftHand = skeleton.Joints[JointID.HandLeft].ScaleTo(640, 480, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointID.HandRight].ScaleTo(640, 480, window.k_xMaxJointScale, window.k_yMaxJointScale);

            foreach (object uiElm in canvas.Children) 
            {
                if (uiElm is Rectangle)
                {
                    if (eitherHandIsOverButton((Rectangle)uiElm, canvas, leftHand, rightHand)) 
                    {
                       if (String.Compare(((Rectangle)uiElm).Name, "Record") == 0)
                       {


                       }
                       else if (String.Compare(((Rectangle)uiElm).Name, "Pause") == 0)
                       {


                       }
                       else if (String.Compare(((Rectangle)uiElm).Name, "End Scene") == 0)
                       {

                       }
                       else if(String.Compare(((Rectangle)uiElm).Name, "Toy Box") == 0)
                       {
                           Console.WriteLine("Add Character");
                       }
                    }
                }
            }
        }

        public bool eitherHandIsOverButton(Rectangle r, Canvas c, Joint lh, Joint rh)
        {
            bool isAHandOverButton = (lh.Position.Y > Canvas.GetTop(r) && lh.Position.Y < Canvas.GetTop(r) + r.ActualHeight &&
                lh.Position.X > Canvas.GetLeft(r) && lh.Position.X < Canvas.GetLeft(r) + r.ActualWidth);
            if (!isAHandOverButton) isAHandOverButton = rh.Position.Y > Canvas.GetTop(r) && rh.Position.Y < Canvas.GetTop(r) + r.ActualHeight &&
                rh.Position.X > Canvas.GetLeft(r) && rh.Position.X < Canvas.GetLeft(r) + r.ActualWidth;
            return isAHandOverButton;
        }

        //This is called when the controller becomes active. This allows you to place your targets and do any 
        //initialization that you don't want to repeat with each new skeleton frame. You may also 
        //directly move the targets in the MainWindow.xaml file to achieve the same initial repositioning.
        public virtual void controllerActivated()
        {
         
        }

        //The default value that gets passed to MaxSkeletonX and MaxSkeletonY in the Coding4Fun Joint.ScaleTo function is 1.5f
        //This function will change that so that your scaling in processSkeletonFrame aligns with the scaling done when we
        //position the ellipses in the MainWindow.xaml.cs file.
        public void adjustScale(float f)
        {
            window.k_xMaxJointScale = f;
            window.k_yMaxJointScale = f;
        }

    }


    
}
