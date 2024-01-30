using EventPlannerMAUI.MobileApp;
using Library.ApiModels;
using Library.ApiService;

namespace EventPlannerMAUI.MVVM.View
{

    public partial class MainPage : ContentPage
    {

        private readonly ApiService _apiService;

        public MainPage()
        {
            
            InitializeComponent();
            _apiService = ServiceLocator.apiService;

            OnCreate();

        }

        private void OnCreate()
        {
            OnCreate(loadingStackLayout: LoadingStackLayout);
        }

        private async void OnCreate(StackLayout loadingStackLayout)
        {

            if (await SecureStorage.GetAsync("Username") is string Username && await SecureStorage.GetAsync("Password") is string Password)
            {

                AccountModel? account = await _apiService.CreateObject("Api/User/Login", new AccountModel { Username = Username, Password = Password });
 
                if (account != null)
                    await Navigation.PushAsync(new HomeNavigationPage());

            }

            loadingStackLayout.IsVisible = false;
            LoginVerticalStackLayout.IsVisible = true;

        }

        private async void OnLoginClick(object sender, EventArgs e)
        {

            AccountModel? account = await _apiService.CreateObject("Api/User/Login", new AccountModel { Username = UsernameEntry.Text, Password = PasswordEntry.Text });

            if (account != null)
            {

                await SecureStorage.SetAsync("Username", UsernameEntry.Text);
                await SecureStorage.SetAsync("Password", PasswordEntry.Text);

                LogginFailedLabel.IsVisible = false;
                await Navigation.PushAsync(new HomeNavigationPage());

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

    }

}
