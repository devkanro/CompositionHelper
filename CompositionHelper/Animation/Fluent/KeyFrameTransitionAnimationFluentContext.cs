using System;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class KeyFrameFluentContext
    {
        internal KeyFrameFluentContext()
        {
        }

        public float Progress { get; set; }
        public CompositionEasingFunction EasingFunction { get; set; }
    }

    public class KeyFrameFluentContext<T> : KeyFrameFluentContext
    {
        internal KeyFrameFluentContext()
        {
        }

        public T Value { get; set; }
    }

    public class ExpressionKeyFrameFluentContext : KeyFrameFluentContext<String>
    {
        internal ExpressionKeyFrameFluentContext()
        {
        }
    }

    public class KeyFrameTransitionAnimationFluentContext<T> : TransitionAnimationFluentContext
    {
        internal KeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected ExpressionKeyFrameFluentContext ExpressionKeyFrameContext { get; private set; }
        protected KeyFrameFluentContext<T> KeyFrameContext { get; private set; }

        /// <summary>
        /// 插入一个表达式帧，并提交上一帧。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> ExpressionKeyFrame(String expression)
        {
            InsertActiveKeyFrame();
            ExpressionKeyFrameContext = new ExpressionKeyFrameFluentContext {Value = expression};
            return this;
        }

        /// <summary>
        /// 插入一个关键帧，并提交上一帧。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> KeyFrame(T value)
        {
            InsertActiveKeyFrame();
            KeyFrameContext = new KeyFrameFluentContext<T> {Value = value};
            return this;
        }

        /// <summary>
        /// 关键帧所处的进度。
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> At(float progress)
        {
            GetActiveKeyFrame().Progress = progress;
            return this;
        }

        /// <summary>
        /// 为当前帧创建一个线性缓动。
        /// </summary>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> WithLinerEasing()
        {
            GetActiveKeyFrame().EasingFunction = CompositionAnimation.Compositor.CreateLinearEasingFunction();
            return this;
        }

        /// <summary>
        /// 为当前帧创建一个基于贝塞尔曲线的缓动。
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> WithCubicBezierEasing(Point point1, Point point2)
        {
            GetActiveKeyFrame().EasingFunction = CompositionAnimation.Compositor.CreateCubicBezierEasingFunction(point1.ToVector2(), point2.ToVector2());
            return this;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// 为当前帧创建一个基于步数的缓动。
        /// </summary>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> WithStepEasing(int stepCount)
        {
            GetActiveKeyFrame().EasingFunction = CompositionAnimation.Compositor.CreateStepEasingFunction(stepCount);
            return this;
        }
#endif

        protected override void OnAnimationBuildOver()
        {
            base.OnAnimationBuildOver();
            InsertActiveKeyFrame();
        }

        protected virtual void InsertKeyFrame(KeyFrameFluentContext<T> keyFrameContext)
        {
            throw new NotImplementedException("InsertKeyFrame must be override.");
        }

        private void InsertActiveKeyFrame()
        {
            var activeKeyFrame = GetActiveKeyFrame();

            if (activeKeyFrame == null)
            {
                return;
            }

            if (activeKeyFrame is ExpressionKeyFrameFluentContext)
            {
                (CompositionAnimation as KeyFrameAnimation).InsertExpressionKeyFrame(activeKeyFrame.Progress, (activeKeyFrame as ExpressionKeyFrameFluentContext).Value);
            }
            else
            {
                InsertKeyFrame(activeKeyFrame as KeyFrameFluentContext<T>);
            }

            ExpressionKeyFrameContext = null;
            KeyFrameContext = null;
        }

        private KeyFrameFluentContext GetActiveKeyFrame()
        {
            if (KeyFrameContext != null && ExpressionKeyFrameContext != null)
            {
                throw new InvalidOperationException("Internal error multiple active frames .");
            }

            if (KeyFrameContext != null)
            {
                return KeyFrameContext;
            }

            if (ExpressionKeyFrameContext != null)
            {
                return ExpressionKeyFrameContext;
            }

            return null;
        }
    }

    public class ScalarKeyFrameTransitionAnimationFluentContext : KeyFrameTransitionAnimationFluentContext<float>
    {
        internal ScalarKeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] ScalarKeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<float> keyFrameContext)
        {
            (CompositionAnimation as ScalarKeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class Vector2KeyFrameTransitionAnimationFluentContext : KeyFrameTransitionAnimationFluentContext<Vector2>
    {
        internal Vector2KeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] Vector2KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Vector2> keyFrameContext)
        {
            (CompositionAnimation as Vector2KeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class Vector3KeyFrameTransitionAnimationFluentContext : KeyFrameTransitionAnimationFluentContext<Vector3>
    {
        internal Vector3KeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] Vector3KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Vector3> keyFrameContext)
        {
            (CompositionAnimation as Vector3KeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class Vector4KeyFrameTransitionAnimationFluentContext : KeyFrameTransitionAnimationFluentContext<Vector4>
    {
        internal Vector4KeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] Vector4KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Vector4> keyFrameContext)
        {
            (CompositionAnimation as Vector4KeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class ColorKeyFrameTransitionAnimationFluentContext : KeyFrameTransitionAnimationFluentContext<Color>
    {
        internal ColorKeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] ColorKeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Color> keyFrameContext)
        {
            (CompositionAnimation as ColorKeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class QuaternionKeyFrameTransitionAnimationFluentContext : KeyFrameTransitionAnimationFluentContext<Quaternion>
    {
        internal QuaternionKeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] QuaternionKeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Quaternion> keyFrameContext)
        {
            (CompositionAnimation as QuaternionKeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }
}