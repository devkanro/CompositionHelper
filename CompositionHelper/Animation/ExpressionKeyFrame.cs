using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 表示使用表达式的关键帧。
    /// </summary>
    public class ExpressionKeyFrame : KeyFrame
    {
        /// <summary>
        /// 标示 <see cref="Expression"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ExpressionProperty = DependencyProperty.Register(
            "Expression", typeof(String), typeof(ExpressionKeyFrame), new PropertyMetadata(default(String)));

        /// <summary>
        /// 计算值的表达式。
        /// </summary>
        public String Expression
        {
            get { return (String)GetValue(ExpressionProperty); }
            set { SetValue(ExpressionProperty, value); }
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            animation.InsertExpressionKeyFrame((float)Progress, Expression, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
        }
    }
}