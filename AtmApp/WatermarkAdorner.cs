using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace AtmApp
{
    public class WatermarkAdorner : Adorner
    {
        private readonly ContentPresenter _contentPresenter;

        public WatermarkAdorner(UIElement adornedElement, object watermark) : base(adornedElement)
        {
            _contentPresenter = new ContentPresenter();
            _contentPresenter.Content = watermark;
            _contentPresenter.Opacity = 0.5;
            _contentPresenter.Margin = new Thickness(Control.Margin.Left + Control.Padding.Left,
                                                     Control.Margin.Top + Control.Padding.Top, 0, 0);

            if (Control is ItemsControl && !(Control is ComboBox))
            {
                _contentPresenter.VerticalAlignment = VerticalAlignment.Center;
                _contentPresenter.HorizontalAlignment = HorizontalAlignment.Center;
            }

            this.IsHitTestVisible = false;

            adornedElement.GotFocus += (sender, args) => { this.Visibility = Visibility.Hidden; };
            adornedElement.LostFocus += (sender, args) => { this.Visibility = IsControlEmpty() ? Visibility.Visible : Visibility.Hidden; };
        }

        private Control Control => (Control)this.AdornedElement;

        protected override int VisualChildrenCount => 1;

        protected override Visual GetVisualChild(int index)
        {
            return _contentPresenter;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _contentPresenter.Arrange(new Rect(finalSize));
            return finalSize;
        }

        private bool IsControlEmpty()
        {
            if (Control is TextBox textBox)
            {
                return string.IsNullOrEmpty(textBox.Text);
            }
            if (Control is PasswordBox passwordBox)
            {
                return string.IsNullOrEmpty(passwordBox.Password);
            }
            return false;
        }
    }
}
