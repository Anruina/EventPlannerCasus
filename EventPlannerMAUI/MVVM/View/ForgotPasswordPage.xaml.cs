namespace EventPlannerMAUI.MVVM.View;


    public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnResetClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            await DisplayAlert("Invalid Email", "Email is not valid: missing '@'.", "OK");
        }
        else
        {
            // Hier zou eventueel nog de logica kunnen komen om een rest mail te sturen naar de gebruiker.
            await DisplayAlert("Success", "Reset link sent to your email.", "OK");
            // Optioneel: Navigeer terug naar de loginpagina of een andere relevante pagina
        }
    }


    private async void
        OnInstructionsClicked(object sender, 
        EventArgs e)
    { 
        await Navigation.PushAsync(new PasswordResetInstructionsPage()); 
    }
}

