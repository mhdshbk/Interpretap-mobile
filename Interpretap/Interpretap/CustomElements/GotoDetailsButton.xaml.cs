using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.CustomElements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GotoDetailsButton : ContentView
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(GotoDetailsButton),
            null,
            propertyChanged: CommandPropertyChanged
            );

        private static void CommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as GotoDetailsButton;
            if (control == null) return;

            control.btn.Command = (ICommand)newValue;
        }

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                if (Command == value) return;
                SetValue(CommandProperty, value);
            }
        }

        public string Text
        {
            get => lbl.Text;
            set => lbl.Text = value;
        }

        public GotoDetailsButton()
        {
            InitializeComponent();
        }
    }
}