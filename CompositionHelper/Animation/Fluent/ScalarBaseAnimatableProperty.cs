using System;
using System.Runtime.CompilerServices;

namespace CompositionHelper.Animation.Fluent
{
    public class ScalarBaseAnimatableProperty : BaseAnimatableProperty<float>
    {
        internal ScalarBaseAnimatableProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }
    }
}