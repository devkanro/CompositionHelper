using System;
using System.Runtime.CompilerServices;
using Windows.UI;

namespace CompositionHelper.Animation.Fluent
{
    public class ColorBaseAnimatableProperty : BaseAnimatableProperty<Color>
    {
        internal ColorBaseAnimatableProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }
    }
}