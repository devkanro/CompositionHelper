using System;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class TransitionAnimationFluentContext : AnimationFluentContext
    {
        internal TransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        /// <summary>
        /// 指定当前动画在故事版开始后的一个延迟时间后执行。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public TransitionAnimationFluentContext BeginAfter(TimeSpan time)
        {
            (CompositionAnimation as KeyFrameAnimation).DelayTime = time;
            return this;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public TransitionAnimationFluentContext Spend(TimeSpan time)
        {
            (CompositionAnimation as KeyFrameAnimation).Duration = time;
            return this;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public TransitionAnimationFluentContext Spend(double millisecond)
        {
            return Spend(TimeSpan.FromMilliseconds(millisecond));
        }

        /// <summary>
        /// 指定动画的重复次数，-1 为无限重复。
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public TransitionAnimationFluentContext Repeat(int times)
        {
            if (times == -1)
            {
                return RepeatForever();
            }
            else
            {
                (CompositionAnimation as KeyFrameAnimation).IterationBehavior = AnimationIterationBehavior.Count;
                (CompositionAnimation as KeyFrameAnimation).IterationCount = times;
                return this;
            }
        }

        /// <summary>
        /// 指定动画为无限重复。
        /// </summary>
        /// <returns></returns>
        public TransitionAnimationFluentContext RepeatForever()
        {
            (CompositionAnimation as KeyFrameAnimation).IterationBehavior = AnimationIterationBehavior.Forever;
            (CompositionAnimation as KeyFrameAnimation).IterationCount = -1;
            return this;
        }

        /// <summary>
        /// 指定动画在结束时保持当前值。
        /// </summary>
        /// <returns></returns>
        public TransitionAnimationFluentContext LeaveCurrentValueWhenStop()
        {
            (CompositionAnimation as KeyFrameAnimation).StopBehavior = AnimationStopBehavior.LeaveCurrentValue;
            return this;
        }

        /// <summary>
        /// 指定动画在结束时设置为初始值。
        /// </summary>
        /// <returns></returns>
        public TransitionAnimationFluentContext SetToInitialValueWhenStop()
        {
            (CompositionAnimation as KeyFrameAnimation).StopBehavior = AnimationStopBehavior.SetToInitialValue;
            return this;
        }

        /// <summary>
        /// 指定动画在结束时设置为结束值。
        /// </summary>
        /// <returns></returns>
        public TransitionAnimationFluentContext SetToFinalValueWhenStop()
        {
            (CompositionAnimation as KeyFrameAnimation).StopBehavior = AnimationStopBehavior.SetToFinalValue;
            return this;
        }
    }
}