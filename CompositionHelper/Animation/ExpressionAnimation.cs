using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 使用表达式的逐帧呈现的动画。
    /// </summary>
    public class ExpressionAnimation : Animation
    {
        public ExpressionAnimation()
        {
        }

        public static readonly DependencyProperty ExpressionProperty = DependencyProperty.Register(
            "Expression", typeof(String), typeof(ExpressionAnimation), new PropertyMetadata(default(String)));

        /// <summary>
        /// 表示要呈现的帧的值的表达式。
        /// </summary>
        public String Expression
        {
            get { return (String)GetValue(ExpressionProperty); }
            set { SetValue(ExpressionProperty, value); }
        }

        public override CompositionPropertyAnimator BuildCompositionAnimation()
        {
            if (Animator != null) return Animator;

            if (Target == null) throw new InvalidOperationException("没有为动画提供目标对象。");
            if (Property == null) throw new InvalidOperationException("没有为动画提供目标属性。");

            TargetVisual = (ContainerVisual)ElementCompositionPreview.GetContainerVisual(Target);

            CompositionAnimation?.Dispose();
            CompositionAnimation = TargetVisual.Compositor.CreateExpressionAnimation(Expression);



            Animator?.Dispose();
            Animator = TargetVisual.ConnectAnimation(Property, CompositionAnimation);
            return Animator;
        }
    }
}