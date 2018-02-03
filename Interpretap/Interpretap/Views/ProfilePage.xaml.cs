using Interpretap.CustomElements;
using Interpretap.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        bool _selectorExpanded;

        public ProfileViewModel ProfileViewModel { get; set; }

        public ProfilePage()
        {
            InitializeComponent();
            ProfileViewModel = new ProfileViewModel();
            this.BindingContext = ProfileViewModel;

            CalculateProfilesListHeight();
            SetProfileViewToContent();
            InitProfileSelectorOverlay();
        }

        private void InitProfileSelectorOverlay()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s,e) => ToggleSelectorExpanded();
            ProfileSelectorOverlay.GestureRecognizers.Add(tgr);
        }

        private void SetProfileViewToContent()
        {
            if (ProfileViewModel.UserType == UserTypes.Client)
            {
                SetViewToContent(new ClientProfileContentView());
            }
            if (ProfileViewModel.UserType == UserTypes.Interpreter)
            {
                SetViewToContent(new InterpreterProfileContentView());
            }
        }

        private void SetViewToContent(ContentView view)
        {
            ContentLayout.Children.Clear();
            ContentLayout.Children.Add(view);
        }

        private void ProfileSelectorButtonClicked(object sender, EventArgs e)
        {
            ToggleSelectorExpanded();
        }

        private void ToggleSelectorExpanded()
        {
            if (_selectorExpanded)
            {
                SelectorLayout.IsVisible = false;
                SelectorButton.Text = ">";
            }
            else
            {
                SelectorLayout.IsVisible = true;
                SelectorButton.Text = "v";
            }

            _selectorExpanded = !_selectorExpanded;
        }

        private void CalculateProfilesListHeight()
        {
            ProfilesListViewContainer.HeightRequest = Math.Min(SelectorLayout.Height, ProfilesListView.RowHeight * ProfileViewModel.Profiles.Count);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}