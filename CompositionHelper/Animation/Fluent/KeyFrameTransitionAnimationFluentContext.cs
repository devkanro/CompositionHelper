using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public abstract class KeyFrameTransitionAnimationFluentContext<T> : TransitionAnimationFluentContext
    {
        internal KeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
            KeyFrameContexts = new List<IKeyFrameFluentContext>();
        }

        protected IList<IKeyFrameFluentContext> KeyFrameContexts { get; private set; }
        protected IKeyFrameFluentContext CurrentKeyFrameContext { get; private set; }

        /// <summary>
        /// 插入一个表达式帧，并提交上一帧。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> ExpressionKeyFrame(String expression)
        {
            InsertActiveKeyFrame();
            CurrentKeyFrameContext = new ExpressionKeyFrameFluentContext { Value = expression };
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
            CurrentKeyFrameContext = new KeyFrameFluentContext<T> { Value = value };
            return this;
        }

        /// <summary>
        /// 关键帧所处的进度。
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> At(float progress)
        {
            CurrentKeyFrameContext.Progress = progress;
            return this;
        }

        /// <summary>
        /// 为当前帧创建一个线性缓动。
        /// </summary>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> WithLinerEasing()
        {
            CurrentKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateLinearEasingFunction();
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
            CurrentKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateCubicBezierEasingFunction(point1.ToVector2(), point2.ToVector2());
            return this;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]为当前帧创建一个基于步数的缓动。
        /// </summary>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> WithStepEasing(int stepCount)
        {
            CurrentKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateStepEasingFunction(stepCount);
            return this;
        }
#endif

        protected override void OnAnimationBuildOver()
        {
            base.OnAnimationBuildOver();
            InsertActiveKeyFrame();
            InsertActiveKeyFrameToAnimation();
        }

        protected abstract void InsertKeyFrame(KeyFrameFluentContext<T> keyFrameContext);
        protected abstract void InsertExpressionKeyFrame(ExpressionKeyFrameFluentContext keyFrameContext);
        private void InsertActiveKeyFrameToAnimation()
        {
            foreach (var frameContext in KeyFrameContexts)
            {
                if (frameContext is ExpressionKeyFrameFluentContext)
                {
                    InsertExpressionKeyFrame(frameContext as ExpressionKeyFrameFluentContext);
                }
                else
                {
                    InsertKeyFrame(frameContext as KeyFrameFluentContext<T>);
                }
            }
            KeyFrameContexts.Clear();
        }
        private void InsertActiveKeyFrame()
        {
            var activeKeyFrame = CurrentKeyFrameContext;

            if (activeKeyFrame == null)
            {
                return;
            }

            KeyFrameContexts.Add(activeKeyFrame);

            CurrentKeyFrameContext = null;
        }

                #region TransitionAnimationFluentContext
        /// <summary>
        /// 指定当前动画在故事版开始后的一个延迟时间后执行。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> BeginAfter(TimeSpan time)
        {
            return base.BeginAfter(time) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> Spend(TimeSpan time)
        {
            return base.Spend(time) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> Spend(double millisecond)
        {
            return base.Spend(millisecond) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画的重复次数，-1 为无限重复。
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> Repeat(int times)
        {
            return base.Repeat(times) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画为无限重复。
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> RepeatForever()
        {
            return base.RepeatForever() as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时保持当前值。
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> LeaveCurrentValueWhenStop()
        {
            return base.LeaveCurrentValueWhenStop() as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时设置为初始值。
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetToInitialValueWhenStop()
        {
            return base.SetToInitialValueWhenStop() as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时设置为结束值。
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetToFinalValueWhenStop()
        {
            return base.SetToFinalValueWhenStop() as KeyFrameTransitionAnimationFluentContext<T>;
        }
        #endregion

        #region AnimationFluentContext
        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Color parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Matrix3x2 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Matrix4x4 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Quaternion parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, CompositionObject parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, float parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Vector2 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Vector3 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Vector4 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, bool parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }
#endif
        #endregion
    }
}