using System;
using Windows.UI.Composition;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// 表示动画的缓动函数。
    /// </summary>
    public abstract class EasingFunction
    {
        protected EasingFunction()
        {
        }

        /// <summary>
        /// 创建用于 Composition API 的 CompositionEasingFunction。
        /// </summary>
        /// <param name="compositor"></param>
        /// <returns></returns>
        public virtual CompositionEasingFunction CreateCompositionEasingFunction(Compositor compositor)
        {
            throw new NotImplementedException("未提供创建 CompositionEasingFunction 的方法。");
        }
    }
}