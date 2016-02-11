using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    public class EasyCompositionProperties
    {
        public static readonly DependencyProperty AnchorPointProperty = DependencyProperty.RegisterAttached(
            "AnchorPoint", typeof(String), typeof(EasyCompositionProperties), new PropertyMetadata(default(String)));

        public static void SetAnchorPoint(UIElement element, String value)
        {
            CompositionProperties.SetAnchorPoint(element, value.ToVector2());
        }

        public static String GetAnchorPoint(UIElement element)
        {
            return CompositionProperties.GetAnchorPoint(element).ToStringEx();
        }

        public static readonly DependencyProperty BackfaceVisibilityProperty = DependencyProperty.RegisterAttached(
            "BackfaceVisibility", typeof(CompositionBackfaceVisibility), typeof(UIElement), new PropertyMetadata(default(CompositionBackfaceVisibility)));

        public static void SetBackfaceVisibility(UIElement element, CompositionBackfaceVisibility value)
        {
            element.GetVisual().BackfaceVisibility = value;
        }

        public static CompositionBackfaceVisibility GetBackfaceVisibility(UIElement element)
        {
            return element.GetVisual().BackfaceVisibility;
        }

        public static readonly DependencyProperty BorderModeProperty = DependencyProperty.RegisterAttached(
            "BorderMode", typeof(CompositionBorderMode), typeof(UIElement), new PropertyMetadata(default(CompositionBorderMode)));

        public static void SetBorderMode(UIElement element, CompositionBorderMode value)
        {
            element.GetVisual().BorderMode = value;
        }

        public static CompositionBorderMode GetBorderMode(UIElement element)
        {
            return element.GetVisual().BorderMode;
        }

        public static readonly DependencyProperty CenterPointProperty = DependencyProperty.RegisterAttached(
            "CenterPoint", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetCenterPoint(UIElement element, String value)
        {
            CompositionProperties.SetCenterPoint(element, value.ToVector3());
        }

        public static String GetCenterPoint(UIElement element)
        {
            return CompositionProperties.GetCenterPoint(element).ToStringEx();
        }

        public static readonly DependencyProperty CompositeModeProperty = DependencyProperty.RegisterAttached(
            "CompositeMode", typeof(CompositionCompositeMode), typeof(UIElement), new PropertyMetadata(default(CompositionCompositeMode)));

        public static void SetCompositeMode(UIElement element, CompositionCompositeMode value)
        {
            element.GetVisual().CompositeMode = value;
        }

        public static CompositionCompositeMode GetCompositeMode(UIElement element)
        {
            return element.GetVisual().CompositeMode;
        }

        public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.RegisterAttached(
            "IsVisible", typeof(bool), typeof(UIElement), new PropertyMetadata(default(bool)));

        public static void SetIsVisible(UIElement element, bool value)
        {
            element.GetVisual().IsVisible = value;
        }

        public static bool GetIsVisible(UIElement element)
        {
            return element.GetVisual().IsVisible;
        }

        public static readonly DependencyProperty OffsetProperty = DependencyProperty.RegisterAttached(
            "Offset", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetOffset(UIElement element, String value)
        {
            CompositionProperties.SetOffset(element, value.ToVector3());
        }

        public static String GetOffset(UIElement element)
        {
            return CompositionProperties.GetOffset(element).ToStringEx();
        }

        public static readonly DependencyProperty OpacityProperty = DependencyProperty.RegisterAttached(
            "Opacity", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetOpacity(UIElement element, String value)
        {
            CompositionProperties.SetOpacity(element, value.ToScalar());
        }

        public static String GetOpacity(UIElement element)
        {
            return CompositionProperties.GetOpacity(element).ToString();
        }

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.RegisterAttached(
            "Orientation", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetOrientation(UIElement element, String value)
        {
            CompositionProperties.SetOrientation(element, value.ToQuaternion());
        }

        public static String GetOrientation(UIElement element)
        {
            return CompositionProperties.GetOrientation(element).ToStringEx();
        }

        public static readonly DependencyProperty RotationAngleProperty = DependencyProperty.RegisterAttached(
            "RotationAngle", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetRotationAngle(UIElement element, String value)
        {
            CompositionProperties.SetRotationAngle(element, value.ToScalar());
        }

        public static String GetRotationAngle(UIElement element)
        {
            return CompositionProperties.GetRotationAngle(element).ToString();
        }

        public static readonly DependencyProperty RotationAngleInDegreesProperty = DependencyProperty.RegisterAttached(
            "RotationAngleInDegrees", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetRotationAngleInDegrees(UIElement element, String value)
        {
            CompositionProperties.SetRotationAngleInDegrees(element, value.ToScalar());
        }

        public static String GetRotationAngleInDegrees(UIElement element)
        {
            return CompositionProperties.GetRotationAngleInDegrees(element).ToString();
        }

        public static readonly DependencyProperty RotationAxisProperty = DependencyProperty.RegisterAttached(
            "RotationAxis", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetRotationAxis(UIElement element, String value)
        {
            CompositionProperties.SetRotationAngleInDegrees(element, value.ToScalar());
        }

        public static String GetRotationAxis(UIElement element)
        {
            return CompositionProperties.GetRotationAngleInDegrees(element).ToString();
        }

        public static readonly DependencyProperty ScaleProperty = DependencyProperty.RegisterAttached(
            "Scale", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetScale(UIElement element, String value)
        {
            CompositionProperties.SetScale(element, value.ToVector3());
        }

        public static String GetScale(UIElement element)
        {
            return CompositionProperties.GetScale(element).ToStringEx();
        }

        public static readonly DependencyProperty SizeProperty = DependencyProperty.RegisterAttached(
            "Size", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetSize(UIElement element, String value)
        {
            CompositionProperties.SetSize(element, value.ToVector2());
        }

        public static String GetSize(UIElement element)
        {
            return CompositionProperties.GetSize(element).ToStringEx();
        }

        public static readonly DependencyProperty TransformMatrixProperty = DependencyProperty.RegisterAttached(
            "TransformMatrix", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetTransformMatrix(UIElement element, String value)
        {
            CompositionProperties.SetTransformMatrix(element, value.ToMatrix4x4());
        }

        public static String GetTransformMatrix(UIElement element)
        {
            return CompositionProperties.GetTransformMatrix(element).ToStringEx();
        }
    }
}