using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    /// <summary>
    /// 4x4¾ØÕó²ÎÊý¡£
    /// </summary>
    public class Matrix4x4Parameter : Parameter<Matrix4x4>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetMatrix4x4Parameter(Key, ObjectValue);
        }

        protected override Matrix4x4 ValueToObject(string value)
        {
            return value.ToMatrix4x4();
        }
    }
}