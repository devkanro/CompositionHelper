using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 三维矢量动画关键帧。
    /// </summary>
    public class Vector3KeyFrame : ValueKeyFrame<Vector3>
    {
        public Vector3KeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is Vector3KeyFrameAnimation)
            {
                (animation as Vector3KeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }

        protected override Vector3 GetValueObject(string value)
        {
            return value.ToVector3();
        }
    }
}