using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;

namespace CompositionHelper.Animation.Fluent
{
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
            Completed?.Invoke(this, new EventArgs());
        }

        private List<AnimationFluentContext> _animations = new List<AnimationFluentContext>();
        private EventWaitHandle _waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

        public event EventHandler Completed;

        /// <summary>
        /// 故事版的目标 <see cref="Visual"/>。
        /// </summary>
        public Visual Target { get; private set; }

        public CompositionScopedBatch Batch { get; private set; }

        public IReadOnlyList<AnimationFluentContext> AnimationFluentContexts => _animations;

        /// <summary>
        /// 在指定的属性上开始创建简易动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public ScalarEasyTransitionAnimationFluentContext Animate(IAnimatableProperty<float> targetProperty)
        {
            return Animate<float>(targetProperty) as ScalarEasyTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建简易动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public Vector2EasyTransitionAnimationFluentContext Animate(IAnimatableProperty<Vector2> targetProperty)
        {
            return Animate<Vector2>(targetProperty) as Vector2EasyTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建简易动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public Vector3EasyTransitionAnimationFluentContext Animate(IAnimatableProperty<Vector3> targetProperty)
        {
            return Animate<Vector3>(targetProperty) as Vector3EasyTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建简易动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public Vector4EasyTransitionAnimationFluentContext Animate(IAnimatableProperty<Vector4> targetProperty)
        {
            return Animate<Vector4>(targetProperty) as Vector4EasyTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建简易动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public ColorEasyTransitionAnimationFluentContext Animate(IAnimatableProperty<Color> targetProperty)
        {
            return Animate<Color>(targetProperty) as ColorEasyTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建简易动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public QuaternionEasyTransitionAnimationFluentContext Animate(IAnimatableProperty<Quaternion> targetProperty)
        {
            return Animate<Quaternion>(targetProperty) as QuaternionEasyTransitionAnimationFluentContext;
        }

        protected EasyTransitionAnimationFluentContext<T> Animate<T>(IAnimatableProperty<T> targetProperty)
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
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public ScalarKeyFrameTransitionAnimationFluentContext AnimateWithKeyFrame(IAnimatableProperty<float> targetProperty)
        {
            return AnimateWithKeyFrame<float>(targetProperty) as ScalarKeyFrameTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建基于关键帧的动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public Vector2KeyFrameTransitionAnimationFluentContext AnimateWithKeyFrame(IAnimatableProperty<Vector2> targetProperty)
        {
            return AnimateWithKeyFrame<Vector2>(targetProperty) as Vector2KeyFrameTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建基于关键帧的动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public Vector3KeyFrameTransitionAnimationFluentContext AnimateWithKeyFrame(IAnimatableProperty<Vector3> targetProperty)
        {
            return AnimateWithKeyFrame<Vector3>(targetProperty) as Vector3KeyFrameTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建基于关键帧的动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public Vector4KeyFrameTransitionAnimationFluentContext AnimateWithKeyFrame(IAnimatableProperty<Vector4> targetProperty)
        {
            return AnimateWithKeyFrame<Vector4>(targetProperty) as Vector4KeyFrameTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建基于关键帧的动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public ColorKeyFrameTransitionAnimationFluentContext AnimateWithKeyFrame(IAnimatableProperty<Color> targetProperty)
        {
            return AnimateWithKeyFrame<Color>(targetProperty) as ColorKeyFrameTransitionAnimationFluentContext;
        }

        /// <summary>
        /// 在指定的属性上开始创建基于关键帧的动画。
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        public QuaternionKeyFrameTransitionAnimationFluentContext AnimateWithKeyFrame(IAnimatableProperty<Quaternion> targetProperty)
        {
            return AnimateWithKeyFrame<Quaternion>(targetProperty) as QuaternionKeyFrameTransitionAnimationFluentContext;
        }
        
        /// <summary>
        /// 在指定的属性上开始创建基于关键帧的动画。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetProperty"></param>
        /// <returns></returns>
        protected KeyFrameTransitionAnimationFluentContext<T> AnimateWithKeyFrame<T>(IAnimatableProperty<T> targetProperty)
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
        public ExpressionAnimationFluentContext AnimateWithExpression(IAnimatableProperty targetProperty)
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
