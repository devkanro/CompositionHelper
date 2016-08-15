using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class Vector2EasyTransitionAnimationFluentContext : EasyTransitionAnimationWithKindFluentContext<Vector2>
    {
        internal Vector2EasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] Vector2KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Vector2> keyFrameContext)
        {
            switch (AnimationKind)
            {
                case TransitionAnimationKind.Relative:
                    (CompositionAnimation as KeyFrameAnimation).InsertExpressionKeyFrame(keyFrameContext.Progress, $"this.StartingValue + Vector2({keyFrameContext.Value.X}, {keyFrameContext.Value.Y})", keyFrameContext.EasingFunction);
                    break;
                case TransitionAnimationKind.Absolute:
                    (CompositionAnimation as Vector2KeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
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