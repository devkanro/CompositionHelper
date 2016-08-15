using System;

namespace CompositionHelper.Annotations
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class RazorWriteMethodParameterAttribute : Attribute { }
}