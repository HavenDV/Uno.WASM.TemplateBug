using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

#nullable enable

namespace Dedoose.Extensions
{
    public static class ResizeExtensions
    {
        #region AttachedProperty : Target

        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.RegisterAttached(
                nameof(TargetProperty).Replace("Property", string.Empty),
                typeof(object),
                typeof(ResizeExtensions),
                new PropertyMetadata(null, OnTargetChanged));

        public static object? GetTarget(DependencyObject element)
        {
            return element.GetValue(TargetProperty);
        }

        public static void SetTarget(DependencyObject element, object? value)
        {
            element.SetValue(TargetProperty, value);
        }

        private static void OnTargetChanged(
            DependencyObject element,
            DependencyPropertyChangedEventArgs args)
        {
            if (element is not Thumb thumb)
            {
                return;
            }

            if (args.NewValue != null)
            {
                thumb.DragDelta += Thumb_DragDelta;
            }
            else
            {
                thumb.DragDelta -= Thumb_DragDelta;
            }
        }

        private static void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is not Thumb thumb ||
                GetTarget(thumb) is not FrameworkElement obj)
            {
                return;
            }

            obj.SetValue(
                FrameworkElement.WidthProperty,
                Math.Max(0.0, obj.ActualWidth + e.HorizontalChange));
            obj.SetValue(
                FrameworkElement.HeightProperty,
                Math.Max(0.0, obj.ActualHeight + e.VerticalChange));
        }

        #endregion
    }
}
