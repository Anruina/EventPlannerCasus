using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.IO;

namespace EventPlannerMAUI.MVVM.View;

public partial class EditEventPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly int _eventId;

    public EditEventPage(int EventId)
    {

        InitializeComponent();
        _apiService = ServiceLocator.apiService;
        _eventId = EventId;

        OnCreate();
    }

    private async void OnCreate()
    {
        User? user = await _apiService.GetSpecific<User>("Api/User");
        Event? currentEvent = await _apiService.GetSpecific<Event>("Api/Events/", _eventId);

        if (user == null || user.Type != UserType.Organizer || currentEvent == null)
            await Navigation.PopAsync();

        
        
        if(currentEvent != null)
        {

            EventNameTextField.Text = currentEvent.Name;
            EventDescriptionTextField.Text = currentEvent.Description;
            EventCityTextField.Text = currentEvent.Address.City;
            EventCountryTextField.Text = currentEvent.Address.Country;
            EventPostalCodeTextField.Text = currentEvent.Address.PostalCode;
            EventProvinceTextField.Text = currentEvent.Address.Province;
            EventStreetTextField.Text = currentEvent.Address.Street;
            EventStreetnumberTextField.Text = currentEvent.Address.StreetNumber;
            
            EndDateDatePicker.Date = currentEvent.EndDate;
            StartDateDatePicker.Date = currentEvent.StartDate;
            StartEventTimeTimePicker.Time = TimeOnly.FromDateTime(currentEvent.StartDate).ToTimeSpan();
            EndEventTimeTimePicker.Time = TimeOnly.FromDateTime(currentEvent.EndDate).ToTimeSpan();
            MaxPeopleTextField.Text = currentEvent.MaxParticipants.ToString();
            TypeEventTextField.Text = currentEvent.Type.Name;


        }

    }

    private async void UpdateButton_Clicked(object sender, EventArgs e)
    {

        User? user = await _apiService.GetSpecific<User>("Api/User");
        if (user == null || user.Type != UserType.Organizer)
            await Navigation.PopAsync();

        Event newEvent = new Event()
        {

            Id = _eventId,
            Name = EventNameTextField.Text,
            Description = EventDescriptionTextField.Text,
            Address = new Address()
            {

                City = EventCityTextField.Text,
                Country = EventCountryTextField.Text,
                PostalCode = EventPostalCodeTextField.Text,
                Province = EventProvinceTextField.Text,
                Street = EventStreetTextField.Text,
                StreetNumber = EventStreetnumberTextField.Text,

            },
            StartDate = new DateTime(DateOnly.FromDateTime((DateTime)StartDateDatePicker.Date), TimeOnly.FromTimeSpan((TimeSpan)StartEventTimeTimePicker.Time)),
            EndDate = new DateTime(DateOnly.FromDateTime((DateTime)EndDateDatePicker.Date), TimeOnly.FromTimeSpan((TimeSpan)EndEventTimeTimePicker.Time)),
            OrganizerId = user.Id,
            MaxParticipants = int.Parse(MaxPeopleTextField.Text),
            Type = new EventType() { Name = TypeEventTextField.Text }

        };

        Event? updateEvent = await _apiService.UpdateObject<Event>("Api/Events", _eventId, newEvent);

        if (updateEvent != null)
            await DisplayAlert("Event Updated", "Event has been Updated.", "Ok");

        await Navigation.PopAsync();

    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }
}