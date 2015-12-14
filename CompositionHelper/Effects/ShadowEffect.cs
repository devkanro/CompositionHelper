using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.DirectX;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;

namespace CompositionHelper.Effects
{
    /// <summary>
    /// 为 UI 元素提供阴影特效。
    /// </summary>
    public class ShadowEffect : DependencyObject
    {
        private UIElement Target { get; set; }

        private ContainerVisual MainContainer { get; set; }

        public static readonly DependencyProperty ShadowEffectProperty = DependencyProperty.RegisterAttached(
            "ShadowEffect", typeof (ShadowEffect), typeof (UIElement), new PropertyMetadata(default(ShadowEffect)));

        public static void SetShadowEffect(DependencyObject element, ShadowEffect value)
        {
            var oldValue = GetShadowEffect(element);
            if (oldValue != null)
            {
                oldValue.DeattacheToElement();
                oldValue.Target = null;
                oldValue.MainContainer = null;
            }
            if (value != null)
            {
                value.Target = element as UIElement;
                value.AttacheToElement();
            }
            element.SetValue(ShadowEffectProperty, value);
        }

        public static ShadowEffect GetShadowEffect(DependencyObject element)
        {
            return (ShadowEffect) element.GetValue(ShadowEffectProperty);
        }

        public static readonly DependencyProperty ShadowColorProperty = DependencyProperty.Register(
            "ShadowColor", typeof (Color), typeof (ShadowEffect), new PropertyMetadata(Colors.Black, (o, args) => {(o as ShadowEffect).RedrawEffect();}));

        public Color ShadowColor
        {
            get { return (Color) GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty BlurAmountProperty = DependencyProperty.Register(
            "BlurAmount", typeof (Double), typeof (ShadowEffect), new PropertyMetadata(2.0, (o, args) => { (o as ShadowEffect).RedrawEffect(); }));

        public Double BlurAmount
        {
            get { return (Double) GetValue(BlurAmountProperty); }
            set { SetValue(BlurAmountProperty, value); }
        }
        
        public static readonly DependencyProperty DepthProperty = DependencyProperty.Register(
            "Depth", typeof(Double), typeof(ShadowEffect), new PropertyMetadata(2.0, (o, args) => { (o as ShadowEffect).RedrawEffect(); }));

        public Double Depth
        {
            get { return (Double)GetValue(DepthProperty); }
            set { SetValue(DepthProperty, value); }
        }

        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register(
            "Direction", typeof (Double), typeof (ShadowEffect), new PropertyMetadata(270.0, (o, args) => { (o as ShadowEffect).RedrawEffect(); }));

        public Double Direction
        {
            get { return (Double) GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        private void AttacheToElement()
        {
            (Target as FrameworkElement).LayoutUpdated += Element_LayoutUpdated;
            DrawEffect();
        }

        private void DeattacheToElement()
        {
            (Target as FrameworkElement).LayoutUpdated -= Element_LayoutUpdated;
            RemoveEffect();
        }

        private void Element_LayoutUpdated(object sender, object e)
        {
            RedrawEffect();
        }

        public void RedrawEffect()
        {
            DrawEffect();
        }

        public void RemoveEffect()
        {
            MainContainer?.Children?.RemoveAll();
        }
        
        public async void DrawEffect()
        {
            if (Target == null)
            {
                return;
            }

            if (MainContainer != null)
            {
                foreach (var child in MainContainer.Children)
                {
                    if (child is SpriteVisual)
                    {
                        (child as SpriteVisual).Brush.Dispose();
                    }
                }
                RemoveEffect();
            }

            RenderTargetBitmap bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(Target);
            var pixels  = (await bitmap.GetPixelsAsync()).ToArray();
            
            Size srcSize = new Size(bitmap.PixelWidth, bitmap.PixelHeight);
            Size decSize = new Size((int)BlurAmount * 10 + bitmap.PixelWidth, (int)BlurAmount * 10 + bitmap.PixelHeight);
            Size blurSize = new Size(decSize.Width - srcSize.Width, decSize.Height - srcSize.Height);
            Point transform = new Point(blurSize.Width/2, blurSize.Height/2);
            transform.X += Math.Cos(Direction / 360 * 2 * Math.PI) * Depth;
            transform.Y += Math.Sin(Direction / 360 * 2 * Math.PI) * Depth;
            
            ContainerVisual visual = Target.GetVisual() as ContainerVisual;

            Compositor compositor = visual.Compositor;

            CanvasDevice device = CanvasDevice.GetSharedDevice();
            CanvasRenderTarget offscreen = new CanvasRenderTarget(device, (int)decSize.Width, (int)decSize.Height, 96);

            using (CanvasDrawingSession ds = offscreen.CreateDrawingSession())
            {
                Transform2DEffect finalEffect = new Transform2DEffect()
                {
                    Source = new Microsoft.Graphics.Canvas.Effects.ShadowEffect()
                    {
                        Source = CanvasBitmap.CreateFromBytes(ds, pixels, (int)srcSize.Width, (int)srcSize.Height,
                                DirectXPixelFormat.B8G8R8A8UIntNormalized),
                        BlurAmount = (float)BlurAmount,
                        ShadowColor = ShadowColor
                    },
                    TransformMatrix = Matrix3x2.CreateTranslation((float)blurSize.Width / 2, (float)blurSize.Height / 2)
                };


                ds.DrawImage(finalEffect);
            }

            var effectPixels = offscreen.GetPixelBytes();

            var imageFactory =
                Microsoft.UI.Composition.Toolkit.CompositionImageFactory.CreateCompositionImageFactory(compositor);

            var effectImage = imageFactory.CreateImageFromPixels(effectPixels, (int)decSize.Width, (int)decSize.Height);
            var effectbrush = compositor.CreateSurfaceBrush(effectImage.Surface);
            var effectVisual = compositor.CreateSpriteVisual();

            effectVisual.Brush = effectbrush;
            effectVisual.Offset = new Vector3( -(float)transform.X, -(float)transform.Y, 0);
            effectVisual.Size = new Vector2((float)decSize.Width, (float)decSize.Height);

            var srcImage = imageFactory.CreateImageFromPixels(pixels, (int)srcSize.Width, (int)srcSize.Height);
            var srcbrush = compositor.CreateSurfaceBrush(srcImage.Surface);
            var srcVisual = compositor.CreateSpriteVisual();

            srcVisual.Brush = srcbrush;
            srcVisual.Offset = new Vector3(0, 0, 0);
            srcVisual.Size = new Vector2((int)srcSize.Width, (int)srcSize.Height);

            if (MainContainer == null)
            {
                MainContainer = compositor.CreateContainerVisual();
                ElementCompositionPreview.SetElementChildVisual(Target, MainContainer);
            }

            MainContainer.Children.InsertAtTop(srcVisual);
            MainContainer.Children.InsertAtBottom(effectVisual);
        }
    }
}
