using EventPlannerMAUI.MobileApp;
using Library.ApiModels;
using Library.ApiService;
using UraniumUI.Material.Controls;

namespace EventPlannerMAUI.MVVM.View
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            
            InitializeComponent();

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
