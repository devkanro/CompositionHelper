using System;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public abstract class KeyFrameTransitionAnimationWithKindFluentContext<T> :
        KeyFrameTransitionAnimationFluentContext<T>
    {
        internal KeyFrameTransitionAnimationWithKindFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected TransitionAnimationKind AnimationKind { get; set; }
        /// <summary>
        /// 指定动画是以相对值进行动画。
        /// </summary>
        /// <returns></returns>
        public KeyFrameTransitionAnimationWithKindFluentContext<T> RelativeBased()
        {
            AnimationKind = TransitionAnimationKind.Relative;
            return this;
        }

        /// <summary>
        /// [SDK14393+]指定动画是以绝对值进行动画。
        /// </summary>
        /// <returns></returns>
        public KeyFrameTransitionAnimationWithKindFluentContext<T> AbsolutelyBased()
        {
            AnimationKind = TransitionAnimationKind.Absolute;
            return this;
        }

        #region TransitionAnimationFluentContext
        /// <summary>
        /// 指定当前动画在故事版开始后的一个延迟时间后执行。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> BeginAfter(TimeSpan time)
        {
            return base.BeginAfter(time) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> Spend(TimeSpan time)
        {
            return base.Spend(time) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> Spend(double millisecond)
        {
            return base.Spend(millisecond) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画的重复次数，-1 为无限重复。
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> Repeat(int times)
        {
            return base.Repeat(times) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画为无限重复。
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> RepeatForever()
        {
            return base.RepeatForever() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时保持当前值。
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> LeaveCurrentValueWhenStop()
        {
            return base.LeaveCurrentValueWhenStop() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时设置为初始值。
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetToInitialValueWhenStop()
        {
            return base.SetToInitialValueWhenStop() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时设置为结束值。
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetToFinalValueWhenStop()
        {
            return base.SetToFinalValueWhenStop() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }
        #endregion

        #region AnimationFluentContext
        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Color parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Matrix3x2 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Matrix4x4 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Quaternion parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, CompositionObject parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, float parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector2 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector3 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector4 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, bool parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }
#endif
        #endregion

        #region EasyTransitionAnimationFluentContext
        /// <summary>
        /// 插入一个表达式帧，并提交上一帧。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> ExpressionKeyFrame(String expression)
        {
            return base.ExpressionKeyFrame(expression) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 插入一个关键帧，并提交上一帧。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> KeyFrame(T value)
        {
            return base.KeyFrame(value) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 关键帧所处的进度。
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> At(float progress)
        {
            return base.At(progress) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 为当前帧创建一个线性缓动。
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> WithLinerEasing()
        {
            return base.WithLinerEasing() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 为当前帧创建一个基于贝塞尔曲线的缓动。
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> WithCubicBezierEasing(Point point1, Point point2)
        {
            return base.WithCubicBezierEasing(point1, point2) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]为当前帧创建一个基于步数的缓动。
        /// </summary>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> WithStepEasing(int stepCount)
        {
            return base.WithStepEasing(stepCount) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }
#endif
        #endregion
    }
}