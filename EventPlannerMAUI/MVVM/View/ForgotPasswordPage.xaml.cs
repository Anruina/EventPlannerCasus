namespace EventPlannerMAUI.MVVM.View;


    public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {

        InitializeComponent();

    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }

    private async void OnResetClicked(object sender, EventArgs e)
    {

        await DisplayAlert("Success", "Reset link sent to your email.", "OK");
        await Navigation.PushAsync(new PasswordResetInstructionsPage());

    }

    private async void OnInstructionsClicked(object sender, EventArgs e)
    { 

        await Navigation.PushAsync(new PasswordResetInstructionsPage()); 

    }
}

