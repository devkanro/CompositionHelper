using System;
using System.Numerics;
using Windows.ApplicationModel;
using Windows.UI;
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
        protected ValueKeyFrame()
        {
        }

        /// <summary>
        /// 标示 <see cref="ValueObject"/> 依赖属性。
        /// </summary>
        internal static readonly DependencyProperty ValueObjectProperty = DependencyProperty.Register(
            "ValueObject", typeof(T), typeof(ValueKeyFrame<T>), new PropertyMetadata(default(T)));

        /// <summary>
        /// 表示关键帧的值。
        /// </summary>
        internal T ValueObject
        {
            get { return (T)GetValue(ValueObjectProperty); }
            set { SetValue(ValueObjectProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(String), typeof(ValueKeyFrame<T>), new PropertyMetadata(default(String)));

        public String Value
        {
            get { return (String)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
                if (DesignMode.DesignModeEnabled)
                {
                    try
                    {
                        ValueObject = GetValueObject(value);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    ValueObject = GetValueObject(value);
                }
            }
        }

        protected virtual T GetValueObject(String value)
        {
            throw new NotImplementedException("未提供由字符串转换为值的方法。");
        }

        /// <summary>
        /// 将关键帧加入动画。
        /// </summary>
        /// <param name="animation"></param>
        /// <exception cref="InvalidOperationException">错误的动画类型。</exception>
        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is ScalarKeyFrameAnimation)
            {
                (animation as ScalarKeyFrameAnimation).InsertKeyFrame((float)Progress, (float)(Object)ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else if (animation is Vector2KeyFrameAnimation)
            {
                (animation as Vector2KeyFrameAnimation).InsertKeyFrame((float)Progress, (Vector2)(Object)ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else if (animation is Vector3KeyFrameAnimation)
            {
                (animation as Vector3KeyFrameAnimation).InsertKeyFrame((float)Progress, (Vector3)(Object)ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else if (animation is Vector4KeyFrameAnimation)
            {
                (animation as Vector4KeyFrameAnimation).InsertKeyFrame((float)Progress, (Vector4)(Object)ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else if (animation is ColorKeyFrameAnimation)
            {
                (animation as ColorKeyFrameAnimation).InsertKeyFrame((float)Progress, (Color)(Object)ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("错误的动画类型。");
            }
        }
    }
}