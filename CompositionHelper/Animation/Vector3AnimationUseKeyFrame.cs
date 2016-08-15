using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml.Markup;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 三维矢量动画。
    /// </summary>
    [ContentProperty(Name = "KeyFrames")]
    public class Vector3AnimationUseKeyFrame : AnimationUseKeyFrame<Vector3>
    {
        public Vector3AnimationUseKeyFrame()
        {
        }

        protected override KeyFrameAnimation CreateCompositionAnimation(Compositor compositor)
        {
            return compositor.CreateVector3KeyFrameAnimation();
        }
    }
}