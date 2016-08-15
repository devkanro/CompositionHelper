using System;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 标量动画关键帧。
    /// </summary>
    public class ScalarKeyFrame : ValueKeyFrame<float>
    {
        public ScalarKeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is ScalarKeyFrameAnimation)
            {
                (animation as ScalarKeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }

        protected override float GetValueObject(string value)
        {
            return value.ToScalar();
        }
    }
}