using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;
using Microsoft.Extensions.Logging;

namespace EventPlannerMAUI.MVVM.View;

public partial class EditActivityPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly int _eventId;
    private readonly int _activityId;

    public EditActivityPage(int eventId, int ActivityId)
    {

        InitializeComponent();

        _apiService = ServiceLocator.apiService;
        _eventId = eventId;
        _activityId = ActivityId;

        OnCreate();

    }

    private async void OnCreate()
    {
        //User? user = await _apiService.GetSpecific<User>("Api/User");
        Event? selectedEvent = await _apiService.GetSpecific<Event>("Api/Events/", _eventId);
        Activity? currentActivity = await _apiService.GetSpecific<Activity>("Api/Activities/", _activityId);

        if (selectedEvent != null)
            ActivityEventTextField.Text = selectedEvent.Name;

        if(currentActivity != null)
        {

            ActivityNameTextField.Text = currentActivity.Name;
            ActivityDescriptionTextField.Text = currentActivity.Description;
            ActivtyLocationTextField.Text = currentActivity.Room;
            StartActivityTimeTimePicker.Time = ((TimeOnly)currentActivity.StartTime).ToTimeSpan();
            EndActivityTimeTimePicker.Time = ((TimeOnly)currentActivity.EndTime).ToTimeSpan();

        }

    }


    private async void UpdateButton_Clicked(object sender, EventArgs e)
    {
        User? user = await _apiService.GetSpecific<User>("Api/User");
        if(user == null || user.Type != UserType.Organizer)
            await Navigation.PopAsync();

        Activity newActivity = new Activity()
        {

            Id = _activityId,
            EventId = _eventId,
            Name = ActivityNameTextField.Text,
            Description = ActivityDescriptionTextField.Text,
            Room = ActivtyLocationTextField.Text,
            StartTime = TimeOnly.FromTimeSpan((TimeSpan)StartActivityTimeTimePicker.Time),
            EndTime = TimeOnly.FromTimeSpan((TimeSpan)EndActivityTimeTimePicker.Time)

        };

        await _apiService.UpdateObject<Activity>("Api/Activities/", _activityId, newActivity);
        await DisplayAlert("Activity Updated!", "Activity has been updated.", "Ok");

        await Navigation.PopAsync();

    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }
}