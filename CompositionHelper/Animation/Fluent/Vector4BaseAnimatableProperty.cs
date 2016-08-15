using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CompositionHelper.Animation.Fluent
{
    public class Vector4BaseAnimatableProperty : BaseAnimatableProperty<Vector4>
    {
        internal Vector4BaseAnimatableProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }
    }
}