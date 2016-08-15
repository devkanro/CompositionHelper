using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation.Fluent
{
    public static class StoryBoardFluentExtension
    {
        /// <summary>
        /// 开始为制定的 <see cref="Visual"/> 对象构建动画。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static StoryBoardFluentContext StartBuildAnimation([NotNull]this Visual target)
        {
            return new StoryBoardFluentContext(target);
        }

        public static EasyTransitionAnimationFluentContext<Vector2> From(this EasyTransitionAnimationFluentContext<Vector2> animationFluentContext, float x, float y)
        {
            animationFluentContext.From(new Vector2(x, y));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector3> From(this EasyTransitionAnimationFluentContext<Vector3> animationFluentContext, float x, float y, float z)
        {
            animationFluentContext.From(new Vector3(x, y, z));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector4> From(this EasyTransitionAnimationFluentContext<Vector4> animationFluentContext, float x, float y, float z, float w)
        {
            animationFluentContext.From(new Vector4(x, y, z, w));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Quaternion> From(this EasyTransitionAnimationFluentContext<Quaternion> animationFluentContext, float x, float y, float z, float w)
        {
            animationFluentContext.From(new Quaternion(x, y, z, w));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Color> From(this EasyTransitionAnimationFluentContext<Color> animationFluentContext, byte r, byte g, byte b)
        {
            animationFluentContext.From(Color.FromArgb(0xFF, r, g, b));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Color> From(this EasyTransitionAnimationFluentContext<Color> animationFluentContext, byte a, byte r, byte g, byte b)
        {
            animationFluentContext.From(Color.FromArgb(a, r, g, b));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Color> From(this EasyTransitionAnimationFluentContext<Color> animationFluentContext, string colorCode)
        {
            animationFluentContext.From(colorCode.ToColor());
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Color> From(this EasyTransitionAnimationFluentContext<Color> animationFluentContext, int colorCode)
        {
            animationFluentContext.From(colorCode.ToColor());
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector2> From(this EasyTransitionAnimationFluentContext<Vector2> animationFluentContext, float value)
        {
            animationFluentContext.From(new Vector2(value, value));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector3> From(this EasyTransitionAnimationFluentContext<Vector3> animationFluentContext, float value)
        {
            animationFluentContext.From(new Vector3(value, value, value));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector4> From(this EasyTransitionAnimationFluentContext<Vector4> animationFluentContext, float value)
        {
            animationFluentContext.From(new Vector4(value, value, value, value));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Quaternion> From(this EasyTransitionAnimationFluentContext<Quaternion> animationFluentContext, float value)
        {
            animationFluentContext.From(new Quaternion(value, value, value, value));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector2> To(this EasyTransitionAnimationFluentContext<Vector2> animationFluentContext, float x, float y)
        {
            animationFluentContext.To(new Vector2(x, y));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector3> To(this EasyTransitionAnimationFluentContext<Vector3> animationFluentContext, float x, float y, float z)
        {
            animationFluentContext.To(new Vector3(x, y, z));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector4> To(this EasyTransitionAnimationFluentContext<Vector4> animationFluentContext, float x, float y, float z, float w)
        {
            animationFluentContext.To(new Vector4(x, y, z, w));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Quaternion> To(this EasyTransitionAnimationFluentContext<Quaternion> animationFluentContext, float x, float y, float z, float w)
        {
            animationFluentContext.To(new Quaternion(x, y, z, w));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Color> To(this EasyTransitionAnimationFluentContext<Color> animationFluentContext, byte r, byte g, byte b)
        {
            animationFluentContext.To(Color.FromArgb(0xFF, r, g, b));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Color> To(this EasyTransitionAnimationFluentContext<Color> animationFluentContext, byte a, byte r, byte g, byte b)
        {
            animationFluentContext.To(Color.FromArgb(a, r, g, b));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Color> To(this EasyTransitionAnimationFluentContext<Color> animationFluentContext, string colorCode)
        {
            animationFluentContext.To(colorCode.ToColor());
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Color> To(this EasyTransitionAnimationFluentContext<Color> animationFluentContext, int colorCode)
        {
            animationFluentContext.To(colorCode.ToColor());
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector2> To(this EasyTransitionAnimationFluentContext<Vector2> animationFluentContext, float value)
        {
            animationFluentContext.To(new Vector2(value, value));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector3> To(this EasyTransitionAnimationFluentContext<Vector3> animationFluentContext, float value)
        {
            animationFluentContext.To(new Vector3(value, value, value));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Vector4> To(this EasyTransitionAnimationFluentContext<Vector4> animationFluentContext, float value)
        {
            animationFluentContext.To(new Vector4(value, value, value, value));
            return animationFluentContext;
        }

        public static EasyTransitionAnimationFluentContext<Quaternion> To(this EasyTransitionAnimationFluentContext<Quaternion> animationFluentContext, float value)
        {
            animationFluentContext.To(new Quaternion(value, value, value, value));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Vector2> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Vector2> animationFluentContext, float x, float y)
        {
            animationFluentContext.KeyFrame(new Vector2(x, y));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Vector3> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Vector3> animationFluentContext, float x, float y, float z)
        {
            animationFluentContext.KeyFrame(new Vector3(x, y, z));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Vector4> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Vector4> animationFluentContext, float x, float y, float z, float w)
        {
            animationFluentContext.KeyFrame(new Vector4(x, y, z, w));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Quaternion> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Quaternion> animationFluentContext, float x, float y, float z, float w)
        {
            animationFluentContext.KeyFrame(new Quaternion(x, y, z, w));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Color> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Color> animationFluentContext, byte r, byte g, byte b)
        {
            animationFluentContext.KeyFrame(Color.FromArgb(0xFF, r, g, b));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Color> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Color> animationFluentContext, byte a, byte r, byte g, byte b)
        {
            animationFluentContext.KeyFrame(Color.FromArgb(a, r, g, b));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Color> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Color> animationFluentContext, string colorCode)
        {
            animationFluentContext.KeyFrame(colorCode.ToColor());
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Color> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Color> animationFluentContext, int colorCode)
        {
            animationFluentContext.KeyFrame(colorCode.ToColor());
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Vector2> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Vector2> animationFluentContext, float value)
        {
            animationFluentContext.KeyFrame(new Vector2(value, value));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Vector3> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Vector3> animationFluentContext, float value)
        {
            animationFluentContext.KeyFrame(new Vector3(value, value, value));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Vector4> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Vector4> animationFluentContext, float value)
        {
            animationFluentContext.KeyFrame(new Vector4(value, value, value, value));
            return animationFluentContext;
        }

        public static KeyFrameTransitionAnimationFluentContext<Quaternion> KeyFrame(this KeyFrameTransitionAnimationFluentContext<Quaternion> animationFluentContext, float value)
        {
            animationFluentContext.KeyFrame(new Quaternion(value, value, value, value));
            return animationFluentContext;
        }
    }
}