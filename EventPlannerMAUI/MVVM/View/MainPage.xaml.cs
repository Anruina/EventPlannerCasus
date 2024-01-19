using EventPlannerMAUI.MobileApp;
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


        private async void OnCreate()
        {

            if (await SecureStorage.GetAsync("Username") is string Username && await SecureStorage.GetAsync("Password") is string Password)
            {

                //bool LoggedIn = await _apiService.Login(Username, Password);

               // if (LoggedIn)
                //    await Navigation.PushAsync(new HomeNavigationPage());

            }

            LoadingStackLayout.IsVisible = false;
            LoginVerticalStackLayout.IsVisible = true;

        }

        private async void OnLoginClick(object sender, EventArgs e)
        {

            //bool LoggedIn = await _apiService.Login(UsernameEntry.Text, PasswordEntry.Text);
            bool LoggedIn = false;

            if (LoggedIn)
            {

                await SecureStorage.SetAsync("Username", UsernameEntry.Text);
                await SecureStorage.SetAsync("Password", PasswordEntry.Text);

                LogginFailedLabel.IsVisible = false;
               // await Navigation.PushAsync(new HomeNavigationPage());

            }
            else
                LogginFailedLabel.IsVisible = true;

        }

        private async void OnRegisterClick(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());

        }

    }

}
