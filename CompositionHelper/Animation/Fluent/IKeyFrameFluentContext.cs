using System;
using Windows.UI.Composition;

namespace CompositionHelper.Animation.Fluent
{
    public interface IKeyFrameFluentContext
    {
        float Progress { get; set; }
        CompositionEasingFunction EasingFunction { get; set; }
        Object Value { get; set; }
    }
}