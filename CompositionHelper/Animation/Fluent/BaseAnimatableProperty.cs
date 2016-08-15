using System;
using System.Runtime.CompilerServices;

namespace CompositionHelper.Animation.Fluent
{
    public class BaseAnimatableProperty<T> : IAnimatableProperty<T>
    {
        internal BaseAnimatableProperty([CallerMemberName]String propertyPath = null)
        {
            PropertyPath = propertyPath;
        }

        public AnimationTypes AnimationType => GetAnimationType();
        public String PropertyPath { get; }

        protected virtual AnimationTypes GetAnimationType()
        {
            AnimationTypes result;

            if (Enum.TryParse(typeof(T).Name, true, out result))
            {
                return result;
            }
            return AnimationTypes.NotSupport;
        }
    }
}