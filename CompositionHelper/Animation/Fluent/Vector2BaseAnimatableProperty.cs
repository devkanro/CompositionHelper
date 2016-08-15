using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CompositionHelper.Animation.Fluent
{
    public class Vector2BaseAnimatableProperty : BaseAnimatableProperty<Vector2>
    {
        internal Vector2BaseAnimatableProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }

        public Vector2BaseAnimatableProperty XY => this;
        public ScalarBaseAnimatableProperty X => new ScalarBaseAnimatableProperty($"{PropertyPath}.x");
        public ScalarBaseAnimatableProperty Y => new ScalarBaseAnimatableProperty($"{PropertyPath}.y");
    }
}