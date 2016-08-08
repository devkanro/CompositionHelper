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

        public static EasyTransitionAnimationFluentContext<Color> From(this EasyTransitionAnimationFluentContext<Color> animationFluentContext,byte a, byte r, byte g, byte b)
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
