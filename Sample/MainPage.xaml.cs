using System.Numerics;
using CompositionHelper.Animation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            var v2 = new Vector2(1, 2);
            var v3 = new Vector3(1, 2, 3);
            var v4 = new Vector4(1, 2, 3, 4);
            var q = new Quaternion(1, 2, 3, 4);
            var m4x4 = new Matrix4x4(11, 12, 13, 14, 21, 22, 23, 24, 31, 32,33, 34, 41, 42, 43, 44);
            (this.Resources["Storyboard"] as Storyboard).Start();
        }
    }
}