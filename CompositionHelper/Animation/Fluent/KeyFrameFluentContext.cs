using Windows.UI.Composition;

namespace CompositionHelper.Animation.Fluent
{
    public class KeyFrameFluentContext<T> : IKeyFrameFluentContext
    {
        internal KeyFrameFluentContext()
        {
        }

        public float Progress { get; set; }
        public CompositionEasingFunction EasingFunction { get; set; }
        object IKeyFrameFluentContext.Value
        {
            get { return Value; }
            set { Value = (T)value; }
        }
        public T Value { get; set; }
    }
}