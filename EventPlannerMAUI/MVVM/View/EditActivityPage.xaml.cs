using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class SaveActivityPage : ContentPage
{

    private readonly ApiService _apiService;
    private readonly int _eventId;

	public SaveActivityPage(int eventId)
	{

		InitializeComponent();

        _apiService = ServiceLocator.apiService;
        _eventId = eventId;

        OnCreate();

	}

    private async void OnCreate()
    {

        Event? selectedEvent = await _apiService.GetSpecific<Event>("Api/Events/", _eventId);

        if (selectedEvent != null)
            ActivityEventTextField.Text = selectedEvent.Name;

    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {

        Activity newActivity = new Activity()
        {

            EventId = _eventId,
            Name = ActivityNameTextField.Text,
            Description = ActivityDescriptionTextField.Text,
            Room = ActivtyLocationTextField.Text,
            StartTime = TimeOnly.FromTimeSpan((TimeSpan)StartActivityTimeTimePicker.Time),
            EndTime = TimeOnly.FromTimeSpan((TimeSpan)EndActivityTimeTimePicker.Time)

        };

        Activity? activity = await _apiService.CreateObject<Activity>("Api/Activities", newActivity);

        if (activity != null)
            await DisplayAlert("Activity Created", "Activity has been created.", "Ok");
        else
            await DisplayAlert("Activity Failure", "Activity could not be created.", "Ok");

        await Navigation.PopAsync();

    }

}