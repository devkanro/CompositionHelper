using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    public static class EasyCompositionProperties
    {
        public static readonly DependencyProperty AnchorPointProperty = DependencyProperty.RegisterAttached(
            "AnchorPoint", typeof(String), typeof(EasyCompositionProperties), new PropertyMetadata(default(String)));

        public static void SetAnchorPoint(DependencyObject element, String value)
        {
            CompositionProperties.SetAnchorPoint(element, value.ToVector2());
        }

        public static String GetAnchorPoint(DependencyObject element)
        {
            return CompositionProperties.GetAnchorPoint(element).ToStringEx();
        }

        public static readonly DependencyProperty BackfaceVisibilityProperty = DependencyProperty.RegisterAttached(
            "BackfaceVisibility", typeof(CompositionBackfaceVisibility), typeof(UIElement), new PropertyMetadata(default(CompositionBackfaceVisibility)));

        public static void SetBackfaceVisibility(DependencyObject element, CompositionBackfaceVisibility value)
        {
            (element as UIElement).GetVisual().BackfaceVisibility = value;
        }

        public static CompositionBackfaceVisibility GetBackfaceVisibility(DependencyObject element)
        {
            return (element as UIElement).GetVisual().BackfaceVisibility;
        }

        public static readonly DependencyProperty BorderModeProperty = DependencyProperty.RegisterAttached(
            "BorderMode", typeof(CompositionBorderMode), typeof(UIElement), new PropertyMetadata(default(CompositionBorderMode)));

        public static void SetBorderMode(DependencyObject element, CompositionBorderMode value)
        {
            (element as UIElement).GetVisual().BorderMode = value;
        }

        public static CompositionBorderMode GetBorderMode(DependencyObject element)
        {
            return (element as UIElement).GetVisual().BorderMode;
        }

        public static readonly DependencyProperty CenterPointProperty = DependencyProperty.RegisterAttached(
            "CenterPoint", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetCenterPoint(DependencyObject element, String value)
        {
            CompositionProperties.SetCenterPoint(element, value.ToVector3());
        }

        public static String GetCenterPoint(DependencyObject element)
        {
            return CompositionProperties.GetCenterPoint(element).ToStringEx();
        }
        

        public static readonly DependencyProperty CompositeModeProperty = DependencyProperty.RegisterAttached(
            "CompositeMode", typeof(CompositionCompositeMode), typeof(UIElement), new PropertyMetadata(default(CompositionCompositeMode)));

        public static void SetCompositeMode(DependencyObject element, CompositionCompositeMode value)
        {
            (element as UIElement).GetVisual().CompositeMode = value;
        }

        public static CompositionCompositeMode GetCompositeMode(DependencyObject element)
        {
            return (element as UIElement).GetVisual().CompositeMode;
        }

        public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.RegisterAttached(
            "IsVisible", typeof(bool), typeof(UIElement), new PropertyMetadata(default(bool)));

        public static void SetIsVisible(DependencyObject element, bool value)
        {
            (element as UIElement).GetVisual().IsVisible = value;
        }

        public static bool GetIsVisible(DependencyObject element)
        {
            return (element as UIElement).GetVisual().IsVisible;
        }

        public static readonly DependencyProperty OffsetProperty = DependencyProperty.RegisterAttached(
            "Offset", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetOffset(DependencyObject element, String value)
        {
            CompositionProperties.SetOffset(element, value.ToVector3());
        }

        public static String GetOffset(DependencyObject element)
        {
            return CompositionProperties.GetOffset(element).ToStringEx();
        }

        public static readonly DependencyProperty OpacityProperty = DependencyProperty.RegisterAttached(
            "Opacity", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetOpacity(DependencyObject element, String value)
        {
            CompositionProperties.SetOpacity(element, value.ToScalar());
        }

        public static String GetOpacity(DependencyObject element)
        {
            return CompositionProperties.GetOpacity(element).ToString();
        }

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.RegisterAttached(
            "Orientation", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetOrientation(DependencyObject element, String value)
        {
            CompositionProperties.SetOrientation(element, value.ToQuaternion());
        }

        public static String GetOrientation(DependencyObject element)
        {
            return CompositionProperties.GetOrientation(element).ToStringEx();
        }

        public static readonly DependencyProperty RotationAngleProperty = DependencyProperty.RegisterAttached(
            "RotationAngle", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetRotationAngle(DependencyObject element, String value)
        {
            CompositionProperties.SetRotationAngle(element, value.ToScalar());
        }

        public static String GetRotationAngle(DependencyObject element)
        {
            return CompositionProperties.GetRotationAngle(element).ToString();
        }

        public static readonly DependencyProperty RotationAngleInDegreesProperty = DependencyProperty.RegisterAttached(
            "RotationAngleInDegrees", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetRotationAngleInDegrees(DependencyObject element, String value)
        {
            CompositionProperties.SetRotationAngleInDegrees(element, value.ToScalar());
        }

        public static String GetRotationAngleInDegrees(DependencyObject element)
        {
            return CompositionProperties.GetRotationAngleInDegrees(element).ToString();
        }

        public static readonly DependencyProperty RotationAxisProperty = DependencyProperty.RegisterAttached(
            "RotationAxis", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetRotationAxis(DependencyObject element, String value)
        {
            CompositionProperties.SetRotationAngleInDegrees(element, value.ToScalar());
        }

        public static String GetRotationAxis(DependencyObject element)
        {
            return CompositionProperties.GetRotationAngleInDegrees(element).ToString();
        }

        public static readonly DependencyProperty ScaleProperty = DependencyProperty.RegisterAttached(
            "Scale", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetScale(DependencyObject element, String value)
        {
            CompositionProperties.SetScale(element, value.ToVector3());
        }

        public static String GetScale(DependencyObject element)
        {
            return CompositionProperties.GetScale(element).ToStringEx();
        }

        public static readonly DependencyProperty SizeProperty = DependencyProperty.RegisterAttached(
            "Size", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetSize(DependencyObject element, String value)
        {
            CompositionProperties.SetSize(element, value.ToVector2());
        }

        public static String GetSize(DependencyObject element)
        {
            return CompositionProperties.GetSize(element).ToStringEx();
        }

        public static readonly DependencyProperty TransformMatrixProperty = DependencyProperty.RegisterAttached(
            "TransformMatrix", typeof(String), typeof(UIElement), new PropertyMetadata(default(String)));

        public static void SetTransformMatrix(DependencyObject element, String value)
        {
            CompositionProperties.SetTransformMatrix(element, value.ToMatrix4x4());
        }

        public static String GetTransformMatrix(DependencyObject element)
        {
            return CompositionProperties.GetTransformMatrix(element).ToStringEx();
        }
    }
}
