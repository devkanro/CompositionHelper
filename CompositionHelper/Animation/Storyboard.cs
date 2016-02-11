using System;
using Windows.UI.Composition;
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
        private CompositionScopedBatch _animationBatch;

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

        /// <summary>
        /// 开始故事板。
        /// </summary>
        public void Start()
        {
            if (_animationBatch != null)
            {
                _animationBatch.Completed -= _animationBatch_Completed;
                _animationBatch.Dispose();
            }

            _animationBatch = AnimationBatchFactory.Singleton.StartAnimations(Children);

            if (_animationBatch == null)
            {
                return;
            }

            _animationBatch.Completed += _animationBatch_Completed;
        }

        private void _animationBatch_Completed(object sender, CompositionBatchCompletedEventArgs args)
        {
            Completed?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// 停止故事板。
        /// </summary>
        public void Stop()
        {
            _animationBatch?.Dispose();
            _animationBatch = null;

            foreach (var animation in Children)
            {
                animation.TargetVisual.StopAnimation(animation.TargetProperty.ToString());
            }
        }

        /// <summary>
        /// [SDK 10586 不可用]暂停故事板。
        /// </summary>
        [Obsolete("SDK 10586 不可用。")]
        public void Pause()
        {
            throw new NotImplementedException("SDK 10586 不可用。");
        }

        /// <summary>
        /// 当故事板动画完成是被触发。
        /// </summary>
        public event EventHandler Completed;

        public void Dispose()
        {
            foreach (var animation in Children)
            {
                animation.Dispose();
            }
        }
    }
}