using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CompositionHelper.Animation.Fluent
{
    public class Matrix4x4BaseAnimatableProperty : BaseAnimatableProperty<Matrix4x4>
    {
        internal Matrix4x4BaseAnimatableProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }

        public ScalarBaseAnimatableProperty _11 => new ScalarBaseAnimatableProperty($"{PropertyPath}._11");
        public ScalarBaseAnimatableProperty _12 => new ScalarBaseAnimatableProperty($"{PropertyPath}._12");
        public ScalarBaseAnimatableProperty _13 => new ScalarBaseAnimatableProperty($"{PropertyPath}._13");
        public ScalarBaseAnimatableProperty _14 => new ScalarBaseAnimatableProperty($"{PropertyPath}._14");
        public ScalarBaseAnimatableProperty _21 => new ScalarBaseAnimatableProperty($"{PropertyPath}._21");
        public ScalarBaseAnimatableProperty _22 => new ScalarBaseAnimatableProperty($"{PropertyPath}._22");
        public ScalarBaseAnimatableProperty _23 => new ScalarBaseAnimatableProperty($"{PropertyPath}._23");
        public ScalarBaseAnimatableProperty _24 => new ScalarBaseAnimatableProperty($"{PropertyPath}._24");
        public ScalarBaseAnimatableProperty _31 => new ScalarBaseAnimatableProperty($"{PropertyPath}._31");
        public ScalarBaseAnimatableProperty _32 => new ScalarBaseAnimatableProperty($"{PropertyPath}._32");
        public ScalarBaseAnimatableProperty _33 => new ScalarBaseAnimatableProperty($"{PropertyPath}._33");
        public ScalarBaseAnimatableProperty _34 => new ScalarBaseAnimatableProperty($"{PropertyPath}._34");
        public ScalarBaseAnimatableProperty _41 => new ScalarBaseAnimatableProperty($"{PropertyPath}._41");
        public ScalarBaseAnimatableProperty _42 => new ScalarBaseAnimatableProperty($"{PropertyPath}._42");
        public ScalarBaseAnimatableProperty _43 => new ScalarBaseAnimatableProperty($"{PropertyPath}._43");
        public ScalarBaseAnimatableProperty _44 => new ScalarBaseAnimatableProperty($"{PropertyPath}._44");
    }
}