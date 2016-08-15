using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    /// <summary>
    /// 引用参数。
    /// </summary>
    public class ReferenceParameter : Parameter<CompositionObject>
    {
        private CompositionObject _value;
        private UIElement _target;

        /// <summary>
        /// 设置需要创建引用参数的对象。
        /// </summary>
        public UIElement Target
        {
            get { return _target; }
            set
            {
                if (value != null)
                {
                    _target = value;
                    switch (CreateMode)
                    {
                        case ReferenceParameterCreateMode.Visual:
                            _value = ElementCompositionPreview.GetElementVisual(value);
                            break;

                        case ReferenceParameterCreateMode.ScrollViewerManipulationPropertySet:
                            ScrollViewer scrollViewer = value is ScrollViewer ? value as ScrollViewer : VisualTreeHelper.FindVisualElement<ScrollViewer>(value);
                            if (scrollViewer != null)
                            {
                                _value = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(scrollViewer);
                            }
                            else
                            {
                                throw new InvalidOperationException("创建 ScrollViewerManipulationPropertySet 时，对象必须是 ScrollViewer 或者包含 ScrollViewer 的 UI 元素。");
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 获取或设置创建引用对象的方式。
        /// </summary>
        public ReferenceParameterCreateMode CreateMode { get; set; }

        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetReferenceParameter(Key, ObjectValue);
        }

        protected override CompositionObject ValueToObject(string value)
        {
            return _value;
        }
    }
}