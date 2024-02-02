using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class SaveEventPage : ContentPage
{

    private readonly ApiService _apiService;

	public SaveEventPage()
	{

		InitializeComponent();
        _apiService = ServiceLocator.apiService;        

	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {

        User? user = await _apiService.GetSpecific<User>("Api/User");
        if (user == null || user.Type != UserType.Organizer)
            await Navigation.PopAsync();

        Event newEvent = new Event()
        {

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

        Event? createdEvent = await _apiService.CreateObject<Event>("Api/Events", newEvent);

        if (createdEvent != null)
            await DisplayAlert("Event Created", "Event has been created.", "Ok");

        await Navigation.PopAsync();

    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
       
        await Navigation.PopAsync();

    }

}