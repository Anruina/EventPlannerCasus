using EventPlannerMAUI.MobileApp;
using Library.ApiService;

namespace EventPlannerMAUI.MVVM.View;

using Library.Models;

public partial class EventDetailActivitySchedule : ContentPage
{

	private readonly ApiService _apiService;
	public int EventId { get; set; }
    public int ActivityId { get; set; }

	public EventDetailActivitySchedule()
	{
	
		InitializeComponent();
		_apiService = ServiceLocator.apiService;

        UpdateListView();

	}

	protected override void OnAppearing()
	{

		base.OnAppearing();
        UpdateListView();

	}

    private async void UpdateListView()
    {

        Event? selectedEvent = await _apiService.GetSpecific<Event>("Api/Events/", EventId);

        if (selectedEvent != null)
            ActivityListView.ItemsSource = selectedEvent.Activities;

    }

    private async void OnAddActivityClick(object sender, EventArgs e)
	{

		await Navigation.PushAsync(new SaveActivityPage(EventId));

	}

    private async void OnDeleteClick(object sender, EventArgs e)
    {

        await _apiService.DeleteObject("Api/Events/", ActivityId);


    }

    private async void OnEditClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditActivityPage(EventId, ActivityId));
    }

}