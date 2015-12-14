using System;
using System.Diagnostics;
using System.Numerics;
using CompositionHelper.Animation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CompositionHelper;
using CompositionHelper.Effects;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Sample
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //(this.Resources["Storyboard"] as Storyboard).Start();
            //(this.Resources["Storyboard2"] as Storyboard).Start();
        }

        private void Storyboard_OnCompleted(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now);
        }

        private void Storyboard2_OnCompleted(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now);
        }
    }
}