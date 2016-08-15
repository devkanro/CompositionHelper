using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class Vector3KeyFrameTransitionAnimationFluentContext : KeyFrameTransitionAnimationWithKindFluentContext<Vector3>
    {
        internal Vector3KeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] Vector3KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Vector3> keyFrameContext)
        {
            switch (AnimationKind)
            {
                case TransitionAnimationKind.Relative:
                    (CompositionAnimation as KeyFrameAnimation).InsertExpressionKeyFrame(keyFrameContext.Progress, $"this.StartingValue + Vector3({keyFrameContext.Value.X}, {keyFrameContext.Value.Y}, {keyFrameContext.Value.Z})", keyFrameContext.EasingFunction);
                    break;
                case TransitionAnimationKind.Absolute:
                    (CompositionAnimation as Vector3KeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
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