using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml.Markup;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// ÑÕÉ«¶¯»­¡£
    /// </summary>
    [ContentProperty(Name = "KeyFrames")]
    public class ColorUseKeyFrame : AnimationUseKeyFrame<Color>
    {
        public ColorUseKeyFrame()
        {
        }

        protected override KeyFrameAnimation CreateCompositionAnimation(Compositor compositor)
        {
            return compositor.CreateColorKeyFrameAnimation();
        }
    }
}