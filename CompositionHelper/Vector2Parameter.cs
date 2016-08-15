using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    /// <summary>
    /// 二维矢量参数。
    /// </summary>
    public class Vector2Parameter : Parameter<Vector2>
    {
        /// <summary>
        /// 为动画添加参数。
        /// </summary>
        /// <param name="animation"></param>
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetVector2Parameter(Key, ObjectValue);
        }

        protected override Vector2 ValueToObject(string value)
        {
            return value.ToVector2();
        }
    }
}