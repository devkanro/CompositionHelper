using System;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public abstract class EasyTransitionAnimationFluentContext<T> : TransitionAnimationFluentContext
    {
        internal EasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {

        }

        protected IKeyFrameFluentContext FromKeyFrameContext { get; private set; }
        protected IKeyFrameFluentContext ToKeyFrameContext { get; private set; }


        /// <summary>
        /// 为当前帧创建一个线性缓动。
        /// </summary>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> WithLinerEasing()
        {
            ToKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateLinearEasingFunction();
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
            ToKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateCubicBezierEasingFunction(point1.ToVector2(), point2.ToVector2());
            return this;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]为当前帧创建一个基于步数的缓动。
        /// </summary>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> WithStepEasing(int stepCount)
        {
            ToKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateStepEasingFunction(stepCount);
            return this;
        }
#endif

        protected override void OnAnimationBuildOver()
        {
            base.OnAnimationBuildOver();
            InsertActiveKeyFrameToAnimation();
        }

        protected abstract void InsertKeyFrame(KeyFrameFluentContext<T> keyFrameContext);
        protected abstract void InsertExpressionKeyFrame(ExpressionKeyFrameFluentContext keyFrameContext);

        private void InsertActiveKeyFrameToAnimation()
        {
            if (FromKeyFrameContext != null)
            {
                if (FromKeyFrameContext is ExpressionKeyFrameFluentContext)
                {
                    InsertExpressionKeyFrame(FromKeyFrameContext as ExpressionKeyFrameFluentContext);
                }
                else
                {
                    InsertKeyFrame(FromKeyFrameContext as KeyFrameFluentContext<T>);
                }
            }

            if (ToKeyFrameContext != null)
            {
                if (ToKeyFrameContext is ExpressionKeyFrameFluentContext)
                {
                    InsertExpressionKeyFrame(ToKeyFrameContext as ExpressionKeyFrameFluentContext);
                }
                else
                {
                    InsertKeyFrame(ToKeyFrameContext as KeyFrameFluentContext<T>);
                }
            }
        }

        /// <summary>
        /// 指定动画开始的值。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> From(T value)
        {
            if (FromKeyFrameContext != null)
            {
                throw new InvalidOperationException("From 已经被指定。");
            }

            FromKeyFrameContext = new KeyFrameFluentContext<T>
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
            if (ToKeyFrameContext != null)
            {
                throw new InvalidOperationException("To 已经被指定。");
            }

            ToKeyFrameContext = new KeyFrameFluentContext<T>
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
            if (FromKeyFrameContext != null)
            {
                throw new InvalidOperationException("From 已经被指定。");
            }

            FromKeyFrameContext = new ExpressionKeyFrameFluentContext
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
            if (ToKeyFrameContext != null)
            {
                throw new InvalidOperationException("To 已经被指定。");
            }

            ToKeyFrameContext = new ExpressionKeyFrameFluentContext()
            {
                Value = expression,
                Progress = 1
            };
            return this;
        }

        #region TransitionAnimationFluentContext
        /// <summary>
        /// 指定当前动画在故事版开始后的一个延迟时间后执行。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> BeginAfter(TimeSpan time)
        {
            return base.BeginAfter(time) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> Spend(TimeSpan time)
        {
            return base.Spend(time) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定当前动画所花费的时间。
        /// </summary>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> Spend(double millisecond)
        {
            return base.Spend(millisecond) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画的重复次数，-1 为无限重复。
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> Repeat(int times)
        {
            return base.Repeat(times) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画为无限重复。
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> RepeatForever()
        {
            return base.RepeatForever() as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时保持当前值。
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> LeaveCurrentValueWhenStop()
        {
            return base.LeaveCurrentValueWhenStop() as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时设置为初始值。
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetToInitialValueWhenStop()
        {
            return base.SetToInitialValueWhenStop() as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 指定动画在结束时设置为结束值。
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetToFinalValueWhenStop()
        {
            return base.SetToFinalValueWhenStop() as EasyTransitionAnimationFluentContext<T>;
        }
        #endregion

        #region AnimationFluentContext
        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Color parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Matrix3x2 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Matrix4x4 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Quaternion parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, CompositionObject parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, float parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Vector2 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Vector3 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Vector4 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, bool parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }
#endif
        #endregion
    }
}