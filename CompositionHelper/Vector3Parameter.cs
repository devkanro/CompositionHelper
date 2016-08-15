using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    /// <summary>
    /// 三维矢量参数。
    /// </summary>
    public class Vector3Parameter : Parameter<Vector3>
    {
        /// <summary>
        /// 为动画添加参数。
        /// </summary>
        /// <param name="animation"></param>
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetVector3Parameter(Key, ObjectValue);
        }

        protected override Vector3 ValueToObject(string value)
        {
            return value.ToVector3();
        }
    }
}