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

        private async void OnRegisterClick(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());

        }

        private async void OnForgotPasswordClick(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ForgotPasswordPage());

        }

        protected override bool OnBackButtonPressed()
        {

            return true;

        }

    }

}
