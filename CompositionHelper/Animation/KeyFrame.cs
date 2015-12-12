using CompositionHelper.Annotations;
using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 关键帧的基类。
    /// </summary>
    public abstract class KeyFrame : DependencyObject
    {
        /// <summary>
        /// 标示 <see cref="Progress"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            "Progress", typeof(double), typeof(KeyFrame), new PropertyMetadata(default(double)));

        /// <summary>
        /// 表示该关键帧在动画中的进度。
        /// </summary>
        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        /// <summary>
        /// 标示 <see cref="EasingFunction"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty EasingFunctionProperty = DependencyProperty.Register(
            "EasingFunction", typeof(EasingFunction), typeof(KeyFrame), new PropertyMetadata(new LinearEasingFunction()));

        /// <summary>
        /// 表示从上一个关键帧到该关键帧的过程中的缓动函数。
        /// </summary>
        public EasingFunction EasingFunction
        {
            get { return (EasingFunction)GetValue(EasingFunctionProperty); }
            set { SetValue(EasingFunctionProperty, value); }
        }

        public virtual void AddKayFrameToAnimation([NotNull]KeyFrameAnimation animation)
        {
            throw new NotImplementedException("未提供加入关键帧的方法。");
        }
    }
}