using System;

namespace CompositionHelper.Annotations
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RazorWriteLiteralMethodAttribute : Attribute { }
}