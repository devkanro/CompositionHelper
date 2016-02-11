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
    public class ShadowEffect : Effect
    {
        public static readonly DependencyProperty ShadowColorProperty = DependencyProperty.Register(
            "ShadowColor", typeof(Color), typeof(ShadowEffect), new PropertyMetadata(Colors.Black, (o, args) => { (o as ShadowEffect).RedrawEffect(); }));

        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty BlurAmountProperty = DependencyProperty.Register(
            "BlurAmount", typeof(Double), typeof(ShadowEffect), new PropertyMetadata(2.0, (o, args) => { (o as ShadowEffect).RedrawEffect(); }));

        public Double BlurAmount
        {
            get { return (Double)GetValue(BlurAmountProperty); }
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
            "Direction", typeof(Double), typeof(ShadowEffect), new PropertyMetadata(270.0, (o, args) => { (o as ShadowEffect).RedrawEffect(); }));

        public Double Direction
        {
            get { return (Double)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }



        protected override void AttacheToElement()
        {
            (Target as FrameworkElement).LayoutUpdated += Element_LayoutUpdated;
            BuildEffect();
        }

        protected override void DeattacheToElement()
        {
            (Target as FrameworkElement).LayoutUpdated -= Element_LayoutUpdated;
            RemoveEffect();
        }

        private void Element_LayoutUpdated(object sender, object e)
        {
            RedrawEffect();
        }

        protected override void RedrawEffect()
        {
            BuildEffect();
        }

        protected override void RemoveEffect()
        {
            Context.MainContainer.Children.Remove(Context.ShadowVisual);
            Context.ShadowVisual = null;
        }

        protected override async void BuildEffect()
        {
            if (Target == null)
            {
                return;
            }

            BuildEffect2();

            return;

            if (Context.MainContainer != null)
            {
                foreach (var child in Context.MainContainer.Children)
                {
                    if (child is SpriteVisual)
                    {
                        (child as SpriteVisual).Brush.Dispose();
                    }
                }
                RemoveEffect();
            }

            // Render a UIElement.
            RenderTargetBitmap bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(Target);
            var pixels = (await bitmap.GetPixelsAsync()).ToArray();

            Size srcSize = new Size(bitmap.PixelWidth, bitmap.PixelHeight);
            Size decSize = new Size((int)BlurAmount * 10 + bitmap.PixelWidth, (int)BlurAmount * 10 + bitmap.PixelHeight);
            Size blurSize = new Size(decSize.Width - srcSize.Width, decSize.Height - srcSize.Height);
            Point transform = new Point(blurSize.Width / 2, blurSize.Height / 2);
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
            effectVisual.Offset = new Vector3(-(float)transform.X, -(float)transform.Y, 0);
            effectVisual.Size = new Vector2((float)decSize.Width, (float)decSize.Height);

            var srcImage = imageFactory.CreateImageFromPixels(pixels, (int)srcSize.Width, (int)srcSize.Height);
            var srcbrush = compositor.CreateSurfaceBrush(srcImage.Surface);
            var srcVisual = compositor.CreateSpriteVisual();

            srcVisual.Brush = srcbrush;
            srcVisual.Offset = new Vector3(0, 0, 0);
            srcVisual.Size = new Vector2((int)srcSize.Width, (int)srcSize.Height);

            if (Context.MainContainer == null)
            {
                Context.MainContainer = compositor.CreateContainerVisual();
                ElementCompositionPreview.SetElementChildVisual(Target, Context.MainContainer);
            }

            Context.MainContainer.Children.InsertAtTop(srcVisual);
            Context.MainContainer.Children.InsertAtBottom(effectVisual);
        }


        private FrameworkElement _parentElement;
        private ContainerVisual _mainContainer;
        private SpriteVisual _effectVisual;
        private bool _drawing = false;

        protected async void BuildEffect2()
        {
            if (_drawing)
            {
                return;
            }
            _drawing = true;

            var parent = VisualTreeHelper.GetParent(Target) as FrameworkElement;

            if (parent != _parentElement)
            {
                ClearEffect();
                _parentElement = parent;
            }

            if (parent == null)
            {
                _drawing = false;
                return;
            }

            var point = Target.TransformToVisual(_parentElement).TransformPoint(new Point(0, 0));

            // Render a UIElement.
            RenderTargetBitmap bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(Target);
            var pixels = (await bitmap.GetPixelsAsync()).ToArray();

            Size srcSize = new Size(bitmap.PixelWidth, bitmap.PixelHeight);
            Size decSize = new Size((int)BlurAmount * 10 + bitmap.PixelWidth, (int)BlurAmount * 10 + bitmap.PixelHeight);
            Size blurSize = new Size(decSize.Width - srcSize.Width, decSize.Height - srcSize.Height);

            Point depthTransform = new Point(blurSize.Width / 2, blurSize.Height / 2);
            depthTransform.X += Math.Cos(Direction / 360 * 2 * Math.PI) * Depth;
            depthTransform.Y += Math.Sin(Direction / 360 * 2 * Math.PI) * Depth;

            ContainerVisual visual = _parentElement.GetVisual() as ContainerVisual;
            Compositor compositor = visual.Compositor;


            if (_mainContainer == null)
            {
                _mainContainer = ElementCompositionPreview.GetElementChildVisual(_parentElement) as ContainerVisual;
                if (_mainContainer == null)
                {
                    _mainContainer = compositor.CreateContainerVisual();
                    ElementCompositionPreview.SetElementChildVisual(_parentElement, _mainContainer);
                }
            }

            if ((_effectVisual != null && (!(Math.Abs(_effectVisual.Size.X - (float) decSize.Width) < 0.0000001) ||
                                          !(Math.Abs(_effectVisual.Size.Y - (float) decSize.Height) < 0.0000001))) || _effectVisual == null)
            {
                CanvasDevice device = CanvasDevice.GetSharedDevice();
                CanvasRenderTarget offscreen = new CanvasRenderTarget(device, (int) decSize.Width,
                    (int) decSize.Height, 96);

                using (CanvasDrawingSession ds = offscreen.CreateDrawingSession())
                {
                    Transform2DEffect finalEffect = new Transform2DEffect()
                    {
                        Source = new Microsoft.Graphics.Canvas.Effects.ShadowEffect()
                        {
                            Source =
                                CanvasBitmap.CreateFromBytes(ds, pixels, (int) srcSize.Width, (int) srcSize.Height,
                                    DirectXPixelFormat.B8G8R8A8UIntNormalized),
                            BlurAmount = (float) BlurAmount,
                            ShadowColor = ShadowColor
                        },
                        TransformMatrix =
                            Matrix3x2.CreateTranslation((float) blurSize.Width/2, (float) blurSize.Height/2)
                    };

                    ds.DrawImage(finalEffect);
                }

                var effectPixels = offscreen.GetPixelBytes();

                var imageFactory =
                    Microsoft.UI.Composition.Toolkit.CompositionImageFactory.CreateCompositionImageFactory(
                        compositor);


                var effectImage = imageFactory.CreateImageFromPixels(effectPixels, (int) decSize.Width,
                    (int) decSize.Height);
                var effectbrush = compositor.CreateSurfaceBrush(effectImage.Surface);
                _effectVisual = compositor.CreateSpriteVisual();
                _effectVisual.Brush = effectbrush;

                _effectVisual.Offset = new Vector3((float) (point.X - depthTransform.X),
                    (float) (point.Y - depthTransform.Y), 0);
                _effectVisual.Size = new Vector2((float) decSize.Width, (float) decSize.Height);
                _mainContainer.Children.InsertAtBottom(_effectVisual);
            }
            else
            {
                _effectVisual.Offset = new Vector3((float)(point.X - depthTransform.X),
                    (float)(point.Y - depthTransform.Y), 0);
                _effectVisual.Size = new Vector2((float)decSize.Width, (float)decSize.Height);
            }
            
            _drawing = false;
        }

        void ClearEffect()
        {
            if (_parentElement == null) return;

            if(_mainContainer == null) return;

            if(_effectVisual == null) return;

            _mainContainer.Children.Remove(_effectVisual);
            _mainContainer = null;
            _parentElement = null;
            _effectVisual.Brush?.Dispose();
            _effectVisual.Dispose();
            _effectVisual = null;
        }


    }
}
