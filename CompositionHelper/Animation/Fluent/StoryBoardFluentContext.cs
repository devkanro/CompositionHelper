using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using CompositionHelper.Annotations;

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
    }

    /// <summary>
    /// 故事版流式接口上下文。
    /// </summary>
    public class StoryBoardFluentContext
    {
        public StoryBoardFluentContext(Visual target)
        {
            Target = target;
            Batch = Target.Compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
            Batch.Suspend();
            Batch.Completed += OnBatchCompleted;
        }

        private void OnBatchCompleted(object sender, CompositionBatchCompletedEventArgs args)
        {
            _waitHandle.Set();
        }

        private List<AnimationFluentContext> _animations = new List<AnimationFluentContext>();
        private EventWaitHandle _waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

        /// <summary>
        /// 故事版的目标 <see cref="Visual"/>。
        /// </summary>
        public Visual Target { get; private set; }

        public CompositionScopedBatch Batch { get; private set; }

        public IReadOnlyList<AnimationFluentContext> AnimationFluentContexts => _animations;

        /// <summary>
        /// 在指定的属性上开始创建简易动画。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> Animate<T>(IAnimateProperty<T> targetProperty)
        {
            AnimationFluentContext result;

            switch (targetProperty.AnimationType)
            {
                case AnimationTypes.Single:
                    result = new ScalarEasyTransitionAnimationFluentContext(this, Target.Compositor.CreateScalarKeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector2:
                    result = new Vector2EasyTransitionAnimationFluentContext(this, Target.Compositor.CreateVector2KeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector3:
                    result = new Vector3EasyTransitionAnimationFluentContext(this, Target.Compositor.CreateVector3KeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector4:
                    result = new Vector4EasyTransitionAnimationFluentContext(this, Target.Compositor.CreateVector4KeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Color:
                    result = new ColorEasyTransitionAnimationFluentContext(this, Target.Compositor.CreateColorKeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Quaternion:
                    result = new QuaternionEasyTransitionAnimationFluentContext(this, Target.Compositor.CreateQuaternionKeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.NotSupport:
                default:
                    throw new InvalidOperationException("");
            }
        }

        /// <summary>
        /// 在指定的属性上开始创建简易动画。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetPropertyPath"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> Animate<T>(string targetPropertyPath)
        {
            AnimationTypes type = AnimationTypes.NotSupport;
            Enum.TryParse(typeof(T).Name, true, out type);

            AnimationFluentContext result;

            switch (type)
            {
                case AnimationTypes.Single:
                    result = new ScalarEasyTransitionAnimationFluentContext(this, Target.Compositor.CreateScalarKeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector2:
                    result = new Vector2EasyTransitionAnimationFluentContext(this, Target.Compositor.CreateVector2KeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector3:
                    result = new Vector3EasyTransitionAnimationFluentContext(this, Target.Compositor.CreateVector3KeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector4:
                    result = new Vector4EasyTransitionAnimationFluentContext(this, Target.Compositor.CreateVector4KeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Color:
                    result = new ColorEasyTransitionAnimationFluentContext(this, Target.Compositor.CreateColorKeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Quaternion:
                    result = new QuaternionEasyTransitionAnimationFluentContext(this, Target.Compositor.CreateQuaternionKeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (EasyTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.NotSupport:
                default:
                    throw new InvalidOperationException("");
            }
        }

        /// <summary>
        /// 在指定的属性上开始创建基于关键帧的动画。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> AnimateWithKeyFrame<T>(IAnimateProperty<T> targetProperty)
        {
            AnimationFluentContext result;

            switch (targetProperty.AnimationType)
            {
                case AnimationTypes.Single:
                    result = new ScalarKeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateScalarKeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector2:
                    result = new Vector2KeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateVector2KeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector3:
                    result = new Vector3KeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateVector3KeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector4:
                    result = new Vector4KeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateVector4KeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Color:
                    result = new ColorKeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateColorKeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Quaternion:
                    result = new QuaternionKeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateQuaternionKeyFrameAnimation(), targetProperty.PropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.NotSupport:
                default:
                    throw new InvalidOperationException("");
            }
        }

        /// <summary>
        /// 在指定的属性上开始创建基于关键帧的动画。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetPropertyPath"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> AnimateWithKeyFrame<T>(string targetPropertyPath)
        {
            AnimationTypes type = AnimationTypes.NotSupport;
            Enum.TryParse(typeof(T).Name, true, out type);

            AnimationFluentContext result;

            switch (type)
            {
                case AnimationTypes.Single:
                    result = new ScalarKeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateScalarKeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector2:
                    result = new Vector2KeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateVector2KeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector3:
                    result = new Vector3KeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateVector3KeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Vector4:
                    result = new Vector4KeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateVector4KeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Color:
                    result = new ColorKeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateColorKeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.Quaternion:
                    result = new QuaternionKeyFrameTransitionAnimationFluentContext(this, Target.Compositor.CreateQuaternionKeyFrameAnimation(), targetPropertyPath);
                    _animations.Add(result);
                    return (KeyFrameTransitionAnimationFluentContext<T>)result;
                case AnimationTypes.NotSupport:
                default:
                    throw new InvalidOperationException("");
            }
        }

        /// <summary>
        /// 在指定的属性上开始创建基于表达式的动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public ExpressionAnimationFluentContext AnimateWithExpression(IAnimateProperty targetProperty)
        {
            var result = new ExpressionAnimationFluentContext(this, Target.Compositor.CreateExpressionAnimation(), targetProperty.PropertyPath);
            _animations.Add(result);
            return result;
        }

        /// <summary>
        /// 在指定的属性上开始创建基于表达式的动画。
        /// </summary>
        /// <param name="targetPropertyPath"></param>
        /// <returns></returns>
        public ExpressionAnimationFluentContext AnimateWithExpression(string targetPropertyPath)
        {
            var result = new ExpressionAnimationFluentContext(this, Target.Compositor.CreateExpressionAnimation(), targetPropertyPath);
            _animations.Add(result);
            return result;
        }

        /// <summary>
        /// 开始所有创建的动画。
        /// </summary>
        /// <returns></returns>
        public StoryBoardFluentContext Start()
        {
            Batch.Resume();
            foreach (var animationFluentContext in AnimationFluentContexts)
            {
                Target.StartAnimation(animationFluentContext.TargetProperty, animationFluentContext.CompositionAnimation);
            }
            Batch.End();
            return this;
        }

        /// <summary>
        /// 停止所有创建的动画。
        /// </summary>
        /// <returns></returns>
        public StoryBoardFluentContext Stop()
        {
            foreach (var animationFluentContext in AnimationFluentContexts)
            {
                Target.StopAnimation(animationFluentContext.TargetProperty);
            }
            return this;
        }

        /// <summary>
        /// 异步等待动画 完成。
        /// </summary>
        /// <returns></returns>
        public IAsyncOperation<StoryBoardFluentContext> Wait()
        {
            return Task.Run(() =>
            {
                _waitHandle.WaitOne();
                return this;
            }).AsAsyncOperation();
        }
    }

}
