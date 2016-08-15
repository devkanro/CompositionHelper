namespace CompositionHelper.Animation.Fluent
{
    /// <summary>
    /// [SDK14393+]变换动画种类，相对动画与绝对动画，在 SDK 版本低于 14393 时所有的动画都是相对的。
    /// </summary>
    public enum TransitionAnimationKind
    {
        /// <summary>
        /// 相对动画表示当前动画以自身当前值为原点进行，该值是默认值。
        /// </summary>
        Relative,
        /// <summary>
        /// [SDK14393+]绝对动画表示当前的动画以绝对值进行动画，仅在 SDK 版本高于 14393 有效。
        /// </summary>
        Absolute
    }
}