using Interpretap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RateUserView : ContentPage
    {
        RateUserViewModel VM;

        public RateUserView(RateUserViewModel vm)
        {
            InitializeComponent();
            VM = vm;
            VM.PropertyChanged += VM_PropertyChanged;
            this.BindingContext = VM;

            DrawStars(0);
        }

        private void VM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(VM.Rating))
            {
                DrawStars(int.Parse(VM.Rating));
            }
        }

        private void DrawStars(int rating)
        {
            var maxRating = 5;
            var emptyStarFileName = "staroutline.png";
            var solidStarFileName = "starfilled.png";

            StarsView.Children.Clear();

            for (int i = 0; i < maxRating; i++)
            {
                var star = new Image();
                if (i<rating)
                {
                    star.Source = ImageSource.FromFile(solidStarFileName);
                }
                else
                {
                    star.Source = ImageSource.FromFile(emptyStarFileName);
                }

                var tgr = new TapGestureRecognizer();
                var r = (i+1).ToString();
                tgr.Tapped += (s, e) => { VM.Rating = r; };
                star.GestureRecognizers.Add(tgr);

                StarsView.Children.Add(star);
            }
        }
    }
}