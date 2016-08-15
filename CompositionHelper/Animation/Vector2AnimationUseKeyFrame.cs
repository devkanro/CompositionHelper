using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml.Markup;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 二维矢量动画。
    /// </summary>
    [ContentProperty(Name = "KeyFrames")]
    public class Vector2AnimationUseKeyFrame : AnimationUseKeyFrame<Vector2>
    {
        public Vector2AnimationUseKeyFrame()
        {
        }

        protected override KeyFrameAnimation CreateCompositionAnimation(Compositor compositor)
        {
            return compositor.CreateVector2KeyFrameAnimation();
        }
    }
}