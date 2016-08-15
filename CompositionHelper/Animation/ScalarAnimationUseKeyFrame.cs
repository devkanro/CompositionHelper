using Windows.UI.Composition;
using Windows.UI.Xaml.Markup;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 标量动画。
    /// </summary>
    [ContentProperty(Name = "KeyFrames")]
    public class ScalarAnimationUseKeyFrame : AnimationUseKeyFrame<float>
    {
        public ScalarAnimationUseKeyFrame()
        {
        }

        protected override KeyFrameAnimation CreateCompositionAnimation(Compositor compositor)
        {
            return compositor.CreateScalarKeyFrameAnimation();
        }
    }
}