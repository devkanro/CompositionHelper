using System;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class ColorKeyFrameTransitionAnimationFluentContext : KeyFrameTransitionAnimationFluentContext<Color>
    {
        internal ColorKeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] ColorKeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Color> keyFrameContext)
        {
            (CompositionAnimation as ColorKeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }

        protected override void InsertExpressionKeyFrame(ExpressionKeyFrameFluentContext keyFrameContext)
        {
            (CompositionAnimation as KeyFrameAnimation).InsertExpressionKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }
}