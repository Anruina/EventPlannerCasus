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

	public async void OnSetEventId(int eventId)
	{

		EventId = eventId;

		User? user = await _apiService.GetSpecific<User>("Api/User");
		Event? currentEvent = await _apiService.GetSpecific<Event>("Api/Events/", EventId);

        if (user != null && currentEvent != null)
			AddActivityButton.IsVisible = (user.Type == UserType.Organizer) && (currentEvent.OrganizerId == user.Id);


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
        await Navigation.PushAsync(new EditActivityPage(ActivityId));
    }

	private async void OnActivityTapped(object sender, EventArgs e)
	{

		ViewCell cell = sender as ViewCell;
		await Navigation.PushAsync(new ActivityDetailPage(((Activity)cell.BindingContext).Id));

	}

}