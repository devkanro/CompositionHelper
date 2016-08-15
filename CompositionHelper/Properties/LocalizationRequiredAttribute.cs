using System;

namespace CompositionHelper.Annotations
{
    /// <summary>
    /// Indicates that marked element should be localized or not.
    /// </summary>
    /// <example><code>
    /// [LocalizationRequiredAttribute(true)]
    /// public class Foo {
    ///   private string str = "my string"; // Warning: Localizable string
    /// }
    /// </code></example>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class LocalizationRequiredAttribute : Attribute
    {
        public LocalizationRequiredAttribute() : this(true)
        {
        }

        public LocalizationRequiredAttribute(bool required)
        {
            Required = required;
        }

        public bool Required { get; private set; }
    }
}