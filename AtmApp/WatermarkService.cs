using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace AtmApp
{
    public static class WatermarkService
    {
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
            "Watermark", typeof(object), typeof(WatermarkService), new FrameworkPropertyMetadata(null, OnWatermarkChanged));

        public static object GetWatermark(DependencyObject d)
        {
            return d.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject d, object value)
        {
            d.SetValue(WatermarkProperty, value);
        }

        private static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Control control)
            {
                control.Loaded += Control_Loaded;
                if (d is TextBox textBox)
                {
                    textBox.TextChanged += (sender, args) => ShowHideWatermark(control);
                }
                else if (d is PasswordBox passwordBox)
                {
                    passwordBox.PasswordChanged += (sender, args) => ShowHideWatermark(control);
                }
            }
        }

        private static void Control_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Control control)
            {
                ShowHideWatermark(control);
            }
        }

        private static void ShowHideWatermark(Control control)
        {
            if (control is TextBox textBox)
            {
                SetWatermarkVisibility(control, string.IsNullOrEmpty(textBox.Text));
            }
            else if (control is PasswordBox passwordBox)
            {
                SetWatermarkVisibility(control, string.IsNullOrEmpty(passwordBox.Password));
            }
        }

        private static void SetWatermarkVisibility(Control control, bool isWatermarkVisible)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(control);
            Adorner[] adorners = layer.GetAdorners(control);

            if (isWatermarkVisible)
            {
                if (adorners == null)
                {
                    layer.Add(new WatermarkAdorner(control, GetWatermark(control)));
                }
            }
            else
            {
                if (adorners != null)
                {
                    foreach (Adorner adorner in adorners)
                    {
                        if (adorner is WatermarkAdorner)
                        {
                            adorner.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
        }
    }
}
