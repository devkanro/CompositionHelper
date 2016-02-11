using System;
using Windows.UI.Composition;

namespace CompositionHelper
{
    /// <summary>
    /// 参数。
    /// </summary>
    public abstract class Parameter
    {
        /// <summary>
        /// 参数名。
        /// </summary>
        public string Key { get; set; }

        public String Value { get; set; }

        public virtual void AddParameterToAnimation(CompositionAnimation animation)
        {
            throw new NotImplementedException("为提供加入参数的方法。");
        }
    }

    /// <summary>
    /// 泛型参数。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Parameter<T> : Parameter
    {
        /// <summary>
        /// 参数值。
        /// </summary>
        public T ObjectValue => ValueToObject(Value);

        protected virtual T ValueToObject(String value)
        {
            throw new NotImplementedException("未提供转换方法。");
        }
    }
}