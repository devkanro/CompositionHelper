using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionHelper.Animation.Fluent
{
    public enum AnimationTypes
    {
        NotSupport = -1,
        Single,
        Scalar = Single,
        Vector2,
        Vector3,
        Vector4,
        Color,
        Quaternion,
    }
}
