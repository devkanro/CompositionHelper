namespace CompositionHelper.Animation.Fluent
{
    /// <summary>
    /// 为可动画属性提供访问。
    /// </summary>
    public static class AnimateProperties
    {
        public static Vector3BaseAnimateProperty Offset => new Vector3BaseAnimateProperty();
        public static Vector2BaseAnimateProperty AnchorPoint => new Vector2BaseAnimateProperty();
        public static Vector3BaseAnimateProperty CenterPoint => new Vector3BaseAnimateProperty();
        public static Vector3BaseAnimateProperty Scale => new Vector3BaseAnimateProperty();
        public static Vector2BaseAnimateProperty Size => new Vector2BaseAnimateProperty();
        public static Vector3BaseAnimateProperty RotationAxis => new Vector3BaseAnimateProperty();
        public static ScalarBaseAnimateProperty RotationAngle => new ScalarBaseAnimateProperty();
        public static ScalarBaseAnimateProperty RotationAngleInDegrees => new ScalarBaseAnimateProperty();
        public static QuaternionBaseAnimateProperty Orientation => new QuaternionBaseAnimateProperty();
        public static ScalarBaseAnimateProperty Opacity => new ScalarBaseAnimateProperty();
        public static ColorBaseAnimateProperty Color => new ColorBaseAnimateProperty();
        public static Matrix4x4BaseAnimateProperty TransformMatrix => new Matrix4x4BaseAnimateProperty();
    }
}