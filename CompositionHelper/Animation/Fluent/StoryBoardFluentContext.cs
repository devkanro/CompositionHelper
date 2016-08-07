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
        public static StoryBoardFluentContext StartBuildAnimation([NotNull]this Visual target)
        {
            return new StoryBoardFluentContext(target);
        }
    }

    public class StoryBoardFluentContext
    {
        public StoryBoardFluentContext(Visual target)
        {
            Target = target;
            Storyboard = new Storyboard();
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

        public Visual Target { get; private set; }

        public Storyboard Storyboard { get; private set; }

        public CompositionScopedBatch Batch { get; private set; }

        public IReadOnlyList<AnimationFluentContext> AnimationFluentContexts => _animations;

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

        public ExpressionAnimationFluentContext AnimateWithExpression(IAnimateProperty targetProperty)
        {
            var result = new ExpressionAnimationFluentContext(this, Target.Compositor.CreateExpressionAnimation(), targetProperty.PropertyPath);
            _animations.Add(result);
            return result;
        }

        public ExpressionAnimationFluentContext AnimateWithExpression(string targetPropertyPath)
        {
            var result = new ExpressionAnimationFluentContext(this, Target.Compositor.CreateExpressionAnimation(), targetPropertyPath);
            _animations.Add(result);
            return result;
        }

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

        public StoryBoardFluentContext Stop()
        {
            foreach (var animationFluentContext in AnimationFluentContexts)
            {
                Target.StopAnimation(animationFluentContext.TargetProperty);
            }
            return this;
        }

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
