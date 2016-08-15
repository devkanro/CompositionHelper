using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CompositionHelper.Animation.Fluent
{
    public class QuaternionBaseAnimatableProperty : BaseAnimatableProperty<Quaternion>
    {
        internal QuaternionBaseAnimatableProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }
    }
}