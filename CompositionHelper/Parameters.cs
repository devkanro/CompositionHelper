using CompositionHelper.Helper;
using System;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace CompositionHelper
{
    /// <summary>
    /// 引用参数。
    /// </summary>
    public class ReferenceParameter : Parameter<CompositionObject>
    {
        private CompositionObject _value;

        /// <summary>
        /// 设置需要创建引用参数的对象。
        /// </summary>
        public UIElement Target
        {
            set
            {
                if (value != null)
                {
                    switch (CreateMode)
                    {
                        case ReferenceParameterCreateMode.Visual:
                            _value = ElementCompositionPreview.GetElementVisual(value);
                            break;
                        case ReferenceParameterCreateMode.ScrollViewerManipulationPropertySet:
                            ScrollViewer scrollViewer = value is ScrollViewer ? value as ScrollViewer : VisualTreeHelper.FindVisualElement<ScrollViewer>(value);
                            if (scrollViewer != null)
                            {
                                _value = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(scrollViewer);
                            }
                            else
                            {
                                throw new InvalidOperationException("创建 ScrollViewerManipulationPropertySet 时，对象必须是 ScrollViewer 或者包含 ScrollViewer 的 UI 元素。");
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 设置需要创建引用参数的对象名称。
        /// </summary>
        public String TargetName
        {
            set
            {
                if (value != null)
                {
                    Target = VisualTreeHelper.FindVisualElementFormName((FrameworkElement) Window.Current.Content, value);
                }
            }
        }

        /// <summary>
        /// 获取或设置创建引用对象的方式。
        /// </summary>
        public ReferenceParameterCreateMode CreateMode { get; set; }

        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetReferenceParameter(Name, ObjectValue);
        }

        protected override CompositionObject ValueToObject(string value)
        {
            return _value;
        }
    }

    /// <summary>
    /// 创建引用参数的模式。
    /// </summary>
    public enum ReferenceParameterCreateMode
    {
        /// <summary>
        /// 创建为 Visual。
        /// </summary>
        Visual,
        /// <summary>
        /// 创建为 ScrollViewerManipulationPropertySet。
        /// </summary>
        ScrollViewerManipulationPropertySet
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