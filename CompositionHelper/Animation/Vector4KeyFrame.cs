using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 四维矢量动画关键帧。
    /// </summary>
    public class Vector4KeyFrame : ValueKeyFrame<Vector4>
    {
        public Vector4KeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is Vector4KeyFrameAnimation)
            {
                (animation as Vector4KeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }

        protected override Vector4 GetValueObject(string value)
        {
            return value.ToVector4();
        }
    }
}