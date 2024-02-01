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

        if (PasswordUser.Text != ConfirmPasswordUser.Text)
            PasswordMatchLabel.IsVisible = true;
        else
        {

            AccountModel? account = await _apiService.CreateObject<AccountModel>("Api/User/Register", new AccountModel { Username = EmailaddressUser.Text, Password = PasswordUser.Text });

            if (account != null)
                await Navigation.PopAsync();

        }

    }

}