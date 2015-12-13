using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace CompositionHelper
{
    public static class CompositionProperties
    {
        public static Visual GetVisual(this UIElement element)
        {
            return ElementCompositionPreview.GetElementVisual(element);
        }

        public static Visual GetChildVisual(this UIElement element)
        {
            return ElementCompositionPreview.GetElementChildVisual(element);
        }

        public static void SetChildVisual(this UIElement element, Visual visual)
        {
            ElementCompositionPreview.SetElementChildVisual(element, visual);
        }

        public static void SetAnchorPoint(DependencyObject element, Vector2 value)
        {
            (element as UIElement).GetVisual().AnchorPoint = value;
        }

        public static Vector2 GetAnchorPoint(DependencyObject element)
        {
            return (element as UIElement).GetVisual().AnchorPoint;
        }

        public static void SetBackfaceVisibility(DependencyObject element, CompositionBackfaceVisibility value)
        {
            (element as UIElement).GetVisual().BackfaceVisibility = value;
        }

        public static CompositionBackfaceVisibility GetBackfaceVisibility(DependencyObject element)
        {
            return (element as UIElement).GetVisual().BackfaceVisibility;
        }

        public static void SetBorderMode(DependencyObject element, CompositionBorderMode value)
        {
            (element as UIElement).GetVisual().BorderMode = value;
        }

        public static CompositionBorderMode GetBorderMode(DependencyObject element)
        {
            return (element as UIElement).GetVisual().BorderMode;
        }

        public static void SetCenterPoint(DependencyObject element, Vector3 value)
        {
            (element as UIElement).GetVisual().CenterPoint = value;
        }

        public static Vector3 GetCenterPoint(DependencyObject element)
        {
            return (element as UIElement).GetVisual().CenterPoint;
        }

        public static void SetClip(DependencyObject element, CompositionClip value)
        {
            (element as UIElement).GetVisual().Clip = value;
        }

        public static CompositionClip GetClip(DependencyObject element)
        {
            return (element as UIElement).GetVisual().Clip;
        }

        public static void SetCompositeMode(DependencyObject element, CompositionCompositeMode value)
        {
            (element as UIElement).GetVisual().CompositeMode = value;
        }

        public static CompositionCompositeMode GetCompositeMode(DependencyObject element)
        {
            return (element as UIElement).GetVisual().CompositeMode;
        }

        public static void SetIsVisible(DependencyObject element, bool value)
        {
            (element as UIElement).GetVisual().IsVisible = value;
        }

        public static bool GetIsVisible(DependencyObject element)
        {
            return (element as UIElement).GetVisual().IsVisible;
        }

        public static void SetOffset(DependencyObject element, Vector3 value)
        {
            (element as UIElement).GetVisual().Offset = value;
        }

        public static Vector3 GetOffset(DependencyObject element)
        {
            return (element as UIElement).GetVisual().Offset;
        }

        public static void SetOpacity(DependencyObject element, float value)
        {
            (element as UIElement).GetVisual().Opacity = value;
        }

        public static float  GetOpacity(DependencyObject element)
        {
            return (element as UIElement).GetVisual().Opacity;
        }

        public static void SetOrientation(DependencyObject element, Quaternion value)
        {
            (element as UIElement).GetVisual().Orientation = value;
        }

        public static Quaternion GetOrientation(DependencyObject element)
        {
            return (element as UIElement).GetVisual().Orientation;
        }

        public static void SetRotationAngle(DependencyObject element, float value)
        {
            (element as UIElement).GetVisual().RotationAngle = value;
        }

        public static float GetRotationAngle(DependencyObject element)
        {
            return (element as UIElement).GetVisual().RotationAngle;
        }

        public static void SetRotationAngleInDegrees(DependencyObject element, float value)
        {
            (element as UIElement).GetVisual().RotationAngleInDegrees = value;
        }

        public static float GetRotationAngleInDegrees(DependencyObject element)
        {
            return (element as UIElement).GetVisual().RotationAngleInDegrees;
        }

        public static void SetRotationAxis(DependencyObject element, Vector3 value)
        {
            (element as UIElement).GetVisual().RotationAxis = value;
        }

        public static Vector3  GetRotationAxis(DependencyObject element)
        {
            return (element as UIElement).GetVisual().RotationAxis;
        }

        public static void SetScale(DependencyObject element, Vector3 value)
        {
            (element as UIElement).GetVisual().Scale = value;
        }

        public static Vector3 GetScale(DependencyObject element)
        {
            return (element as UIElement).GetVisual().Scale;
        }

        public static void SetSize(DependencyObject element, Vector2 value)
        {
            (element as UIElement).GetVisual().Size = value;
        }

        public static Vector2 GetSize(DependencyObject element)
        {
            return (element as UIElement).GetVisual().Size;
        }

        public static void SetTransformMatrix(DependencyObject element, Matrix4x4 value)
        {
            (element as UIElement).GetVisual().TransformMatrix = value;
        }

        public static Matrix4x4 GetTransformMatrix(DependencyObject element)
        {
            return (element as UIElement).GetVisual().TransformMatrix;
        }
    }
}
