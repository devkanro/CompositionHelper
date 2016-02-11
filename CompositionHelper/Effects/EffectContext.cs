using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media.Imaging;

namespace CompositionHelper.Effects
{
    /// <summary>
    /// 特效上下文，为更换特效，特效间交互提供信息。
    /// </summary>
    public class EffectContext
    {

        public static EffectContext CreateEffectContext(UIElement target)
        {
            if (Effect.GetContext(target) != null)
            {
                return Effect.GetContext(target);
            }

            EffectContext result = new EffectContext(target);
            target.SetChildVisual(result.MainContainer = target.GetVisual().Compositor.CreateContainerVisual());
            (target as Control).LayoutUpdated += result.Target_LayoutUpdated;

            Effect.SetContext(target, result);
            return result;
        }

        private async void Target_LayoutUpdated(object sender, object e)
        {
            if (!Updateding)
            {
                RenderTargetBitmap bitmap = new RenderTargetBitmap();
                await bitmap.RenderAsync(Target);
                var pixels = (await bitmap.GetPixelsAsync()).ToArray();
            }
        }
        private bool Updateding { get; set; } = false;
        private UIElement Target { get; }
        private UIElement Parent { get; }

        private EffectContext(UIElement target)
        {
            Target = target;
        }

        /// <summary>
        /// 元素的主容器。
        /// </summary>
        public ContainerVisual MainContainer { get; internal set; }
        /// <summary>
        /// 元素的源，用于承载元素内容。
        /// </summary>
        public SpriteVisual SourceVisual { get; internal set; }
        /// <summary>
        /// 元素阴影特效。
        /// </summary>
        public SpriteVisual ShadowVisual { get; internal set; }
    }
}
