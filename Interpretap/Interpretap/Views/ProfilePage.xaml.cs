using Interpretap.CustomElements;
using Interpretap.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        bool _selectorExpanded;

        #region Singleton properties
        ClientProfileContentView _clientProfileView;
        public ClientProfileContentView ClientProfileView
        {
            get
            {
                if (_clientProfileView == null)
                {
                    _clientProfileView = new ClientProfileContentView();
                }
                return _clientProfileView;
            }
            set
            {
                if (_clientProfileView != value)
                {
                    _clientProfileView = value;
                }
            }
        }

        InterpreterProfileContentView _interpreterProfileView;
        public InterpreterProfileContentView InterpreterProfileView
        {
            get
            {
                if (_interpreterProfileView == null)
                {
                    _interpreterProfileView = new InterpreterProfileContentView();
                }
                return _interpreterProfileView;
            }
            set
            {
                if (_interpreterProfileView != value)
                {
                    _interpreterProfileView = value;
                }
            }
        }

        AgencyProfileContentView _agencyProfileView;
        public AgencyProfileContentView AgencyProfileView
        {
            get
            {
                if (_agencyProfileView == null)
                {
                    _agencyProfileView = new AgencyProfileContentView();
                }
                return _agencyProfileView;
            }
            set
            {
                if (_agencyProfileView != value)
                {
                    _agencyProfileView = value;
                }
            }
        }

        BusinessProfileContentView _businessProfileView;
        public BusinessProfileContentView BusinessProfileView
        {
            get
            {
                if (_businessProfileView == null)
                {
                    _businessProfileView = new BusinessProfileContentView();
                }
                return _businessProfileView;
            }
            set
            {
                if (_businessProfileView != value)
                {
                    _businessProfileView = value;
                }
            }
        }
        #endregion Singleton properties

        public ProfileViewModel ProfileViewModel { get; set; }

        public ProfilePage()
        {
            InitializeComponent();
            ProfileViewModel = new ProfileViewModel();
            this.BindingContext = ProfileViewModel;

            AddProfileSelectorViewTapRecognizer();
            CalculateProfilesListHeight();
            OnSelectedProfileChanged(ProfileViewModel.SelectedProfile);
            InitProfileSelectorOverlay();

            ProfilesListView.ItemSelected += ProfilesListView_ItemSelected;
        }

        private void AddProfileSelectorViewTapRecognizer()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => ToggleSelectorExpanded();
            ProfileSelectorView.GestureRecognizers.Add(tgr);
        }

        private void InitProfileSelectorOverlay()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => ToggleSelectorExpanded();
            ProfileSelectorOverlay.GestureRecognizers.Add(tgr);
        }

        private void SetViewToContent(ContentView view)
        {
            ContentLayout.Children.Clear();
            ContentLayout.Children.Add(view);
        }

        private void ProfilesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var selectedProfile = e.SelectedItem as ProfileSelectorItemViewModel;
            OnSelectedProfileChanged(selectedProfile);
            ToggleSelectorExpanded();

            (sender as ListView).SelectedItem = null;
        }


        private void ToggleSelectorExpanded()
        {
            if (_selectorExpanded)
            {
                ArrowImage.RotateTo(0, 100);
                SelectorLayout.IsVisible = false;
            }
            else
            {
                SelectorLayout.IsVisible = true;
                ArrowImage.RotateTo(180, 100);
            }

            _selectorExpanded = !_selectorExpanded;
        }

        private void OnSelectedProfileChanged(ProfileSelectorItemViewModel newSelectedProfile)
        {
            if (newSelectedProfile.ProfileType == UserTypes.Client)
            {
                SetViewToContent(ClientProfileView);
            }
            if (newSelectedProfile.ProfileType == UserTypes.Interpreter)
            {
                SetViewToContent(InterpreterProfileView);
            }
            if (newSelectedProfile.ProfileType == UserTypes.Agency)
            {
                SetViewToContent(AgencyProfileView);
                AgencyProfileView.SelectAgency(newSelectedProfile.InterpreterBusinessId);
            }
            if (newSelectedProfile.ProfileType == UserTypes.Business)
            {
                SetViewToContent(BusinessProfileView);
                BusinessProfileView.SelectBusiness(newSelectedProfile.ClientBusinessId);
            }
            ProfileViewModel.SelectProfile(newSelectedProfile);
        }

        private void CalculateProfilesListHeight()
        {
            ProfilesListViewContainer.HeightRequest = Math.Min(SelectorLayout.Height, ProfilesListView.RowHeight * ProfileViewModel.Profiles.Count);
        }

        private async Task LogoutButtonClickedAsync(object sender, EventArgs e)
        {
            await App.LogoutAsync();
        }
    }
}