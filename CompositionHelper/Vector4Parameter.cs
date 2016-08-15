using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    /// <summary>
    /// 四维矢量参数。
    /// </summary>
    public class Vector4Parameter : Parameter<Vector4>
    {
        /// <summary>
        /// 为动画添加参数。
        /// </summary>
        /// <param name="animation"></param>
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetVector4Parameter(Key, ObjectValue);
        }

        protected override Vector4 ValueToObject(string value)
        {
            return value.ToVector4();
        }
    }
}