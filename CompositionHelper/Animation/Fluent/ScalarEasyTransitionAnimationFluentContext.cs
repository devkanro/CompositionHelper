using System;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class ScalarEasyTransitionAnimationFluentContext : EasyTransitionAnimationWithKindFluentContext<float>
    {
        internal ScalarEasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] ScalarKeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<float> keyFrameContext)
        {
            switch (AnimationKind)
            {
                case TransitionAnimationKind.Relative:
                    (CompositionAnimation as KeyFrameAnimation).InsertExpressionKeyFrame(keyFrameContext.Progress, $"this.StartingValue + {keyFrameContext.Value}", keyFrameContext.EasingFunction);
                    break;
                case TransitionAnimationKind.Absolute:
                    (CompositionAnimation as ScalarKeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void InsertExpressionKeyFrame(ExpressionKeyFrameFluentContext keyFrameContext)
        {
            switch (AnimationKind)
            {
                case TransitionAnimationKind.Relative:
                    (CompositionAnimation as KeyFrameAnimation).InsertExpressionKeyFrame(keyFrameContext.Progress, $"this.StartingValue + {keyFrameContext.Value}", keyFrameContext.EasingFunction);
                    break;
                case TransitionAnimationKind.Absolute:
                    (CompositionAnimation as KeyFrameAnimation).InsertExpressionKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}