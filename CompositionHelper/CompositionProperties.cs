using System.Numerics;
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

        public static void SetAnchorPoint(this UIElement element, Vector2 value)
        {
            element.GetVisual().AnchorPoint = value;
        }

        public static Vector2 GetAnchorPoint(this UIElement element)
        {
            return element.GetVisual().AnchorPoint;
        }

        public static void SetBackfaceVisibility(this UIElement element, CompositionBackfaceVisibility value)
        {
            element.GetVisual().BackfaceVisibility = value;
        }

        public static CompositionBackfaceVisibility GetBackfaceVisibility(this UIElement element)
        {
            return element.GetVisual().BackfaceVisibility;
        }

        public static void SetBorderMode(this UIElement element, CompositionBorderMode value)
        {
            element.GetVisual().BorderMode = value;
        }

        public static CompositionBorderMode GetBorderMode(this UIElement element)
        {
            return element.GetVisual().BorderMode;
        }

        public static void SetCenterPoint(this UIElement element, Vector3 value)
        {
            element.GetVisual().CenterPoint = value;
        }

        public static Vector3 GetCenterPoint(this UIElement element)
        {
            return element.GetVisual().CenterPoint;
        }

        public static void SetClip(this UIElement element, CompositionClip value)
        {
            element.GetVisual().Clip = value;
        }

        public static CompositionClip GetClip(this UIElement element)
        {
            return element.GetVisual().Clip;
        }

        public static void SetCompositeMode(this UIElement element, CompositionCompositeMode value)
        {
            element.GetVisual().CompositeMode = value;
        }

        public static CompositionCompositeMode GetCompositeMode(this UIElement element)
        {
            return element.GetVisual().CompositeMode;
        }

        public static void SetIsVisible(this UIElement element, bool value)
        {
            element.GetVisual().IsVisible = value;
        }

        public static bool GetIsVisible(this UIElement element)
        {
            return element.GetVisual().IsVisible;
        }

        public static void SetOffset(this UIElement element, Vector3 value)
        {
            element.GetVisual().Offset = value;
        }

        public static Vector3 GetOffset(this UIElement element)
        {
            return element.GetVisual().Offset;
        }

        public static void SetOpacity(this UIElement element, float value)
        {
            element.GetVisual().Opacity = value;
        }

        public static float GetOpacity(this UIElement element)
        {
            return element.GetVisual().Opacity;
        }

        public static void SetOrientation(this UIElement element, Quaternion value)
        {
            element.GetVisual().Orientation = value;
        }

        public static Quaternion GetOrientation(this UIElement element)
        {
            return element.GetVisual().Orientation;
        }

        public static void SetRotationAngle(this UIElement element, float value)
        {
            element.GetVisual().RotationAngle = value;
        }

        public static float GetRotationAngle(this UIElement element)
        {
            return element.GetVisual().RotationAngle;
        }

        public static void SetRotationAngleInDegrees(this UIElement element, float value)
        {
            element.GetVisual().RotationAngleInDegrees = value;
        }

        public static float GetRotationAngleInDegrees(this UIElement element)
        {
            return element.GetVisual().RotationAngleInDegrees;
        }

        public static void SetRotationAxis(this UIElement element, Vector3 value)
        {
            element.GetVisual().RotationAxis = value;
        }

        public static Vector3 GetRotationAxis(this UIElement element)
        {
            return element.GetVisual().RotationAxis;
        }

        public static void SetScale(this UIElement element, Vector3 value)
        {
            element.GetVisual().Scale = value;
        }

        public static Vector3 GetScale(this UIElement element)
        {
            return element.GetVisual().Scale;
        }

        public static void SetSize(this UIElement element, Vector2 value)
        {
            element.GetVisual().Size = value;
        }

        public static Vector2 GetSize(this UIElement element)
        {
            return element.GetVisual().Size;
        }

        public static void SetTransformMatrix(this UIElement element, Matrix4x4 value)
        {
            element.GetVisual().TransformMatrix = value;
        }

        public static Matrix4x4 GetTransformMatrix(this UIElement element)
        {
            return element.GetVisual().TransformMatrix;
        }
    }
}