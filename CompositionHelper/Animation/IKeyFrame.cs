using Windows.UI.Composition;

namespace CompositionHelper.Animation
{
    internal interface IKeyFrame
    {
        double Progress { get; set; }

        EasingFunction EasingFunction { get; set; }

        void AddKayFrameToAnimation(KeyFrameAnimation animation);
    }
}