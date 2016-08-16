using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 表示动画的基类，所有动画都集成自该类。
    /// </summary>
    public abstract class Animation : DependencyObject
    {
        protected CompositionAnimation CompositionAnimation { get; set; }

        protected Animation()
        {
            Parameters = new ParameterCollection();
        }

        public static readonly DependencyProperty TargetElementProperty = DependencyProperty.Register(
            "TargetElement", typeof(UIElement), typeof(Animation), new PropertyMetadata(default(UIElement)));

        /// <summary>
        /// 表示动画的目标对象。
        /// </summary>
        public UIElement TargetElement
        {
            get { return (UIElement) GetValue(TargetElementProperty); }
            set { SetValue(TargetElementProperty, value); }
        }

        public Visual TargetVisual => ElementCompositionPreview.GetElementVisual(TargetElement);

        public static readonly DependencyProperty TargetPropertyProperty = DependencyProperty.Register(
            "TargetProperty", typeof(VisualProperty), typeof(Animation), new PropertyMetadata(default(VisualProperty)));

        /// <summary>
        /// 表示动画的目标属性。
        /// </summary>
        public VisualProperty TargetProperty
        {
            get { return (VisualProperty)GetValue(TargetPropertyProperty); }
            set { SetValue(TargetPropertyProperty, value); }
        }

        public static readonly DependencyProperty ParametersProperty = DependencyProperty.Register(
            "Parameters", typeof(ParameterCollection), typeof(Animation), new PropertyMetadata(default(ParameterCollection)));

        /// <summary>
        /// 获取一个集合，表示所有表达式所需要的参数。
        /// </summary>
        public ParameterCollection Parameters
        {
            get { return (ParameterCollection)GetValue(ParametersProperty); }
            set { SetValue(ParametersProperty, value); }
        }

        /// <summary>
        /// 创建用于 Composition API 的 CompositionAnimation。
        /// </summary>
        /// <returns></returns>
        public virtual CompositionAnimation BuildCompositionAnimation()
        {
            throw new NotImplementedException("未提供创建 CompositionAnimation 的方法。");
        }

        public virtual void Dispose()
        {
            if (TargetProperty != VisualProperty.None)
            {
                TargetVisual?.StopAnimation(TargetProperty.ToString());
            }
            CompositionAnimation?.Dispose();
            CompositionAnimation = null;
        }
    }
}