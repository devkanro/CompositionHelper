using System;
using System.Diagnostics;
using System.Numerics;
using Windows.Foundation;
using CompositionHelper.Animation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using CompositionHelper;
using CompositionHelper.Animation.Fluent;

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
        
        private async void Rectangle_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            await Rectangle.GetVisual().StartBuildAnimation()
                .Animate(AnimateProperties.Offset.Y)
                .ToExpression("this.target.Offset.y + 100")
                .Spend(TimeSpan.FromSeconds(0.5))
                .Over()
                .Start()
                .Wait();
        }
    }
}