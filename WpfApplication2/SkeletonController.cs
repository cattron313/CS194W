using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf;
using System.Timers;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace WpfApplication2
{
    public class SkeletonController
    {
        private MainWindow window;
        private IStory del;

        private bool userIsSelectingCharacter;
        private bool usingRightHand;
        private float lastZPosition;
        private System.Windows.Controls.Image characterToReposition;
        private string selectedCharacterName;
        private ulong frameCount;

        private MainWindow lastWindow;
        private Frame lastFrame;
        private string newCharacterToAdd;
        List<Joint> previousJoints;

        private ulong count = 0;

        public const double Z_SELECTION_THRESHOLD = 0.15;
        public const ulong TIMER = 2; //in seconds
        public const uint FRAME_PER_SEC = 30;

        public SkeletonController(MainWindow win, IStory stDelegate)
        {
            window = win;
            del = stDelegate;
            frameCount = 0;
        }

        //This function will be implemented by you in the subclass files provided.
        //A simple example of highlighting targets when hovered over has been provided below

        //Note: targets is a dictionary that allows you to retrieve the corresponding target on screen
        //and manipulate its state and position, as well as hide/show it (see class defn. below).
        //It is indexed from 1, thus you can retrieve an individual target with the expression
        //targets[3], which would retrieve the target labeled "3" on screen.

        bool clutchIsEngaged(Joint lh, Joint rh, Joint spine)
        {
            if (lh.Position.X <= spine.Position.X + 30 && lh.Position.X >= spine.Position.X - 30 &&
                lh.Position.Y <= spine.Position.Y + 30 && lh.Position.Y >= spine.Position.Y - 30 &&
                lh.Position.Z <= spine.Position.Z + Z_SELECTION_THRESHOLD && lh.Position.Z >= spine.Position.Z - Z_SELECTION_THRESHOLD)
            {
                return true;
            }
            if (rh.Position.X <= spine.Position.X + 30 && rh.Position.X >= spine.Position.X - 30 &&
                rh.Position.Y <= spine.Position.Y + 30 && rh.Position.Y >= spine.Position.Y - 30 &&
                rh.Position.Z <= spine.Position.Z + Z_SELECTION_THRESHOLD && rh.Position.Z >= spine.Position.Z - Z_SELECTION_THRESHOLD)
            {
                return true;
            }
            return false;
        }

        public virtual void processSkeletonFramePage1(Skeleton skeleton, Canvas canvas)
        {
            Joint leftHand = skeleton.Joints[JointType.HandLeft].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointType.HandRight].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint spine = skeleton.Joints[JointType.Spine].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint neck = skeleton.Joints[JointType.ShoulderCenter].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            bool handIsOverAtleastOneRectangle = false;

            //   System.Drawing.Graphics g;// = new Graphics();
            /*Example implementation*/
           // if (clutchIsEngaged(leftHand, rightHand, spine))
            //{
                foreach (object uiElm in canvas.Children)
                {
                    if (uiElm is System.Windows.Shapes.Rectangle)
                    {
                        if (eitherHandIsOverRectangle((System.Windows.Shapes.Rectangle)uiElm, canvas, leftHand, rightHand))
                        {
                            frameCount++;
                            handIsOverAtleastOneRectangle = true;
                            Console.WriteLine("Frame:" + frameCount);
                            if (frameCount >= TIMER * FRAME_PER_SEC)
                            {
                                selectSetting(((System.Windows.Shapes.Rectangle)uiElm).Name);
                                frameCount = 0;
                                break;
                            }
                        }
                    }
                }
                if (!handIsOverAtleastOneRectangle) frameCount = 0;
            //}
        }

        public virtual void processSkeletonFramePage8(Skeleton skeleton, Canvas canvas, Page8 page)
        {
            Joint leftHand = skeleton.Joints[JointType.HandLeft].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointType.HandRight].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint spine = skeleton.Joints[JointType.Spine].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint neck = skeleton.Joints[JointType.ShoulderCenter].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);

         
            // if (clutchIsEngaged(leftHand, rightHand, spine))
            //{
            /*foreach (object uiElm in canvas.Children)
            {
                if (uiElm is Border)
                {
                    if (eitherHandIsOverBorder((Border)uiElm, canvas, leftHand, rightHand))
                    {
                        selectSetting(((System.Windows.Controls.Image)((Border)uiElm).Child).Name);
                        break;
                    }
                }
            }*/
            //}
        }

        public virtual void processSkeletonFramePage5(Skeleton skeleton, Canvas canvas, Page5 page)
        {
            Joint leftHand = skeleton.Joints[JointType.HandLeft].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointType.HandRight].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);

            //   System.Drawing.Graphics g;// = new Graphics();
            /*Example implementation*/

            foreach (object uiElm in canvas.Children)
            {
                if (uiElm is System.Windows.Shapes.Rectangle)
                {
                    if (eitherHandIsOverRectangle((System.Windows.Shapes.Rectangle)uiElm, canvas, leftHand, rightHand))
                    {
                        if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "Start") == 0)
                        {
                            frameCount++;
                            if (frameCount >= TIMER * FRAME_PER_SEC)
                            {
                                Frame recordAScene = new Frame();
                                recordAScene.Source = new Uri("Page7.xaml", UriKind.Relative);
                                recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                Application.Current.MainWindow.Content = recordAScene;
                                frameCount = 0;
                                break;
                            }
                        }
                        else
                        {
                            frameCount = 0;
                        }
                    }
                }
            }
        }

        public virtual void processSkeletonFramePage6(Skeleton skeleton, Canvas canvas, Page6 page)
        {
            Joint leftHand = skeleton.Joints[JointType.HandLeft].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointType.HandRight].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);

            //   System.Drawing.Graphics g;// = new Graphics();
            /*Example implementation*/

            foreach (object uiElm in canvas.Children)
            {
                if (uiElm is System.Windows.Shapes.Rectangle)
                {
                    if (eitherHandIsOverRectangle((System.Windows.Shapes.Rectangle)uiElm, canvas, leftHand, rightHand))
                    {
                        if (String.Compare(((System.Windows.Shapes.Shape)uiElm).Name, "MainMenu") == 0)
                        {
                            frameCount++;
                            if (frameCount >= TIMER * FRAME_PER_SEC)
                            {
                                Frame recordAScene = new Frame();
                                recordAScene.Source = new Uri("WpfApplication2;component/Page5.xaml", UriKind.Relative);
                                recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                Application.Current.MainWindow.Content = recordAScene;
                                del.createANewStory();
                                frameCount = 0;
                                break;
                            }
                        }
                        else
                        {
                            frameCount = 0;
                        }
                    }
                }
            }
        }

        public virtual void processSkeletonFramePage7(Skeleton skeleton, Canvas canvas, Page7 page)
        {
            Joint leftHand = skeleton.Joints[JointType.HandLeft].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointType.HandRight].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);

            //   System.Drawing.Graphics g;// = new Graphics();
            /*Example implementation*/

            foreach (object uiElm in canvas.Children)
            {
                if (uiElm is System.Windows.Shapes.Rectangle)
                {
                    if (eitherHandIsOverRectangle((System.Windows.Shapes.Rectangle)uiElm, canvas, leftHand, rightHand))
                    {
                        if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "Yes") == 0)
                        {
                            frameCount++;
                            if (frameCount >= TIMER * FRAME_PER_SEC)
                            {
                                del.setAssistanceMode(true);
                                Frame recordAScene = new Frame();
                                recordAScene.Source = new Uri("WpfApplication2;component/Page9.xaml", UriKind.Relative);
                                recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                Application.Current.MainWindow.Content = recordAScene;
                                frameCount = 0;
                                break;
                            }
                        }
                        else if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "No") == 0)
                        {
                            frameCount++;
                            if (frameCount >= TIMER * FRAME_PER_SEC)
                            {
                                del.setAssistanceMode(false);
                                Frame recordAScene = new Frame();
                                recordAScene.Source = new Uri("WpfApplication2;component/Page1.xaml", UriKind.Relative);
                                recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                Application.Current.MainWindow.Content = recordAScene;
                                frameCount = 0;
                                break;
                            }
                        }
                        else
                        {
                            frameCount = 0;
                        }
                    }
                }
            }
        }


        public virtual void processSkeletonFramePage9(Skeleton skeleton, Canvas canvas, Page9 page)
        {
            Joint leftHand = skeleton.Joints[JointType.HandLeft].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointType.HandRight].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);

            //   System.Drawing.Graphics g;// = new Graphics();
            /*Example implementation*/

            foreach (object uiElm in canvas.Children)
            {
                if (uiElm is System.Windows.Shapes.Rectangle)
                {
                    if (eitherHandIsOverRectangle((System.Windows.Shapes.Rectangle)uiElm, canvas, leftHand, rightHand))
                    {
                        if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "Continue") == 0)
                        {
                            frameCount++;
                            if (frameCount >= 1)
                            {
                                Frame recordAScene = new Frame();
                                recordAScene.Source = new Uri("WpfApplication2;component/Page1.xaml", UriKind.Relative);
                                recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                Application.Current.MainWindow.Content = recordAScene;
                                frameCount = 0;
                                break;
                            }
                        }
                        else
                        {
                            frameCount = 0;
                        }
                    }
                }
            }
        }

        private bool bothHandsAreOverBorder(Border img, Canvas c, Joint lh, Joint rh)
        {
            return handIsOverBorder(img, c, lh) && handIsOverBorder(img, c, rh);
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

        private void setCharacterPosition()
        {
            String indexStr = characterToReposition.Name;
            int i = indexStr.IndexOf("character") -1;
            indexStr = indexStr.Substring(1, i);

            int index = Convert.ToInt32(indexStr);
            del.setCharacterPosition(index, Canvas.GetLeft(characterToReposition), Canvas.GetTop(characterToReposition));
        }

        private void moveCharacter(Joint hand)
        {
            Canvas.SetLeft(characterToReposition, hand.Position.X - characterToReposition.ActualWidth / 2);
            Canvas.SetTop(characterToReposition, hand.Position.Y - characterToReposition.ActualHeight / 2);

            setCharacterPosition();
        }

        public virtual void processSkeletonFramePage2(Skeleton skeleton, Canvas canvas, Page2 page, Canvas basCanvas)
        {
            Joint leftHand = skeleton.Joints[JointType.HandLeft].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointType.HandRight].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            bool shouldExitForLoop = false;

            if (userIsSelectingCharacter)
            {
                //User is moving the character
                Console.WriteLine("Z-value-diff: " + Math.Abs(rightHand.Position.Z - lastZPosition));
                Console.WriteLine("Selected Char Name: " + selectedCharacterName);
                if (usingRightHand && rightHand.Position.Z - lastZPosition <= -Z_SELECTION_THRESHOLD)
                {
                    moveCharacter(rightHand);
                }
                else if (!usingRightHand && leftHand.Position.Z - lastZPosition <= -Z_SELECTION_THRESHOLD)
                {
                    moveCharacter(leftHand);
                }
                else if (!eitherHandIsOverImage(characterToReposition, canvas, leftHand, rightHand))
                {
                    userIsSelectingCharacter = false;
                    lastZPosition = 0;
                }
            }
            else
            {
                foreach (object uiElm in canvas.Children)
                {
                  
                    if (uiElm is System.Windows.Shapes.Rectangle)
                    {
                        if (eitherHandIsOverRectangle((System.Windows.Shapes.Rectangle)uiElm, canvas, leftHand, rightHand))
                        {
                            if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "backbutton") == 0)
                            {
                                frameCount++;
                                if (frameCount >= TIMER * FRAME_PER_SEC)
                                {
                                    del.removeCurrentScene();
                                    Frame recordAScene = new Frame();
                                    recordAScene.Source = new Uri("WpfApplication2;component/Page1.xaml", UriKind.Relative);
                                    recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                    Application.Current.MainWindow.Content = recordAScene;
                                    frameCount = 0;
                                    break;
                                }
                            }
                            else if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "record") == 0)
                            {
                                frameCount++;
                                if (frameCount >= TIMER * FRAME_PER_SEC)
                                {
                                    foreach (object obj in canvas.Children)
                                    {
                                        if (obj is Label && String.Compare(((Label)obj).Name, "mode") == 0)
                                        {
                                            ((Label)obj).Content = "Record";
                                            shouldExitForLoop = true;
                                            frameCount = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "pause") == 0)
                            {
                                frameCount++;
                                if (frameCount >= TIMER * FRAME_PER_SEC)
                                {
                                    foreach (object obj in canvas.Children)
                                    {
                                        if (obj is Label && String.Compare(((Label)obj).Name, "mode") == 0)
                                        {
                                            ((Label)obj).Content = "Paused";
                                            shouldExitForLoop = true;
                                            frameCount = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "forwardButton") == 0)
                            {
                                frameCount++;
                                if (frameCount >= TIMER * FRAME_PER_SEC)
                                {
                                    frameCount = 0;
                                    if (del.getCurrentScene() == 2)
                                    {
                                        //done page
                                        //reset everything 
                                        Frame recordAScene = new Frame();
                                        recordAScene.Source = new Uri("Page6.xaml", UriKind.Relative);
                                        recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                        Application.Current.MainWindow.Content = recordAScene;
                                        break;
                                    }
                                    else
                                    {
                                        Frame recordAScene = new Frame();
                                        if(del.getAssitanceMode() == true)
                                            recordAScene.Source = new Uri("WpfApplication2;component/Page9.xaml", UriKind.Relative);
                                        else
                                            recordAScene.Source = new Uri("WpfApplication2;component/Page1.xaml", UriKind.Relative);
                                        recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                        Application.Current.MainWindow.Content = recordAScene;
                                        break;
                                    }
                                }
                            }
                            else if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "toyBox") == 0)
                            {
                                frameCount++;
                                if (frameCount >= TIMER * FRAME_PER_SEC)
                                {
                                    Frame recordAScene = new Frame();
                                    recordAScene.Source = new Uri("Page3.xaml", UriKind.Relative);
                                    recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                    Application.Current.MainWindow.Content = recordAScene;
                                    frameCount = 0;
                                }
                            }
                            else if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "switchMode") == 0)
                            {
                                frameCount++;
                                if (frameCount >+ TIMER * FRAME_PER_SEC)
                                {
                                    frameCount = 0;
                                    lastFrame = (Frame)Application.Current.MainWindow.Content;
                                    Frame recordAScene = new Frame();
                                    recordAScene.Source = new Uri("Page4.xaml", UriKind.Relative);
                                    recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                    Application.Current.MainWindow.Content = recordAScene;
                                    del.setSelectedCharacter(selectedCharacterName);
                                }
                            }

                            else if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "Delete") == 0)
                            {
                                frameCount++;
                                if (frameCount >= TIMER * FRAME_PER_SEC)
                                {
                                    frameCount = 0;
                                    if (characterToReposition != null)
                                    {
                                        String indexStr = characterToReposition.Name;
                                        int i = indexStr.IndexOf("character") -1;
                                        indexStr = indexStr.Substring(1, i);
                                        int index = Convert.ToInt32(indexStr);
                                        
                                        basCanvas.Children.Remove(characterToReposition);
                                        del.setSelectedCharacter("");
                                        del.removeCharacter(index);
                                        characterToReposition = null;
                                    }
                                }
                                // Frame recordAScene = new Frame();
                                // recordAScene.Source = new Uri("Page3.xaml", UriKind.Relative);
                                //recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                //Application.Current.MainWindow.Content = recordAScene;

                            }
                            else
                            {
                                frameCount = 0;
                            }

                            if (shouldExitForLoop) break;
                        }
                    }
                    else if (uiElm is Canvas)
                    {
                        foreach (object child in ((Canvas)uiElm).Children)
                        {
                            if (child is System.Windows.Controls.Image)
                            {
                                if (handIsOverImage((System.Windows.Controls.Image)child, canvas, rightHand))
                                {
                                    //Console.WriteLine("Right Hand Z" + rightHand.Position.Z);
                                    String imgName = ((System.Windows.Controls.Image)child).Name;
                                    if (imgName.Contains("Meatwad"))
                                    {
                                        characterToReposition = (System.Windows.Controls.Image)child;
                                        selectedCharacterName = "Meatwad";
                                        userIsSelectingCharacter = true;
                                        usingRightHand = true;
                                        lastZPosition = rightHand.Position.Z;
                                    }
                                    else if (imgName.Contains("Optimus"))
                                    {
                                        characterToReposition = (System.Windows.Controls.Image)child;
                                        selectedCharacterName = "OptimusPrime";
                                        userIsSelectingCharacter = true;
                                        Console.WriteLine("Selected Char Name: " + selectedCharacterName);
                                        usingRightHand = true;
                                        lastZPosition = rightHand.Position.Z;
                                    }
                                    else if (imgName.Contains("Sailor"))
                                    {
                                        characterToReposition = (System.Windows.Controls.Image)child;
                                        selectedCharacterName = "SailorMoon";
                                        userIsSelectingCharacter = true;
                                        usingRightHand = true;
                                        lastZPosition = rightHand.Position.Z;
                                    }
                                    
                                    //Console.WriteLine("Last Hand Z" + lastZPosition);
                                }
                                else if (handIsOverImage((System.Windows.Controls.Image)child, canvas, leftHand))
                                {

                                    String imgName = ((System.Windows.Controls.Image)child).Name;
                                    if (imgName.Contains("Meatwad"))
                                    {
                                        characterToReposition = (System.Windows.Controls.Image)child;
                                        selectedCharacterName = "Meatwad";
                                        userIsSelectingCharacter = true;
                                        usingRightHand = false;
                                        lastZPosition = leftHand.Position.Z;
                                    }
                                    else if (imgName.Contains("Optimus"))
                                    {
                                        characterToReposition = (System.Windows.Controls.Image)child;
                                        selectedCharacterName = "OptimusPrime";
                                        userIsSelectingCharacter = true;
                                        Console.WriteLine("Selected Char Name: " + selectedCharacterName);
                                        usingRightHand = false;
                                        lastZPosition = leftHand.Position.Z;
                                    }
                                    else if (imgName.Contains("Sailor"))
                                    {
                                        characterToReposition = (System.Windows.Controls.Image)child;
                                        selectedCharacterName = "SailorMoon";
                                        userIsSelectingCharacter = true;
                                        usingRightHand = false;
                                        lastZPosition = leftHand.Position.Z;
                                    }
                                    
                                }
                                /*else
                                {
                                    userIsSelectingCharacter = false;
                                    lastZPosition = 0;
                                }*/

                            }
                        }
                    }
                }
            }
        }


        private bool eitherHandIsOverImage(System.Windows.Controls.Image img, Canvas c, Joint lh, Joint rh)
        {
            return handIsOverImage(img, c, lh) || handIsOverImage(img, c, rh);
        }

        private bool handIsOverImage(System.Windows.Controls.Image img, Canvas c, Joint h)
        {
            return h.Position.Y > Canvas.GetTop(img) && h.Position.Y < Canvas.GetTop(img) + img.ActualHeight &&
                 h.Position.X > Canvas.GetLeft(img) && h.Position.X < Canvas.GetLeft(img) + img.ActualWidth;
        }

        private bool bothHandsAreOverRectangle(System.Windows.Shapes.Rectangle img, Canvas c, Joint lh, Joint rh)
        {
            return handIsOverRectangle(img, c, lh) && handIsOverRectangle(img, c, rh);
        }

        private bool eitherHandIsOverRectangle(System.Windows.Shapes.Rectangle img, Canvas c, Joint lh, Joint rh)
        {
            return handIsOverRectangle(img, c, lh) || handIsOverRectangle(img, c, rh);
        }

        private bool handIsOverRectangle(System.Windows.Shapes.Rectangle img, Canvas c, Joint h)
        {
            return h.Position.Y > Canvas.GetTop(img) && h.Position.Y < Canvas.GetTop(img) + img.ActualHeight &&
                 h.Position.X > Canvas.GetLeft(img) && h.Position.X < Canvas.GetLeft(img) + img.ActualWidth;
        }

        private bool eitherHandIsOverShape(System.Windows.Shapes.Shape img, Canvas c, Joint lh, Joint rh)
        {
            return handIsOverShape(img, c, lh) || handIsOverShape(img, c, rh);
        }

        private bool handIsOverShape(System.Windows.Shapes.Shape img, Canvas c, Joint h)
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


        internal void processSkeletonFramePage3(Skeleton skeleton, Canvas canvas, Page3 page)
        {
            Joint leftHand = skeleton.Joints[JointType.HandLeft].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);
            Joint rightHand = skeleton.Joints[JointType.HandRight].ScaleTo(1366, 768, window.k_xMaxJointScale, window.k_yMaxJointScale);

            foreach (object uiElm in canvas.Children)
            {
                if (uiElm is System.Windows.Shapes.Rectangle)
                {
                    if (eitherHandIsOverRectangle((System.Windows.Shapes.Rectangle)uiElm, canvas, leftHand, rightHand))
                    {
                        frameCount++;
                        System.Windows.Shapes.Rectangle selected = (System.Windows.Shapes.Rectangle)uiElm;
                        if (String.Compare(selected.Name, "Meatwad1") == 0)
                        {
                            if (frameCount >= 30)//TIMER * FRAME_PER_SEC)
                            {
                                String path = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\Meatwad_Images\\Meatwad.gif";
                                newCharacterToAdd = "Meatwad";
                                page.curCharact.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
                                frameCount = 0;
                            }

                        }
                        else if (String.Compare(selected.Name, "Optimus1") == 0)
                        {
                            if (frameCount >= 30)//TIMER * FRAME_PER_SEC)
                            {
                                String path = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\Optimusg1_Images\\Optimusg1.png";
                                newCharacterToAdd = "OptimusPrime";
                                page.curCharact.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
                                frameCount = 0;
                            }
                        }
                        else if (String.Compare(selected.Name, "SailorMoon1") == 0)
                        {
                            if (frameCount >= 30)//TIMER * FRAME_PER_SEC)
                            {
                                String path = "c:\\users\\tajah\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\SMoon_Images\\SMoon.png";
                                newCharacterToAdd = "SailorMoon";
                                page.curCharact.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
                                frameCount = 0;
                            }
                        }
                        else if (String.Compare(selected.Name, "Done1") == 0)
                        {
                            Console.WriteLine("Done selected");
                            Console.WriteLine("Frame Count: " + frameCount);
                            if (frameCount >= 30)//TIMER * FRAME_PER_SEC)
                            {
                                Character c = new Character(CharacterList.getCharacter(newCharacterToAdd));
                                if (newCharacterToAdd != null) del.addCharacterToScene(c);
                                newCharacterToAdd = null;
                                Frame recordAScene = new Frame();
                                recordAScene.Source = new Uri("Page2.xaml", UriKind.Relative);
                                recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                                Application.Current.MainWindow.Content = recordAScene;
                                frameCount = 0;
                            }
                        }
                        /*else
                        {
                            frameCount = 0;
                        }*/
                    }
                }
            }
        }

        private double calculateDistance(System.Windows.Point a, System.Windows.Point b)
        {
            return Math.Sqrt((((b.X - a.X) * (b.X - a.X)) + ((b.Y - a.Y) * (b.Y - a.Y))));
        }
        /*
        private double applyRotation(Joint oldJointA, Joint oldJointB, Joint newJointA, Joint newJointB, System.Windows.Controls.Image img)
        {
            System.Windows.Point a = new System.Windows.Point(oldJointA.Position.X, oldJointA.Position.Y);
            System.Windows.Point b = new System.Windows.Point(oldJointB.Position.X, oldJointB.Position.Y);
            double adjacent = calculateDistance(a, b);

            a.X = newJointA.Position.X;
            a.Y = newJointA.Position.Y;
            b.X = newJointB.Position.X;
            b.Y = newJointB.Position.Y;
            double hypotnuse = calculateDistance(a, b);

            return Math.Acos(adjacent / hypotnuse) * Math.PI / 180.0;
            Bitmap b = new Bitmap(img);
            rotateImage(b,angle, img);
        }

        private void rotateImage(Bitmap b, double angle, System.Windows.Controls.Image img)
        {
           //create a new empty bitmap to hold rotated image
           Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
           //make a graphics object from the empty bitmap
           Graphics g = Graphics.FromImage(returnBitmap);
           //move rotation point to center of image
           g.TranslateTransform((float)b.Width/2, (float)b.Height / 2);
           //rotate
           g.RotateTransform((float)angle);
           //move image back
           g.TranslateTransform(-(float)b.Width/2,-(float)b.Height / 2);
           //draw passed in image onto graphics object
           g.DrawImage(b, new System.Drawing.Point(0, 0));

           string path = "C:\\Users\\Dalila\\Downloads\\AndTheyLoveIt-CS194W-ed1a05c\\AndTheyLoveIt-CS194W-ed1a05c\\WpfApplication2\\imageRot.png";

           b.Save(path, System.Drawing.Imaging.ImageFormat.Png);
           img.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
        }*/

        private void setBodyPosition(Joint bp, System.Windows.Controls.Image bodyPart, double y_offset, double x_offset, bool setTop)
        {
            if (setTop) Canvas.SetTop(bodyPart, bp.Position.Y + y_offset);
            else Canvas.SetBottom(bodyPart, bp.Position.Y + y_offset);
            Canvas.SetLeft(bodyPart, (bp.Position.X - bodyPart.ActualWidth / 2) + x_offset);
        }

        internal void processSkeletonFramePage4(Skeleton skeleton, Canvas canvas, Page4 page4, List<System.Windows.Controls.Image> parts)
        {
            float x_page4Scale = 1f;
            float y_page4Scale = 1f;

            Joint leftHand = skeleton.Joints[JointType.HandLeft].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint leftElbow = skeleton.Joints[JointType.ElbowLeft].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint leftShoulder = skeleton.Joints[JointType.ShoulderLeft].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint leftHip = skeleton.Joints[JointType.HipLeft].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint leftKnee = skeleton.Joints[JointType.KneeLeft].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint leftFoot = skeleton.Joints[JointType.FootLeft].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);

            Joint head = skeleton.Joints[JointType.Head].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint neck = skeleton.Joints[JointType.ShoulderCenter].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint spine = skeleton.Joints[JointType.Spine].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint centerHip = skeleton.Joints[JointType.HipCenter].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);

            Joint rightHand = skeleton.Joints[JointType.HandRight].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint rightElbow = skeleton.Joints[JointType.ElbowRight].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint rightShoulder = skeleton.Joints[JointType.ShoulderRight].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint rightHip = skeleton.Joints[JointType.HipRight].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint rightKnee = skeleton.Joints[JointType.KneeRight].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);
            Joint rightFoot = skeleton.Joints[JointType.FootRight].ScaleTo(1366, 768, x_page4Scale, y_page4Scale);

            foreach (object uiElm in canvas.Children)
            {

                if (uiElm is System.Windows.Shapes.Rectangle)
                {
                    if (eitherHandIsOverRectangle((System.Windows.Shapes.Rectangle)uiElm, canvas, leftHand, rightHand))
                    {
                        //if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "backbutton") == 0)
                        //{

                            Frame recordAScene = new Frame();
                            recordAScene.Source = new Uri("Page2.xaml", UriKind.Relative);
                            recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                            Application.Current.MainWindow.Content = recordAScene;
                            // Application.Current.MainWindow.Content = lastFrame;
                            break;
                        //}

                        /*else if (String.Compare(((System.Windows.Shapes.Rectangle)uiElm).Name, "forwardButton") == 0)
                        {
                            /*  Frame recordAScene = new Frame();
                              recordAScene.Source = new Uri("WpfApplication2;component/Page1.xaml", UriKind.Relative);
                              recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                           
                            //  Application.Current.MainWindow.Content = lastFrame;
                            //  break;
                            Frame recordAScene = new Frame();
                            recordAScene.Source = new Uri("Page2.xaml", UriKind.Relative);
                            recordAScene.NavigationService.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(MainWindow.NavigationService_LoadCompleted);
                            Application.Current.MainWindow.Content = recordAScene;
                            break;
                        }*/

                    }
                }
            }

            // Create pen.
            //System.Drawing.Pen blackPen = new System.Drawing.Pen(System.Drawing.Color.Black, 3);

            // Create points that define line.
            //  System.Drawing.Point point1 = new System.Drawing.Point(100, 100);
            // System.Drawing.Point point2 = new System.Drawing.Point(500, 100);

            // Draw line to screen.
            //Graphics.DrawLine(blackPen, point1, point2);

            if (previousJoints != null)
            {
                Character c = CharacterList.getCharacter(del.getSelectedCharacter());

                foreach (object uiElm in canvas.Children)
                {
                    if (uiElm is System.Windows.Controls.Image)
                    {
                        int partID = -1;
                        string partName = ((System.Windows.Controls.Image)uiElm).Name;
                        System.Windows.Controls.Image bodyPart = (System.Windows.Controls.Image)uiElm;
                        for (int i = 0; i < 22; i++)
                        {
                            if (partName.Contains(i.ToString())) partID = i;
                        }

                        //Switch cases depending on partID
                        switch (partID)
                        {
                            case 0:
                                setBodyPosition(head, bodyPart, c.getOffsetY(0), c.getOffsetX(0), true);
                                break;
                            case 5:
                                //Canvas.SetTop(bodyPart, spine.Position.Y - bodyPart.ActualHeight / 2);
                                //Canvas.SetLeft(bodyPart, spine.Position.X - bodyPart.ActualWidth / 2);
                                setBodyPosition(spine, bodyPart, c.getOffsetY(5), c.getOffsetX(5), true);
                                //Canvas.setl
                                break;
                            case 3:
                                setBodyPosition(rightKnee, bodyPart, c.getOffsetY(3), c.getOffsetX(3), true);
                                break;
                            case 7:
                                setBodyPosition(rightElbow, bodyPart, c.getOffsetY(7), c.getOffsetX(7), true);
                                //   applyRotation(previousJoints[11], previousJoints[10], rightElbow, rightHand, bodyPart, 7, canvas);
                                break;
                            case 15:
                                setBodyPosition(rightShoulder, bodyPart, c.getOffsetY(15), c.getOffsetX(15), true);
                                // applyRotation(previousJoints[12], previousJoints[11], rightShoulder, rightElbow, bodyPart, 15, canvas);
                                break;
                            case 1:
                                setBodyPosition(rightHip, bodyPart, c.getOffsetY(1), c.getOffsetX(1), true);
                                break;
                            case 4:
                                setBodyPosition(leftKnee, bodyPart, c.getOffsetY(4), c.getOffsetX(4), true);
                                break;
                            case 8:
                                setBodyPosition(leftElbow, bodyPart, c.getOffsetY(8), c.getOffsetX(8), true);
                                break;
                            case 16:
                                setBodyPosition(leftShoulder, bodyPart, c.getOffsetY(16), c.getOffsetX(16), true);
                                break;
                            case 2:
                                setBodyPosition(leftHip, bodyPart, c.getOffsetY(2), c.getOffsetX(2), true);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            previousJoints = new List<Joint>();
            previousJoints.Add(leftHand);
            previousJoints.Add(leftElbow);
            previousJoints.Add(leftShoulder);
            previousJoints.Add(leftHip);
            previousJoints.Add(leftKnee);
            previousJoints.Add(leftFoot);
            previousJoints.Add(head);
            previousJoints.Add(neck);
            previousJoints.Add(spine);
            previousJoints.Add(centerHip);
            previousJoints.Add(rightHand);
            previousJoints.Add(rightElbow);
            previousJoints.Add(rightShoulder);
            previousJoints.Add(rightHip);
            previousJoints.Add(rightKnee);
            previousJoints.Add(rightFoot);

                }
    }
}
