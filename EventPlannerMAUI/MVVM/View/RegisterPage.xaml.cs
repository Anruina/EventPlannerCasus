using EventPlannerMAUI.MobileApp;
using Library.ApiService;

namespace EventPlannerMAUI.MVVM.View;

public partial class RegisterPage : ContentPage
{

    private readonly ApiService _apiService;

    public RegisterPage()
	{

		InitializeComponent();
        _apiService = ServiceLocator.apiService;

    }

    private async void OnRegisterClick(object sender, EventArgs e)
    {

        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            PasswordMatchLabel.IsVisible = true;
        else
        {

            //bool registeredNewUser = await _apiService.Register(UsernameEntry.Text, PasswordEntry.Text);

            //if (registeredNewUser)
              //  await Navigation.PopAsync();

        }

    }

}