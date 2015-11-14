using System;
using System.Linq;
using System.Numerics;
using Windows.UI.Composition;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 引用参数。
    /// </summary>
    [Obsolete]
    public class ReferenceParameter : Parameter<CompositionObject>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetReferenceParameter(Name, ObjectValue);
        }
    }

    /// <summary>
    /// 标量参数。
    /// </summary>
    public class ScalarParameter : Parameter<float>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetScalarParameter(Name, ObjectValue);
        }

        protected override float ValueToObject(string value)
        {
            return float.Parse(value);
        }
    }

    /// <summary>
    /// 二维矢量参数。
    /// </summary>
    public class Vector2Parameter : Parameter<Vector2>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetVector2Parameter(Name, ObjectValue);
        }

        protected override Vector2 ValueToObject(string value)
        {
            var data = value.Split(',').Select(s => float.Parse(s)).ToList();
            switch (data.Count)
            {
                case 1:
                    return new Vector2(data[0], data[0]);

                case 2:
                    return new Vector2(data[0], data[1]);
            }
            return Vector2.Zero;
        }
    }

    /// <summary>
    /// 三维矢量参数。
    /// </summary>
    public class Vector3Parameter : Parameter<Vector3>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetVector3Parameter(Name, ObjectValue);
        }

        protected override Vector3 ValueToObject(string value)
        {
            var data = value.Split(',').Select(s => float.Parse(s)).ToList();
            switch (data.Count)
            {
                case 1:
                    return new Vector3(data[0], data[0], data[0]);

                case 3:
                    return new Vector3(data[0], data[1], data[2]);
            }
            return Vector3.Zero;
        }
    }

    /// <summary>
    /// 四维矢量参数。
    /// </summary>
    public class Vector4Parameter : Parameter<Vector4>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetVector4Parameter(Name, ObjectValue);
        }

        protected override Vector4 ValueToObject(string value)
        {
            var data = value.Split(',').Select(s => float.Parse(s)).ToList();
            switch (data.Count)
            {
                case 1:
                    return new Vector4(data[0], data[0], data[0], data[0]);

                case 2:
                    return new Vector4(data[0], data[0], data[1], data[1]);

                case 4:
                    return new Vector4(data[0], data[1], data[2], data[3]);
            }
            return Vector4.Zero;
        }
    }

    /// <summary>
    /// 3x2矩阵参数。
    /// </summary>
    public class Matrix3x2Parameter : Parameter<Matrix3x2>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetMatrix3x2Parameter(Name, ObjectValue);
        }
    }

    /// <summary>
    /// 4x4矩阵参数。
    /// </summary>
    public class Matrix4x4Parameter : Parameter<Matrix4x4>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetMatrix4x4Parameter(Name, ObjectValue);
        }
    }
}