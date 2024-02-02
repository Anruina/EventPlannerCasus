using EventPlannerMAUI.MobileApp;
using Library.ApiService;

namespace EventPlannerMAUI.MVVM.View;

using Library.Models;

public partial class EventDetailActivitySchedule : ContentPage
{

	private readonly ApiService _apiService;
	public int EventId { get; set; }

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

	private async void OnActivityTapped(object sender, EventArgs e)
	{

		ViewCell cell = sender as ViewCell;
		await Navigation.PushAsync(new ActivityDetailPage(((Activity)cell.BindingContext).Id));

	}

}