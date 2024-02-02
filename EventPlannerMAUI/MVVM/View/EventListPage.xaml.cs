using System.Collections.ObjectModel;
using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventListPage : ContentPage
{

    private readonly ApiService _apiService;

    public EventListPage()
    {

        InitializeComponent();
        _apiService = ServiceLocator.apiService;

        OnCreate();

    }

    private async void OnCreate()
    {

        EventListView.ItemsSource = await _apiService.GetList<Event>("Api/Events");
        
        Organizer? organizer = await _apiService.GetSpecific<Organizer>("Api/Organizers");
        if (organizer != null)
            AddEventButton.IsVisible = true;

    }

    protected override async void OnAppearing()
    {
        
        base.OnAppearing();
        EventListView.ItemsSource = await _apiService.GetList<Event>("Api/Events");

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