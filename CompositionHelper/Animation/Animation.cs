using CompositionHelper.Helper;
using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 表示动画的基类，所有动画都集成自该类。
    /// </summary>
    public abstract class Animation : DependencyObject, IAnimation
    {
        protected CompositionPropertyAnimator Animator;
        protected CompositionAnimation CompositionAnimation;
        protected ContainerVisual TargetVisual;

        protected Animation()
        {
            Parameters = new ParameterCollection();
        }

        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(
            "Target", typeof(UIElement), typeof(Animation), new PropertyMetadata(default(UIElement)));

        /// <summary>
        /// 表示动画的目标对象。
        /// </summary>
        public UIElement Target
        {
            get
            {
                var result = (UIElement)GetValue(TargetProperty);
                if (result == null)
                {
                    Target = result = VisualTreeHelper.FindVisualElementFormName((FrameworkElement)Window.Current.Content, TargetName);
                }
                return result;
            }
            set { SetValue(TargetProperty, value); }
        }

        public static readonly DependencyProperty TargetNameProperty = DependencyProperty.Register(
            "TargetName", typeof(String), typeof(Animation), new PropertyMetadata(default(String)));

        public String TargetName
        {
            get { return (String)GetValue(TargetNameProperty); }
            set { SetValue(TargetNameProperty, value); }
        }

        public static readonly DependencyProperty PropertyProperty = DependencyProperty.Register(
            "Property", typeof(String), typeof(Animation), new PropertyMetadata(default(String)));

        /// <summary>
        /// 表示动画的目标属性。
        /// </summary>
        public String Property
        {
            get { return (String)GetValue(PropertyProperty); }
            set { SetValue(PropertyProperty, value); }
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
        public virtual CompositionPropertyAnimator BuildCompositionAnimation()
        {
            throw new NotImplementedException("未提供创建 CompositionAnimation 的方法。");
        }

        public virtual void Dispose()
        {
            if (Property != null)
            {
                TargetVisual?.DisconnectAnimation(Property);
            }
            CompositionAnimation?.Dispose();
            CompositionAnimation = null;
            Animator?.Dispose();
            Animator = null;
        }
    }
}