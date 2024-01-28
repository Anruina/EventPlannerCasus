using EventPlannerMAUI.MobileApp;
using EventPlannerMAUI.MVVM.Models;
using Library.ApiModels;
using Library.ApiService;

namespace EventPlannerMAUI.MVVM.View
{
    public partial class HomeNavigationPage : FlyoutPage
    {

        private readonly ApiService _apiService;

        public HomeNavigationPage()
        {

            InitializeComponent();
            _apiService = ServiceLocator.apiService;

            MainFlyoutPage.NavigationOptionsCollectionView.SelectionChanged += OnSelectionChanged;

            OnCreate();

        }

        private async void OnCreate()
        {

            if (await SecureStorage.GetAsync("Username") is string Username && await SecureStorage.GetAsync("Password") is string Password)
            {

                AccountModel? account = await _apiService.CreateObject("Api/User/Login", new AccountModel { Username = Username, Password = Password });

                if (account != null)
                    ServiceLocator.LoggedIn = true;

            }

        }

        private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e) 
        {

            FlyoutPageItem? item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
            if (item != null) 
            {

                Detail = new NavigationPage((Page?)Activator.CreateInstance(item.TargetType));

                if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                    IsPresented = false;

                if (item.RequiresAuthentication && !ServiceLocator.LoggedIn)
                    Detail.Navigation.PushAsync(new MainPage());

            }

        }

    }

}


