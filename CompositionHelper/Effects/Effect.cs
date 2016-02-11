using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace CompositionHelper.Effects
{
    public abstract class Effect : DependencyObject
    {
        protected UIElement Target { get; set; }

        public EffectContext Context
        {
            get
            {
                if (Target == null)
                {
                    return null;
                }

                return GetContext(Target) ?? EffectContext.CreateEffectContext(Target);
            }
        }

        public static readonly DependencyProperty ShadowEffectProperty = DependencyProperty.RegisterAttached(
            "ShadowEffect", typeof(ShadowEffect), typeof(UIElement), new PropertyMetadata(default(ShadowEffect)));

        public static void SetShadowEffect(DependencyObject element, ShadowEffect value)
        {
            var oldValue = GetShadowEffect(element);
            if (oldValue != null)
            {
                oldValue.DeattacheToElement();
                oldValue.Target = null;
            }
            if (value != null)
            {
                value.Target = element as UIElement;
                value.AttacheToElement();
            }
            element.SetValue(ShadowEffectProperty, value);
        }

        public static ShadowEffect GetShadowEffect(DependencyObject element)
        {
            return (ShadowEffect)element.GetValue(ShadowEffectProperty);
        }

        internal static readonly DependencyProperty ContextProperty = DependencyProperty.RegisterAttached(
            "Context", typeof(EffectContext), typeof(UIElement), new PropertyMetadata(default(EffectContext)));

        internal static void SetContext(DependencyObject element, EffectContext value)
        {
            element.SetValue(ContextProperty, value);
        }

        internal static EffectContext GetContext(DependencyObject element)
        {
            return (EffectContext)element.GetValue(ContextProperty);
        }
        
        protected virtual void AttacheToElement()
        {
            
        }

        protected virtual void DeattacheToElement()
        {
            
        }

        protected virtual void RemoveEffect()
        {
            
        }

        protected virtual void RedrawEffect()
        {
            
        }

        protected virtual void BuildEffect()
        {

        }
    }
}
