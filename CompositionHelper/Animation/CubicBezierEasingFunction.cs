using System.Numerics;
using Windows.Foundation;
using Windows.UI.Composition;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 表示采用两个控制点的三次贝塞尔缓动函数。
    /// </summary>
    public class CubicBezierEasingFunction : EasingFunction
    {
        /// <summary>
        /// 提供的默认缓入函数。
        /// </summary>
        public static CubicBezierEasingFunction EaseIn
        {
            get
            {
                return new CubicBezierEasingFunction(0.5, 0.0, 1.0, 1.0);
            }
        }

        /// <summary>
        /// 提供的默认缓出函数。
        /// </summary>
        public static CubicBezierEasingFunction EaseOut
        {
            get
            {
                return new CubicBezierEasingFunction(0.0, 0.0, 0.5, 1.0);
            }
        }

        public CubicBezierEasingFunction()
        {
        }

        public CubicBezierEasingFunction(double controlPoint1X, double controlPoint1Y, double controlPoint2X, double controlPoint2Y) : this(new Point(controlPoint1X, controlPoint1Y), new Point(controlPoint2Y, controlPoint2Y))
        {
        }

        public CubicBezierEasingFunction(Point controlPoint1, Point controlPoint2)
        {
            ControlPoint1 = controlPoint1;
            ControlPoint2 = controlPoint2;
        }

        /// <summary>
        /// 第一个控制点
        /// </summary>
        public Point ControlPoint1 { get; set; }

        /// <summary>
        /// 第二个控制点
        /// </summary>
        public Point ControlPoint2 { get; set; }

        /// <summary>
        /// 创建用于 Composition API 的 CompositionEasingFunction。
        /// </summary>
        /// <param name="compositor"></param>
        /// <returns></returns>
        public override CompositionEasingFunction CreateCompositionEasingFunction(Compositor compositor)
        {
            return compositor.CreateCubicBezierEasingFunction(ControlPoint1.ToVector2(), ControlPoint2.ToVector2());
        }
    }
}