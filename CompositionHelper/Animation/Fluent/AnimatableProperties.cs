namespace CompositionHelper.Animation.Fluent
{
    /// <summary>
    /// 为可动画属性提供访问。
    /// </summary>
    public static class AnimatableProperties
    {
        public static Vector3BaseAnimatableProperty Offset => new Vector3BaseAnimatableProperty();
        public static Vector2BaseAnimatableProperty AnchorPoint => new Vector2BaseAnimatableProperty();
        public static Vector3BaseAnimatableProperty CenterPoint => new Vector3BaseAnimatableProperty();
        public static Vector3BaseAnimatableProperty Scale => new Vector3BaseAnimatableProperty();
        public static Vector2BaseAnimatableProperty Size => new Vector2BaseAnimatableProperty();
        public static Vector3BaseAnimatableProperty RotationAxis => new Vector3BaseAnimatableProperty();
        public static ScalarBaseAnimatableProperty RotationAngle => new ScalarBaseAnimatableProperty();
        public static ScalarBaseAnimatableProperty RotationAngleInDegrees => new ScalarBaseAnimatableProperty();
        public static QuaternionBaseAnimatableProperty Orientation => new QuaternionBaseAnimatableProperty();
        public static ScalarBaseAnimatableProperty Opacity => new ScalarBaseAnimatableProperty();
        public static ColorBaseAnimatableProperty Color => new ColorBaseAnimatableProperty();
        public static Matrix4x4BaseAnimatableProperty TransformMatrix => new Matrix4x4BaseAnimatableProperty();
    }
}