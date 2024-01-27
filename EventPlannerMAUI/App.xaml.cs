using EventPlannerMAUI.MVVM.View;

namespace EventPlannerMAUI
{
    public partial class App : Application
    {

        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

        }

    }
}
