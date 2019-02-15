using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows.Media;

namespace BehaviorInvestigation.Behviors
{
    public class ChangeColorAtClickBehavior : Behavior<Control>
    {
        private Brush _originalBrush;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.KeyDown += AssociatedObject_KeyDown;
            AssociatedObject.KeyUp += AssociatedObject_KeyUp;
        }

        private void AssociatedObject_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.LeftCtrl || e.Key == System.Windows.Input.Key.RightCtrl)
            {
                AssociatedObject.Background = _originalBrush;
            }
        }

        private void AssociatedObject_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.LeftCtrl || e.Key == System.Windows.Input.Key.RightCtrl)
            {
                _originalBrush = AssociatedObject.Background;
                AssociatedObject.Background = new SolidColorBrush(Colors.Green);
            }
        }
    }
}
