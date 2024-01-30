using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Navigeer terug naar de loginpagina.
            await Navigation.PopToRootAsync();
        }
    }
}

