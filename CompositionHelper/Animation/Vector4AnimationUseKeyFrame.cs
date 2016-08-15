using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml.Markup;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 四维矢量动画。
    /// </summary>
    [ContentProperty(Name = "KeyFrames")]
    public class Vector4AnimationUseKeyFrame : AnimationUseKeyFrame<Vector4>
    {
        public Vector4AnimationUseKeyFrame()
        {
        }

        protected override KeyFrameAnimation CreateCompositionAnimation(Compositor compositor)
        {
            return compositor.CreateVector4KeyFrameAnimation();
        }
    }
}