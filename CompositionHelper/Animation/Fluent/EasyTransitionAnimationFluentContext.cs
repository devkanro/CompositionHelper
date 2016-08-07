using System;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class EasyTransitionAnimationFluentContext<T> : TransitionAnimationFluentContext
    {
        internal EasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }
        protected ExpressionKeyFrameFluentContext ExpressionKeyFrameContext { get; private set; }
        protected KeyFrameFluentContext<T> KeyFrameContext { get; private set; }

        /// <summary>
        /// 为当前帧创建一个线性缓动。
        /// </summary>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> WithLinerEasing()
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
        public EasyTransitionAnimationFluentContext<T> WithCubicBezierEasing(Point point1, Point point2)
        {
            GetActiveKeyFrame().EasingFunction = CompositionAnimation.Compositor.CreateCubicBezierEasingFunction(point1.ToVector2(), point2.ToVector2());
            return this;
        }

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
        
        /// <summary>
        /// 指定动画开始的值。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> From(T value)
        {
            InsertActiveKeyFrame();
            KeyFrameContext = new KeyFrameFluentContext<T>
            {
                Value = value,
                Progress = 0
            };
            return this;
        }

        /// <summary>
        /// 指定动画结束的值。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> To(T value)
        {
            InsertActiveKeyFrame();
            KeyFrameContext = new KeyFrameFluentContext<T>
            {
                Value = value,
                Progress = 1
            };
            return this;
        }

        /// <summary>
        /// 通过表达式指定动画开始的值。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> FromExpression(String expression)
        {
            InsertActiveKeyFrame();
            ExpressionKeyFrameContext = new ExpressionKeyFrameFluentContext
            {
                Value = expression,
                Progress = 0
            };
            return this;
        }

        /// <summary>
        /// 通过表达式指定动画结束的值
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> ToExpression(String expression)
        {
            InsertActiveKeyFrame();
            ExpressionKeyFrameContext = new ExpressionKeyFrameFluentContext
            {
                Value = expression,
                Progress = 1
            };
            return this;
        }
    }

    public class ScalarEasyTransitionAnimationFluentContext : EasyTransitionAnimationFluentContext<float>
    {
        internal ScalarEasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] ScalarKeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<float> keyFrameContext)
        {
            (CompositionAnimation as ScalarKeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class Vector2EasyTransitionAnimationFluentContext : EasyTransitionAnimationFluentContext<Vector2>
    {
        internal Vector2EasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] Vector2KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Vector2> keyFrameContext)
        {
            (CompositionAnimation as Vector2KeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class Vector3EasyTransitionAnimationFluentContext : EasyTransitionAnimationFluentContext<Vector3>
    {
        internal Vector3EasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] Vector3KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Vector3> keyFrameContext)
        {
            (CompositionAnimation as Vector3KeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class Vector4EasyTransitionAnimationFluentContext : EasyTransitionAnimationFluentContext<Vector4>
    {
        internal Vector4EasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] Vector4KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Vector4> keyFrameContext)
        {
            (CompositionAnimation as Vector4KeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class ColorEasyTransitionAnimationFluentContext : EasyTransitionAnimationFluentContext<Color>
    {
        internal ColorEasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] ColorKeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Color> keyFrameContext)
        {
            (CompositionAnimation as ColorKeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }

    public class QuaternionEasyTransitionAnimationFluentContext : EasyTransitionAnimationFluentContext<Quaternion>
    {
        internal QuaternionEasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] QuaternionKeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected override void InsertKeyFrame(KeyFrameFluentContext<Quaternion> keyFrameContext)
        {
            (CompositionAnimation as QuaternionKeyFrameAnimation).InsertKeyFrame(keyFrameContext.Progress, keyFrameContext.Value, keyFrameContext.EasingFunction);
        }
    }
}