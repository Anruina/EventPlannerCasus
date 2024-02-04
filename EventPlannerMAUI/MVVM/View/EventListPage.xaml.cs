using EventPlannerMAUI.MVVM.ViewModels;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View
{
    public partial class EventListPage : ContentPage
    {

        private EventListViewModel _viewModel;

        public EventListPage()
        {

            InitializeComponent();

           _viewModel = new EventListViewModel();
            BindingContext = _viewModel;

        }

        protected override void OnAppearing()
        {
            
            base.OnAppearing();

            _viewModel.OnRefresh();
            BindingContext = _viewModel;

        }

        private async void OnAddEventClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SaveEventPage());

        }

        private async void OnTappedEvent(object sender, EventArgs e)
        {

            ViewCell cell = sender as ViewCell;
            await Navigation.PushAsync(new NavigationPage(new EventDetailTabbedPage(((Event)cell.BindingContext).Id)));
            
        }

    }
}