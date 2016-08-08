using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class AnimationFluentContext
    {
        internal AnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] CompositionAnimation animation, [NotNull] String targetProperty)
        {
            Parent = new WeakReference<StoryBoardFluentContext>(parentStoryBoard);
            CompositionAnimation = animation;
            TargetProperty = targetProperty;
        }

        protected WeakReference<StoryBoardFluentContext> Parent { get; }
        public CompositionAnimation CompositionAnimation { get; }
        public String TargetProperty { get; }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, Color parameter)
        {
            CompositionAnimation.SetColorParameter(key, parameter);
            return this;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, Matrix3x2 parameter)
        {
            CompositionAnimation.SetMatrix3x2Parameter(key, parameter);
            return this;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, Matrix4x4 parameter)
        {
            CompositionAnimation.SetMatrix4x4Parameter(key, parameter);
            return this;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, Quaternion parameter)
        {
            CompositionAnimation.SetQuaternionParameter(key, parameter);
            return this;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, CompositionObject parameter)
        {
            CompositionAnimation.SetReferenceParameter(key, parameter);
            return this;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, float parameter)
        {
            CompositionAnimation.SetScalarParameter(key, parameter);
            return this;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, Vector2 parameter)
        {
            CompositionAnimation.SetVector2Parameter(key, parameter);
            return this;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, Vector3 parameter)
        {
            CompositionAnimation.SetVector3Parameter(key, parameter);
            return this;
        }

        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, Vector4 parameter)
        {
            CompositionAnimation.SetVector4Parameter(key, parameter);
            return this;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// 将一个参数加入动画。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AnimationFluentContext SetParameter(string key, bool parameter)
        {
            CompositionAnimation.SetBooleanParameter(key, parameter);
            return this;
        }
#endif

        /// <summary>
        /// 结束当前动画的构建，返回到故事版上下文。
        /// </summary>
        public StoryBoardFluentContext Over()
        {
            OnAnimationBuildOver();
            StoryBoardFluentContext parent = null;
            if (Parent.TryGetTarget(out parent))
            {
                return parent;
            }

            throw new MemberAccessException("The parent context has been collected.");
        }

        protected virtual void OnAnimationBuildOver()
        {
        }
    }
}