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

        public TransitionAnimationFluentContext BeginAfter(TimeSpan time)
        {
            (CompositionAnimation as KeyFrameAnimation).DelayTime = time;
            return this;
        }

        public TransitionAnimationFluentContext Spend(TimeSpan time)
        {
            (CompositionAnimation as KeyFrameAnimation).Duration = time;
            return this;
        }

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

        public TransitionAnimationFluentContext RepeatForever()
        {
            (CompositionAnimation as KeyFrameAnimation).IterationBehavior = AnimationIterationBehavior.Forever;
            (CompositionAnimation as KeyFrameAnimation).IterationCount = -1;
            return this;
        }

        public TransitionAnimationFluentContext LeaveCurrentValueWhenStop()
        {
            (CompositionAnimation as KeyFrameAnimation).StopBehavior = AnimationStopBehavior.LeaveCurrentValue;
            return this;
        }

        public TransitionAnimationFluentContext SetToInitialValueWhenStop()
        {
            (CompositionAnimation as KeyFrameAnimation).StopBehavior = AnimationStopBehavior.SetToInitialValue;
            return this;
        }

        public TransitionAnimationFluentContext SetToFinalValueWhenStop()
        {
            (CompositionAnimation as KeyFrameAnimation).StopBehavior = AnimationStopBehavior.SetToFinalValue;
            return this;
        }
    }
}