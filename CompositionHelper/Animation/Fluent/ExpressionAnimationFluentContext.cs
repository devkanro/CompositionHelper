using System;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class ExpressionAnimationFluentContext : AnimationFluentContext
    {
        internal ExpressionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] Windows.UI.Composition.ExpressionAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        public ExpressionAnimationFluentContext SetExpression(String expression)
        {
            (CompositionAnimation as Windows.UI.Composition.ExpressionAnimation).Expression = expression;
            return this;
        }
    }
}