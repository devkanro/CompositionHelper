using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CompositionHelper.Animation.Fluent
{
    public class Vector3BaseAnimatableProperty : BaseAnimatableProperty<Vector3>
    {
        internal Vector3BaseAnimatableProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }

        public Vector3BaseAnimatableProperty XYZ => this;
        public ScalarBaseAnimatableProperty X => new ScalarBaseAnimatableProperty($"{PropertyPath}.x");
        public ScalarBaseAnimatableProperty Y => new ScalarBaseAnimatableProperty($"{PropertyPath}.y");
        public ScalarBaseAnimatableProperty Z => new ScalarBaseAnimatableProperty($"{PropertyPath}.z");
        public Vector2BaseAnimatableProperty XY => new Vector2BaseAnimatableProperty($"{PropertyPath}.xy");
        public Vector2BaseAnimatableProperty XZ => new Vector2BaseAnimatableProperty($"{PropertyPath}.xz");
        public Vector2BaseAnimatableProperty YZ => new Vector2BaseAnimatableProperty($"{PropertyPath}.yz");
    }
}