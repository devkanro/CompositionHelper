using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;

namespace CompositionHelper.Animation
{
    internal class AnimationBatchFactory
    {
        private AnimationBatchFactory()
        {
            
        }

        private Object Locker { get; } = new object();

        internal static AnimationBatchFactory Singleton { get; } = new AnimationBatchFactory();

        internal CompositionScopedBatch StartAnimations(AnimationCollection target)
        {
            lock (Locker)
            {
                Compositor compositor = target?.FirstOrDefault()?.TargetVisual?.Compositor;

                if (compositor == null)
                {
                    return null;
                }

                CompositionScopedBatch resultBatch = compositor.CreateScopedBatch(CompositionBatchTypes.Animation);

                foreach (var animation in target)
                {
                    animation.TargetVisual.StartAnimation(animation.TargetProperty.ToString(), animation.BuildCompositionAnimation());
                }

                resultBatch.End();

                return resultBatch;
            }
        }
    }
}
