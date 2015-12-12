using System.Numerics;
using Windows.UI;
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

    /// <summary>
    /// 颜色动画。
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

    /// <summary>
    /// 四元数动画。
    /// </summary>
    [ContentProperty(Name = "KeyFrames")]
    public class QuaternionUseKeyFrame : AnimationUseKeyFrame<Quaternion>
    {
        public QuaternionUseKeyFrame()
        {
        }

        protected override KeyFrameAnimation CreateCompositionAnimation(Compositor compositor)
        {
            return compositor.CreateQuaternionKeyFrameAnimation();
        }
    }
}