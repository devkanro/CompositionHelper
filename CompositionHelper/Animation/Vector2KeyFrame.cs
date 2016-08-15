using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 二维矢量动画关键帧。
    /// </summary>
    public class Vector2KeyFrame : ValueKeyFrame<Vector2>
    {
        public Vector2KeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is Vector2KeyFrameAnimation)
            {
                (animation as Vector2KeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }

        protected override Vector2 GetValueObject(string value)
        {
            return value.ToVector2();
        }
    }
}