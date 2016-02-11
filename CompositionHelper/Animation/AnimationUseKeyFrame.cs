using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 表示使用关键帧的动画。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ContentProperty(Name = "KeyFrames")]
    public abstract class AnimationUseKeyFrame<T> : Animation
    {
        public AnimationUseKeyFrame()
        {
            KeyFrames = new KeyFrameCollection<T>();
        }

        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
            "Duration", typeof(TimeSpan), typeof(Animation), new PropertyMetadata(TimeSpan.FromMilliseconds(250)));

        /// <summary>
        /// 表示动画的时长。
        /// </summary>
        public TimeSpan Duration
        {
            get { return (TimeSpan)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly DependencyProperty DelayTimeProperty = DependencyProperty.Register(
            "DelayTime", typeof(TimeSpan), typeof(Animation), new PropertyMetadata(default(TimeSpan)));

        /// <summary>
        /// 表示动画的延时。
        /// </summary>
        public TimeSpan DelayTime
        {
            get { return (TimeSpan)GetValue(DelayTimeProperty); }
            set { SetValue(DelayTimeProperty, value); }
        }

        public static readonly DependencyProperty IterationBehaviorProperty = DependencyProperty.Register(
            "IterationBehavior", typeof(AnimationIterationBehavior), typeof(Animation), new PropertyMetadata(AnimationIterationBehavior.Count));

        /// <summary>
        /// 表示动画重复行为。
        /// </summary>
        public AnimationIterationBehavior IterationBehavior
        {
            get { return (AnimationIterationBehavior)GetValue(IterationBehaviorProperty); }
            set { SetValue(IterationBehaviorProperty, value); }
        }

        public static readonly DependencyProperty IterationCountProperty = DependencyProperty.Register(
            "IterationCount", typeof(int), typeof(Animation), new PropertyMetadata(1));

        /// <summary>
        /// 表示动画的重复次数。
        /// </summary>
        public int IterationCount
        {
            get { return (int)GetValue(IterationCountProperty); }
            set { SetValue(IterationCountProperty, value); }
        }

        public static readonly DependencyProperty StopBehaviorProperty = DependencyProperty.Register(
            "StopBehavior", typeof(AnimationStopBehavior), typeof(Animation), new PropertyMetadata(AnimationStopBehavior.LeaveCurrentValue));

        /// <summary>
        /// 表示动画的停止行为。
        /// </summary>
        public AnimationStopBehavior StopBehavior
        {
            get { return (AnimationStopBehavior)GetValue(StopBehaviorProperty); }
            set { SetValue(StopBehaviorProperty, value); }
        }

        public static readonly DependencyProperty KeyFramesProperty = DependencyProperty.Register(
            "KeyFrames", typeof(KeyFrameCollection<T>), typeof(AnimationUseKeyFrame<T>), new PropertyMetadata(default(KeyFrameCollection<T>)));

        /// <summary>
        /// 获取一个集合，表示该动画的关键帧。
        /// </summary>
        public KeyFrameCollection<T> KeyFrames
        {
            get { return (KeyFrameCollection<T>)GetValue(KeyFramesProperty); }
            set { SetValue(KeyFramesProperty, value); }
        }

        public override CompositionAnimation BuildCompositionAnimation()
        {
            if (CompositionAnimation != null) return CompositionAnimation;

            if (TargetElement == null) throw new InvalidOperationException("没有为动画提供目标对象。");
            if (TargetProperty == VisualProperty.None) throw new InvalidOperationException("没有为动画提供目标属性。");

            CompositionAnimation?.Dispose();
            var resultAnimation = CreateCompositionAnimation(TargetVisual.Compositor);
            CompositionAnimation = resultAnimation;

            resultAnimation.DelayTime = DelayTime;
            resultAnimation.Duration = Duration;
            resultAnimation.IterationBehavior = IterationBehavior;
            resultAnimation.IterationCount = IterationCount;
            resultAnimation.StopBehavior = StopBehavior;

            foreach (var parameter in Parameters)
            {
                parameter.AddParameterToAnimation(resultAnimation);
            }

            foreach (var keyFrame in KeyFrames)
            {
                keyFrame.AddKayFrameToAnimation(resultAnimation);
            }

            return CompositionAnimation;
        }

        protected virtual KeyFrameAnimation CreateCompositionAnimation(Compositor compositor)
        {
            throw new NotImplementedException("未提供创建动画方法。");
        }
    }
}