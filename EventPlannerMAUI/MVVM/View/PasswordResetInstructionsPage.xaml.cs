namespace EventPlannerMAUI.MVVM.View
{
    
    public partial class PasswordResetInstructionsPage : ContentPage
    {

        public PasswordResetInstructionsPage()
        {

            InitializeComponent();

        }

        private async void OnBackToLoginClicked(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }

    }

}

