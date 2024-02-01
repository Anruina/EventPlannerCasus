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

            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();

        }

    }

}

