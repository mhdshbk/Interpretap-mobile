using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Interpretap.Models;
using Interpretap.Services;
using PropertyChanged;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Interpretap.Common.Constants;

namespace Interpretap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [AddINotifyPropertyChangedInterface]
    public partial class RegisterPage : ContentPage
    {
        string _oneSignalId;

        public ObservableCollection<LanguageModel> Languages { get; set; }
        public LanguageModel SelectedLanguage { get; set; }

        public RegisterPage()
        {
            InitializeComponent();
            SetActivityIndicatorState(false);
            Entry_Registration_Key.Completed += (s, e) => Entry_Username.Focus();
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => Entry_Password_Confirm.Focus();
            Entry_Password_Confirm.Completed += (s, e) => Entry_First_Name.Focus();
            Entry_First_Name.Completed += (s, e) => Entry_Last_Name.Focus();
            Entry_Last_Name.Completed += (s, e) => GenderPicker.Focus();
            GenderPicker.SelectedIndexChanged += (s, e) => 
            {
                if (ProfileTypePicker.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    string profileTypeName = ProfileTypePicker.Items[ProfileTypePicker.SelectedIndex];
                    string profileTypeId = ProfileTypes[profileTypeName];
                    if (profileTypeId.Equals("interpreter"))
                    {
                        Entry_Email.Focus();
                    }
                    else
                    {
                        NativeLanguagePicker.Focus();
                    }
                }
            };
            NativeLanguagePicker.SelectedIndexChanged += (s, e) => Entry_Email.Focus();
            Entry_Email.Completed += (s, e) => Entry_Phone_Number.Focus();
            Entry_Phone_Number.Completed += (s, e) => Entry_Address.Focus();
            Entry_Address.Completed += (s, e) => Entry_City.Focus();
            Entry_City.Completed += (s, e) => Entry_Province.Focus();
            Entry_Province.Completed += (s, e) => Entry_Zip_Code.Focus();

            foreach (String profileTypeName in ProfileTypes.Keys)
                ProfileTypePicker.Items.Add(profileTypeName);

            ProfileTypePicker.SelectedIndexChanged += (sender, args) =>
            {
                if (ProfileTypePicker.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    string profileTypeName = ProfileTypePicker.Items[ProfileTypePicker.SelectedIndex];
                    string profileTypeId = ProfileTypes[profileTypeName];
                    Lbl_Registration_Key.IsVisible = profileTypeId.Equals("interpreter") ? true : false;
                    Entry_Registration_Key.IsVisible = profileTypeId.Equals("interpreter") ? true : false;
                    Lbl_NativeLanguage.IsVisible = profileTypeId.Equals("client") ? true : false;
                    NativeLanguagePicker.IsVisible = profileTypeId.Equals("client") ? true : false;
                }

            };

            foreach (String genderName in Genders.Keys)
                GenderPicker.Items.Add(genderName);

            Languages = new ObservableCollection<LanguageModel>();
            LoadLanguagesAsync();

            this.BindingContext = this;
        }

        async Task LoadLanguagesAsync()
        {
            try
            {
                var service = new MiscServices();
                var request = new BaseModel();
                var responce = await service.FetchAllLanguages(request);

                foreach (var language in responce.Languages)
                {
                    Languages.Add(language);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task RegisterProcedure(object sender, EventArgs e)
        {
            SetActivityIndicatorState(true);

            var registrationModel = new RegisterModel();
            registrationModel.InterpreterTerpcode = Entry_Registration_Key.Text;
            registrationModel.Username = Entry_Username.Text;
            registrationModel.Password = Entry_Password.Text;
            registrationModel.PasswordConfirmation = Entry_Password_Confirm.Text;
            registrationModel.FirstName = Entry_First_Name.Text;
            registrationModel.LastName = Entry_Last_Name.Text;
            registrationModel.GenderId = Genders[GenderPicker.Items[GenderPicker.SelectedIndex]];
            registrationModel.ClientNativeLanguage = SelectedLanguage != null ? SelectedLanguage.Id : "";
            registrationModel.Email = Entry_Email.Text;
            registrationModel.PhoneNumber = Entry_Phone_Number.Text;
            registrationModel.City = Entry_City.Text;
            registrationModel.Address = Entry_Address.Text;
            registrationModel.Province = Entry_Province.Text;
            registrationModel.ZipCode = Entry_Zip_Code.Text;
            registrationModel.UserType = ProfileTypePicker.SelectedItem.ToString().ToLower();

            var r = new Random();
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    registrationModel.DeviceId = Guid.NewGuid().ToString(); 
                    registrationModel.DeviceType = 1;
                    break;
                case Device.Android:
                    registrationModel.DeviceId = Guid.NewGuid().ToString(); 
                    registrationModel.DeviceType = 2;
                    break;
            }

            UserService _userService = new UserService();
            var insertUserResponse = await _userService.InsertUser(registrationModel);

            await DisplayAlert("Message", insertUserResponse.Message, "Ok");

            SetActivityIndicatorState(false);
        }

        private void SetActivityIndicatorState(bool enable)
        {
            if (enable)
            {
                ActivityIndicator.IsVisible = true;
                ControlsView.IsVisible = false;
            }
            else
            {
                ActivityIndicator.IsVisible = false;
                ControlsView.IsVisible = true;
            }
        }
    }
}
