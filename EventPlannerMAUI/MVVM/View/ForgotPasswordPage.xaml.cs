namespace EventPlannerMAUI.MVVM.View;


    public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage() => InitializeComponent();

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnResetClicked(object sender, EventArgs e)
    {
        // Implementeer hier de logica om een reset link te sturen.
        await DisplayAlert("Success", "Reset link sent to your email.", "OK");

        // Optioneel: Navigeer terug naar login na succes.
        await Navigation.PopAsync();
    }
    
    private async void
        OnInstructionsClicked(object sender, 
        EventArgs e)
    { 
        await Navigation.PushAsync(new PasswordResetInstructionsPage()); 
    }
}

