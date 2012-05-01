using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        StoryTimeController st;
        public MainWindow()
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //SetupKinect();
            st = new StoryTimeController(this);
        }

        public IStory getDelegate()
        {
            return (IStory)st;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Cleanup
            //nui.Uninitialize();
        }
    }
}