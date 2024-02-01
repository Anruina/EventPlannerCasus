using System.Collections.ObjectModel;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventListPage : ContentPage
{

    public EventListPage()
    {

        InitializeComponent();

        List<Event> events = new List<Event>();
        events.Add(new Event { Id = 0, Name = "Evenement 1", StartDate = new DateTime(2024, 2, 24, 15, 20, 0), EndDate = new DateTime(2024, 2, 24, 16, 20, 0), Address = new Address() { Id = 0, Country = "The Netherlands", City = "Heerlen", PostalCode = "7993 MN", Street = "EventStreet", Province = "Limburg", StreetNumber = "20" } });

        EventListView.ItemsSource = events;

    }

    private async void OnAddEventClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new SaveEventPage());

    }

    private async void OnSelectedEvent(object sender, EventArgs e)
    {

        if (EventListView.SelectedItem != null)
        {

            await Navigation.PushAsync(new NavigationPage(new EventDetailTabbedPage()));
            EventListView.SelectedItem = null;

        }

    }

}