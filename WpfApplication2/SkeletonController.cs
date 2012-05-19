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
using System.Windows.Media.Imaging;

namespace WpfApplication2
{
    public class SkeletonController
    {
        private MainWindow window;
        private IStory del;

        private bool userIsSelectingCharacter;
        private bool usingRightHand;
        private float lastZPosition;
        private Image characterToReposition;

        private string newCharacterToAdd;

        private ulong count = 0;

        public const double Z_SELECTION_THRESHOLD = 0.15;

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
                    if (eitherHandIsOverBorder((Border)uiElm, canvas, leftHand, rightHand))
                    {
                        selectSetting(((Image)((Border)uiElm).Child).Name);
                        break;
                    }
                }
            }
              
        }

        private bool eitherHandIsOverBorder(Border img, Canvas c, Joint lh, Joint rh)
        {
            return handIsOverBorder(img, c, lh) || handIsOverBorder(img, c, rh);
        }

        private bool handIsOverBorder(Border img, Canvas c, Joint h)
        {
            return h.Position.Y > Canvas.GetTop(img) && h.Position.Y < Canvas.GetTop(img) + img.ActualHeight &&
                 h.Position.X > Canvas.GetLeft(img) && h.Position.X < Canvas.GetLeft(img) + img.ActualWidth;
        }

        private void selectSetting(String name)
        {
            Frame recordAScene = new Frame();
            recordAScene.Source = new Uri("Page2.xaml", UriKind.Relative);
            recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
            Application.Current.MainWindow.Content = recordAScene;
            del.addSettingToScene(name);
        }

        private void moveCharacter(Joint hand)
        {
            Canvas.SetLeft(characterToReposition, hand.Position.X - characterToReposition.ActualWidth / 2);
            Canvas.SetTop(characterToReposition, hand.Position.Y - characterToReposition.ActualHeight / 2);
        }

        public virtual void processSkeletonFramePage2(SkeletonData skeleton, Canvas canvas, Page2 page)
        {
            Joint leftHand = skeleton.Joints[JointID.HandLeft].ScaleTo(640, 480, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointID.HandRight].ScaleTo(640, 480, window.k_xMaxJointScale, window.k_yMaxJointScale);
            bool shouldExitForLoop = false;

            if (userIsSelectingCharacter)
            {
                //User is moving the character
                Console.WriteLine("Z-value-diff: " + Math.Abs(rightHand.Position.Z - lastZPosition));
                if (usingRightHand && rightHand.Position.Z - lastZPosition <= -Z_SELECTION_THRESHOLD)
                {
                    moveCharacter(rightHand);
                }
                else if (!usingRightHand && leftHand.Position.Z - lastZPosition <= -Z_SELECTION_THRESHOLD)
                {
                    moveCharacter(leftHand);
                }
                else if (!eitherHandIsOverImage(characterToReposition, canvas, leftHand, rightHand)) userIsSelectingCharacter = false;
            }
            else
            {
                foreach (object uiElm in canvas.Children)
                {
                    if (uiElm is Rectangle)
                    {
                        if (eitherHandIsOverRectangle((Rectangle)uiElm, canvas, leftHand, rightHand))
                        {
                            if (String.Compare(((Rectangle)uiElm).Name, "record") == 0)
                            {
                                foreach (object obj in canvas.Children)
                                {
                                    if (obj is Label && String.Compare(((Label)obj).Name, "mode") == 0)
                                    {
                                        ((Label)obj).Content = "Record";
                                        shouldExitForLoop = true;
                                        break;
                                    }
                                }
                            }
                            else if (String.Compare(((Rectangle)uiElm).Name, "pause") == 0)
                            {
                                foreach (object obj in canvas.Children)
                                {
                                    if (obj is Label && String.Compare(((Label)obj).Name, "mode") == 0)
                                    {
                                        ((Label)obj).Content = "Paused";
                                        shouldExitForLoop = true;
                                        break;
                                    }
                                }
                            }
                            else if (String.Compare(((Rectangle)uiElm).Name, "endScene") == 0)
                            {

                            }
                            else if (String.Compare(((Rectangle)uiElm).Name, "toyBox") == 0)
                            {
                                Frame recordAScene = new Frame();
                                recordAScene.Source = new Uri("Page3.xaml", UriKind.Relative);
                                recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                Application.Current.MainWindow.Content = recordAScene;
                            }
                        }
                        if (shouldExitForLoop) break;
                    }
                    else if (uiElm is Canvas)
                    {
                        foreach (object child in ((Canvas)uiElm).Children)
                        {
                            if (child is Image)
                            {
                                if (handIsOverImage((Image)child, canvas, rightHand))
                                {
                                    Console.WriteLine("Right Hand Z" + rightHand.Position.Z);
                                    userIsSelectingCharacter = true;
                                    usingRightHand = true;
                                    characterToReposition = (Image)child;
                                    lastZPosition = rightHand.Position.Z;
                                    Console.WriteLine("Last Hand Z" + lastZPosition);
                                }
                                else if (handIsOverImage((Image)child, canvas, leftHand))
                                {
                                    userIsSelectingCharacter = true;
                                    usingRightHand = false;
                                    characterToReposition = (Image)child;
                                    lastZPosition = leftHand.Position.Z;
                                }
                                else
                                {
                                    userIsSelectingCharacter = false;
                                    lastZPosition = 0;
                                }

                            }
                        }
                    }
                }
            }
        }


        private bool eitherHandIsOverImage(Image img, Canvas c, Joint lh, Joint rh)
        {
            return handIsOverImage(img, c, lh) || handIsOverImage(img, c, rh);
        }

        private bool handIsOverImage(Image img, Canvas c, Joint h)
        {
            return h.Position.Y > Canvas.GetTop(img) && h.Position.Y < Canvas.GetTop(img) + img.ActualHeight &&
                 h.Position.X > Canvas.GetLeft(img) && h.Position.X < Canvas.GetLeft(img) + img.ActualWidth;
        }

        private bool eitherHandIsOverRectangle(Rectangle img, Canvas c, Joint lh, Joint rh)
        {
            return handIsOverRectangle(img, c, lh) || handIsOverRectangle(img, c, rh);
        }

        private bool handIsOverRectangle(Rectangle img, Canvas c, Joint h)
        {
            return h.Position.Y > Canvas.GetTop(img) && h.Position.Y < Canvas.GetTop(img) + img.ActualHeight &&
                 h.Position.X > Canvas.GetLeft(img) && h.Position.X < Canvas.GetLeft(img) + img.ActualWidth;
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


        internal void processSkeletonFramePage3(SkeletonData skeleton, Canvas canvas, Page3 page)
        {
            Joint leftHand = skeleton.Joints[JointID.HandLeft].ScaleTo(640, 480, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointID.HandRight].ScaleTo(640, 480, window.k_xMaxJointScale, window.k_yMaxJointScale);

            foreach (object uiElm in canvas.Children)
            {
                if (uiElm is Border)
                {
                    if (eitherHandIsOverBorder((Border)uiElm, canvas, leftHand, rightHand))
                    {
                        Border selected = (Border)uiElm;
                        if (String.Compare(selected.Name, "Meatwad") == 0)
                        {
                            String path = "C:\\Users\\Alexandria\\Documents\\Expression\\Blend 4\\Projects\\WpfApplication2\\WpfApplication2\\Meatwad_Images\\Meatwad.gif";
                            newCharacterToAdd = "Meatwad";
                            page.curCharact.Source = new BitmapImage(new Uri(path, UriKind.Absolute));

                        }
                        else if (String.Compare(selected.Name, "Optimus") == 0)
                        {
                            String path = "C:\\Users\\Alexandria\\Documents\\Expression\\Blend 4\\Projects\\WpfApplication2\\WpfApplication2\\Optimusg1_Images\\Optimusg1.png";
                            newCharacterToAdd = "Optimus Prime";
                            page.curCharact.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
                        }
                        else if (String.Compare(selected.Name, "SailorMoon") == 0)
                        {
                            String path = "C:\\Users\\Alexandria\\Documents\\Expression\\Blend 4\\Projects\\WpfApplication2\\WpfApplication2\\SMoon_Images\\SMoon.png";
                            newCharacterToAdd = "Sailor Moon";
                            page.curCharact.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
                        }
                        else if (String.Compare(selected.Name, "Done") == 0)
                        {
                            if (newCharacterToAdd != null) del.addCharacterToScene(CharacterList.getCharacter(newCharacterToAdd));
                            newCharacterToAdd = null;
                            Frame recordAScene = new Frame();
                            recordAScene.Source = new Uri("Page2.xaml", UriKind.Relative);
                            recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                            Application.Current.MainWindow.Content = recordAScene;
                        }
                        

                    }
                }
            }
        }
    }
    
}
