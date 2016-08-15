using System;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public abstract class EasyTransitionAnimationWithKindFluentContext<T> : EasyTransitionAnimationFluentContext<T>
    {
        internal EasyTransitionAnimationWithKindFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected TransitionAnimationKind AnimationKind { get; set; }

        /// <summary>
        /// 指定动画是以相对值进行动画。
        /// </summary>
        /// <returns></returns>
        public EasyTransitionAnimationWithKindFluentContext<T> RelativeBased()
        {
            AnimationKind = TransitionAnimationKind.Relative;
            return this;
        }

        /// <summary>
        /// [SDK14393+]指定动画是以绝对值进行动画。
        /// </summary>
        /// <returns></returns>
        public EasyTransitionAnimationWithKindFluentContext<T> AbsolutelyBased()
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
        public new EasyTransitionAnimationWithKindFluentContext<T> BeginAfter(TimeSpan time)
        {
            return base.BeginAfter(time) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> Spend(TimeSpan time)
        {
            return base.Spend(time) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> Spend(double millisecond)
        {
            return base.Spend(millisecond) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画的重复次数，-1 为无限重复。
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> Repeat(int times)
        {
            return base.Repeat(times) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画为无限重复。
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> RepeatForever()
        {
            return base.RepeatForever() as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时保持当前值。
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> LeaveCurrentValueWhenStop()
        {
            return base.LeaveCurrentValueWhenStop() as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时设置为初始值。
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetToInitialValueWhenStop()
        {
            return base.SetToInitialValueWhenStop() as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时设置为结束值。
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetToFinalValueWhenStop()
        {
            return base.SetToFinalValueWhenStop() as EasyTransitionAnimationWithKindFluentContext<T>;
        }
        #endregion

        #region AnimationFluentContext
        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Color parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Matrix3x2 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Matrix4x4 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Quaternion parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, CompositionObject parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, float parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector2 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector3 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector4 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, bool parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }
#endif
        #endregion

        #region EasyTransitionAnimationFluentContext
        /// <summary>
        /// 指定动画开始的值。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> From(T value)
        {
            return base.From(value) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 指定动画结束的值。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> To(T value)
        {
            return base.To(value) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 通过表达式指定动画开始的值。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> FromExpression(String expression)
        {
            return base.FromExpression(expression) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 通过表达式指定动画结束的值
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> ToExpression(String expression)
        {
            return base.ToExpression(expression) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 为当前帧创建一个线性缓动。
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> WithLinerEasing()
        {
            return base.WithLinerEasing() as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// 为当前帧创建一个基于贝塞尔曲线的缓动。
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> WithCubicBezierEasing(Point point1, Point point2)
        {
            return base.WithCubicBezierEasing(point1, point2) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]为当前帧创建一个基于步数的缓动。
        /// </summary>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> WithStepEasing(int stepCount)
        {
            return base.WithStepEasing(stepCount) as EasyTransitionAnimationWithKindFluentContext<T>;
        }
#endif
        #endregion
    }
}