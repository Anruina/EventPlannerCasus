using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;
using Microsoft.Extensions.Logging;

namespace EventPlannerMAUI.MVVM.View;

public partial class ActivityDetailPage : ContentPage
{

	private readonly ApiService _apiService;
	private readonly int _activityId;
    private readonly int _eventId;

	public ActivityDetailPage(int eventId, int activityId)
	{

		InitializeComponent();

		_apiService = ServiceLocator.apiService;
        _activityId = activityId;
        _eventId = eventId;

		OnCreate();

	}

	private async void OnCreate()
	{

		Activity? currentActivity = await _apiService.GetSpecific<Activity>("Api/Activities/", _activityId);
        User? user = await _apiService.GetSpecific<User>("Api/User");
        Event? currentEvent = await _apiService.GetSpecific<Event>("Api/Events/", _eventId);

        if (currentActivity != null)
        {

            currentActivity.Event = currentEvent;
            BindingContext = currentActivity;

        }

        if (user != null && currentEvent != null)
        {

            DeleteButton.IsVisible = (user.Type == UserType.Organizer) && (currentEvent.OrganizerId == user.Id);
            EditButton.IsVisible = DeleteButton.IsVisible;

        }

    }

    protected override async void OnAppearing()
    {

        base.OnAppearing();

        Activity? currentActivity = await _apiService.GetSpecific<Activity>("Api/Activities/", _activityId);
        Event? currentEvent = await _apiService.GetSpecific<Event>("Api/Events/", _eventId);

        if (currentActivity != null)
        {

            currentActivity.Event = currentEvent;
            BindingContext = currentActivity;

        }

    }

    private async void OnDeleteClick(object sender, EventArgs e)
    {

        bool answer = await DisplayAlert("Delete Activity", "Are you sure you want to delete this activity.", "Yes", "No");

        if (answer == true)
        {

            await _apiService.DeleteObject("Api/Activities/", _activityId);
            await Navigation.PopAsync();

        }

    }

    private async void OnEditClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditActivityPage(_eventId, _activityId));
    }

}