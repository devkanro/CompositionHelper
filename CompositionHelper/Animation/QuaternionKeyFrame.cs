using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 四元数动画关键帧。
    /// </summary>
    public class QuaternionKeyFrame : ValueKeyFrame<Quaternion>
    {
        public QuaternionKeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is QuaternionKeyFrameAnimation)
            {
                (animation as QuaternionKeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }

        protected override Quaternion GetValueObject(string value)
        {
            return value.ToQuaternion();
        }
    }
}