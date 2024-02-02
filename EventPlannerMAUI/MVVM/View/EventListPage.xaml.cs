using System.Collections.ObjectModel;
using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View
{
    public partial class EventListPage : ContentPage
    {
        private readonly ApiService _apiService;
        private ObservableCollection<Event> _allEvents;

        public EventListPage()
        {

            InitializeComponent();
            _apiService = ServiceLocator.apiService;

            OnCreate();

        }

        private async void OnCreate()
        {
            _allEvents = new ObservableCollection<Event>(await _apiService.GetList<Event>("Api/Events"));
            EventListView.ItemsSource = _allEvents;

            EventListView.ItemsSource = await _apiService.GetList<Event>("Api/Events");

            User? user = await _apiService.GetSpecific<User>("Api/User");
            if (user != null && user.Type == UserType.Organizer)
                AddEventButton.IsVisible = true;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            _allEvents = new ObservableCollection<Event>(await _apiService.GetList<Event>("Api/Events"));
            EventListView.ItemsSource = _allEvents;

        }

        private async void OnAddEventClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SaveEventPage());
        }

        private async void OnTappedEvent(object sender, EventArgs e)
        {

            ViewCell cell = sender as ViewCell;
            int id = ((Event)cell.BindingContext).Id;
            await Navigation.PushAsync(new NavigationPage(new EventDetailTabbedPage(id)));
            
        }
        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text.ToLower();
            var filteredEvents = _allEvents.Where(eventItem => eventItem.Name.ToLower().Contains(searchTerm)).ToList();
            EventListView.ItemsSource = new ObservableCollection<Event>(filteredEvents);
        }
    }
}