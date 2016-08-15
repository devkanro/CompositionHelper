using System;

namespace CompositionHelper.Animation.Fluent
{
    public interface IAnimatableProperty
    {
        AnimationTypes AnimationType { get; }

        String PropertyPath { get; }
    }

    public interface IAnimatableProperty<T> : IAnimatableProperty
    {
    }
}
