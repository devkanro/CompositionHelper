using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace CompositionHelper.Animation
{
    internal interface IAnimation : IDisposable
    {
        UIElement Target { get; set; }

        String Property { get; set; }

        ParameterCollection Parameters { get; }

        CompositionPropertyAnimator BuildCompositionAnimation();
    }
}