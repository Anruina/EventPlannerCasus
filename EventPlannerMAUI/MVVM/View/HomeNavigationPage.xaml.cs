using EventPlannerMAUI.MVVM.Models;

namespace EventPlannerMAUI.MVVM.View
{
    public partial class HomeNavigationPage : FlyoutPage
    {

        public HomeNavigationPage()
        {

            InitializeComponent();
            MainFlyoutPage.NavigationOptionsCollectionView.SelectionChanged += OnSelectionChanged;

        }

        private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e) 
        {

            FlyoutPageItem? item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
            if (item != null) 
            {

                Detail = new NavigationPage((Page?)Activator.CreateInstance(item.TargetType));
                if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                    IsPresented = false;

            }

        }

    }

}


