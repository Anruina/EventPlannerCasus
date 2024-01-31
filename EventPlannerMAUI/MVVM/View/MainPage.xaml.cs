using EventPlannerMAUI.MobileApp;
using Library.ApiModels;
using Library.ApiService;
using UraniumUI.Material.Controls;

namespace EventPlannerMAUI.MVVM.View
{

    public partial class MainPage : ContentPage
    {

        private readonly ApiService _apiService;

        public MainPage()
        {
            
            InitializeComponent();
            _apiService = ServiceLocator.apiService;    

        }

        private async void OnLoginClick(object sender, EventArgs e)
        {

            AccountModel? account = await _apiService.CreateObject("Api/User/Login", new AccountModel { Username = EmailEntry.Text, Password = PasswordEntry.Text });

            if (account != null)
            {

                await SecureStorage.SetAsync("Username", EmailEntry.Text);
                await SecureStorage.SetAsync("Password", PasswordEntry.Text);

                LogginFailedLabel.IsVisible = false;
                ServiceLocator.LoggedIn = true;
                await Navigation.PopAsync();

            }
            else
                LogginFailedLabel.IsVisible = true;

        }

        private async void OnRegisterClick(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());

        }

        private async void OnForgotPasswordClick(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ForgotPasswordPage());

        }

        private async void testclick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QRTicketPage());
        }

    }

}
