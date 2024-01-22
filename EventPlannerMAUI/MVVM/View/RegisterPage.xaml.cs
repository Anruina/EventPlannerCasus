using EventPlannerMAUI.MobileApp;
using Library.ApiModels;
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

            AccountModel? account = await _apiService.CreateObject<AccountModel>("Api/User/Register", new AccountModel { Username = UsernameEntry.Text, Password = PasswordEntry.Text });

            if (account != null)
                await Navigation.PopAsync();

        }

    }

}