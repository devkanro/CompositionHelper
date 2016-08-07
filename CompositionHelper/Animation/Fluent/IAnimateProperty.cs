using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Windows.UI;

namespace CompositionHelper.Animation.Fluent
{
    public interface IAnimateProperty
    {
        AnimationTypes AnimationType { get; }

        String PropertyPath { get; }
    }

    public interface IAnimateProperty<T> : IAnimateProperty
    {
    }

    public class BaseAnimateProperty<T> : IAnimateProperty<T>
    {
        internal BaseAnimateProperty([CallerMemberName]String propertyPath = null)
        {
            PropertyPath = propertyPath;
        }

        public AnimationTypes AnimationType => GetAnimationType();
        public String PropertyPath { get; }

        protected virtual AnimationTypes GetAnimationType()
        {
            AnimationTypes result;

            if (Enum.TryParse(typeof(T).Name, true, out result))
            {
                return result;
            }
            return AnimationTypes.NotSupport;
        }
    }

    public class Vector2BaseAnimateProperty : BaseAnimateProperty<Vector2>
    {
        internal Vector2BaseAnimateProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }

        public Vector2BaseAnimateProperty XY => this;
        public ScalarBaseAnimateProperty X => new ScalarBaseAnimateProperty($"{PropertyPath}.x");
        public ScalarBaseAnimateProperty Y => new ScalarBaseAnimateProperty($"{PropertyPath}.y");
    }

    public class Vector3BaseAnimateProperty : BaseAnimateProperty<Vector3>
    {
        internal Vector3BaseAnimateProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }

        public Vector3BaseAnimateProperty XYZ => this;
        public ScalarBaseAnimateProperty X => new ScalarBaseAnimateProperty($"{PropertyPath}.x");
        public ScalarBaseAnimateProperty Y => new ScalarBaseAnimateProperty($"{PropertyPath}.y");
        public ScalarBaseAnimateProperty Z => new ScalarBaseAnimateProperty($"{PropertyPath}.z");
        public Vector2BaseAnimateProperty XY => new Vector2BaseAnimateProperty($"{PropertyPath}.xy");
        public Vector2BaseAnimateProperty XZ => new Vector2BaseAnimateProperty($"{PropertyPath}.xz");
        public Vector2BaseAnimateProperty YZ => new Vector2BaseAnimateProperty($"{PropertyPath}.yz");
    }

    public class Matrix4x4BaseAnimateProperty : BaseAnimateProperty<Matrix4x4>
    {
        internal Matrix4x4BaseAnimateProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }

        public ScalarBaseAnimateProperty _11 => new ScalarBaseAnimateProperty($"{PropertyPath}._11");
        public ScalarBaseAnimateProperty _12 => new ScalarBaseAnimateProperty($"{PropertyPath}._12");
        public ScalarBaseAnimateProperty _13 => new ScalarBaseAnimateProperty($"{PropertyPath}._13");
        public ScalarBaseAnimateProperty _14 => new ScalarBaseAnimateProperty($"{PropertyPath}._14");
        public ScalarBaseAnimateProperty _21 => new ScalarBaseAnimateProperty($"{PropertyPath}._21");
        public ScalarBaseAnimateProperty _22 => new ScalarBaseAnimateProperty($"{PropertyPath}._22");
        public ScalarBaseAnimateProperty _23 => new ScalarBaseAnimateProperty($"{PropertyPath}._23");
        public ScalarBaseAnimateProperty _24 => new ScalarBaseAnimateProperty($"{PropertyPath}._24");
        public ScalarBaseAnimateProperty _31 => new ScalarBaseAnimateProperty($"{PropertyPath}._31");
        public ScalarBaseAnimateProperty _32 => new ScalarBaseAnimateProperty($"{PropertyPath}._32");
        public ScalarBaseAnimateProperty _33 => new ScalarBaseAnimateProperty($"{PropertyPath}._33");
        public ScalarBaseAnimateProperty _34 => new ScalarBaseAnimateProperty($"{PropertyPath}._34");
        public ScalarBaseAnimateProperty _41 => new ScalarBaseAnimateProperty($"{PropertyPath}._41");
        public ScalarBaseAnimateProperty _42 => new ScalarBaseAnimateProperty($"{PropertyPath}._42");
        public ScalarBaseAnimateProperty _43 => new ScalarBaseAnimateProperty($"{PropertyPath}._43");
        public ScalarBaseAnimateProperty _44 => new ScalarBaseAnimateProperty($"{PropertyPath}._44");
    }

    public class Vector4BaseAnimateProperty : BaseAnimateProperty<Vector4>
    {
        internal Vector4BaseAnimateProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }
    }

    public class QuaternionBaseAnimateProperty : BaseAnimateProperty<Quaternion>
    {
        internal QuaternionBaseAnimateProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }
    }

    public class ScalarBaseAnimateProperty : BaseAnimateProperty<Single>
    {
        internal ScalarBaseAnimateProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }
    }

    public class ColorBaseAnimateProperty : BaseAnimateProperty<Color>
    {
        internal ColorBaseAnimateProperty([CallerMemberName]String propertyPath = null) : base(propertyPath)
        {
        }
    }
}
