using System;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 表示使用固定值的关键帧。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValueKeyFrame<T> : KeyFrame
    {
        /// <summary>
        /// 标示 <see cref="Value"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(T), typeof(ValueKeyFrame<T>), new PropertyMetadata(default(T)));

        /// <summary>
        /// 表示关键帧的值。
        /// </summary>
        public T Value
        {
            get { return (T)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is ScalarKeyFrameAnimation)
            {
                (animation as ScalarKeyFrameAnimation).InsertKeyFrame((float)Progress, (float)(Object)Value, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else if (animation is Vector2KeyFrameAnimation)
            {
                (animation as Vector2KeyFrameAnimation).InsertKeyFrame((float)Progress, (Vector2)(Object)Value, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else if (animation is Vector3KeyFrameAnimation)
            {
                (animation as Vector3KeyFrameAnimation).InsertKeyFrame((float)Progress, (Vector3)(Object)Value, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else if (animation is Vector4KeyFrameAnimation)
            {
                (animation as Vector4KeyFrameAnimation).InsertKeyFrame((float)Progress, (Vector4)(Object)Value, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }
    }

    public class ScalarKeyFrame : ValueKeyFrame<float>
    {
        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is ScalarKeyFrameAnimation)
            {
                (animation as ScalarKeyFrameAnimation).InsertKeyFrame((float)Progress, (float)(Object)Value, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }
    }

    public class Vector2KeyFrame : ValueKeyFrame<float>
    {
        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is Vector2KeyFrameAnimation)
            {
                (animation as Vector2KeyFrameAnimation).InsertKeyFrame((float)Progress, (Vector2)(Object)Value, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }
    }

    public class Vector3KeyFrame : ValueKeyFrame<float>
    {
        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is Vector3KeyFrameAnimation)
            {
                (animation as Vector3KeyFrameAnimation).InsertKeyFrame((float)Progress, (Vector3)(Object)Value, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }
    }

    public class Vector4KeyFrame : ValueKeyFrame<float>
    {
        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is Vector4KeyFrameAnimation)
            {
                (animation as Vector4KeyFrameAnimation).InsertKeyFrame((float)Progress, (Vector4)(Object)Value, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }
    }
}