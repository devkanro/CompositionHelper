using System;

namespace CompositionHelper.Annotations
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class HtmlElementAttributesAttribute : Attribute
    {
        public HtmlElementAttributesAttribute()
        {
        }

        public HtmlElementAttributesAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}