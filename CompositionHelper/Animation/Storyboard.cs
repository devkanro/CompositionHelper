using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 通过时间线控制动画，并为其子动画提供对象和属性目标信息。
    /// </summary>
    [ContentProperty(Name = "Children")]
    public class Storyboard : DependencyObject, IDisposable
    {
        /// <summary>
        /// 构建一个新的故事版。
        /// </summary>
        public Storyboard()
        {
            Children = new AnimationCollection();
        }

        /// <summary>
        /// 标示 <see cref="Children"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ChildrenProperty = DependencyProperty.Register(
            "Children", typeof(AnimationCollection), typeof(Storyboard), new PropertyMetadata(default(AnimationCollection)));

        /// <summary>
        /// 获取一个集合，表示该故事板包含的子动画。
        /// </summary>
        public AnimationCollection Children
        {
            get { return (AnimationCollection)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        public void Start()
        {
            var animators = Children.Select(c => c.BuildCompositionAnimation());
            foreach (var animator in animators)
            {
                animator.Start();
            }
        }

        public void Stop()
        {
            var animators = Children.Select(c => c.BuildCompositionAnimation());
            foreach (var animator in animators)
            {
                animator.Stop();
            }
        }

        public void Pause()
        {
            var animators = Children.Select(c => c.BuildCompositionAnimation());
            foreach (var animator in animators)
            {
                animator.Pause();
            }
        }

        public void Dispose()
        {
            foreach (var animation in Children)
            {
                animation.Dispose();
            }
        }
    }
}