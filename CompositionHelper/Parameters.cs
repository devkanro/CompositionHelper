using CompositionHelper.Helper;
using System;
using System.Numerics;
using Windows.UI.Composition;

namespace CompositionHelper
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
            return value.ToScalar();
        }
    }

    /// <summary>
    /// 二维矢量参数。
    /// </summary>
    public class Vector2Parameter : Parameter<Vector2>
    {
        /// <summary>
        /// 为动画添加参数。
        /// </summary>
        /// <param name="animation"></param>
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetVector2Parameter(Name, ObjectValue);
        }

        protected override Vector2 ValueToObject(string value)
        {
            return value.ToVector2();
        }
    }

    /// <summary>
    /// 三维矢量参数。
    /// </summary>
    public class Vector3Parameter : Parameter<Vector3>
    {
        /// <summary>
        /// 为动画添加参数。
        /// </summary>
        /// <param name="animation"></param>
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetVector3Parameter(Name, ObjectValue);
        }

        protected override Vector3 ValueToObject(string value)
        {
            return value.ToVector3();
        }
    }

    /// <summary>
    /// 四维矢量参数。
    /// </summary>
    public class Vector4Parameter : Parameter<Vector4>
    {
        /// <summary>
        /// 为动画添加参数。
        /// </summary>
        /// <param name="animation"></param>
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetVector4Parameter(Name, ObjectValue);
        }

        protected override Vector4 ValueToObject(string value)
        {
            return value.ToVector4();
        }
    }

    /// <summary>
    /// 3x2矩阵参数。
    /// </summary>
    public class Matrix3x2Parameter : Parameter<Matrix3x2>
    {
        /// <summary>
        /// 为动画添加参数。
        /// </summary>
        /// <param name="animation"></param>
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetMatrix3x2Parameter(Name, ObjectValue);
        }

        protected override Matrix3x2 ValueToObject(string value)
        {
            return value.ToMatrix3x2();
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

        protected override Matrix4x4 ValueToObject(string value)
        {
            return value.ToMatrix4x4();
        }
    }

    /// <summary>
    /// 四元数参数。
    /// </summary>
    public class QuaternionParameter : Parameter<Quaternion>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetQuaternionParameter(Name, ObjectValue);
        }

        protected override Quaternion ValueToObject(string value)
        {
            return value.ToQuaternion();
        }
    }
}