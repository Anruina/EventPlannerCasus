using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventInfoPage : ContentPage
{

	private readonly ApiService _apiService;
	private User? _user;
	public int EventId { get; set; }

	public EventInfoPage()
	{

		InitializeComponent();
		_apiService = ServiceLocator.apiService;

	}

    protected override void OnAppearing()
    {
        
        base.OnAppearing();
        OnSetEventId(EventId);

    }

    public async void OnSetEventId(int eventId)
	{

        EventId = eventId;
        Event? currentEvent = await _apiService.GetSpecific<Event>("Api/Events/", EventId);

        if (currentEvent != null)
        {

            BindingContext = currentEvent;
            _user = await _apiService.GetSpecific<User>("Api/User");

            if (currentEvent?.Users?.FirstOrDefault(u => u.Id == _user.Id) != null)
            {

                SignUpButton.Clicked += OnSignOutClick;
                SignUpButton.Text = "Sign Out";

            }
            else
                SignUpButton.Clicked += OnSignUpClick;

        }

        User? user = await _apiService.GetSpecific<User>("Api/User");
        if (user != null && user.Type == UserType.Organizer)
            DeleteButton.IsVisible = true;
            EditButton.IsVisible = true;

    }

    private async void OnSignOutClick(object? sender, EventArgs e)
	{

		bool signOut = await DisplayAlert("Sign Up", "Are you sure you want to sign out for this event.", "Yes", "No");
		
		if (signOut)
		{

			await _apiService.UpdateObject<User>("Api/Events/SignOut/", EventId, new User { Id = _user.Id });
			await DisplayAlert("Sign Out", "You successfully signed out for this event.", "Ok");

            SignUpButton.Clicked += OnSignUpClick;
			SignUpButton.Text = "Sign Up";

        }

    }

    private async void OnSignUpClick(object? sender, EventArgs e)
	{

		await _apiService.UpdateObject<User>("Api/Events/SignUp/", EventId, new User { Id = _user.Id });

        SignUpButton.Clicked += OnSignOutClick;
        SignUpButton.Text = "Sign Out";

        await DisplayAlert("Sign Up", "You successfully signed up for this event.", "Ok");

    }

    private async void OnDeleteClick(object sender, EventArgs e)
    {

        bool answer = await DisplayAlert("Delete Event", "Are you sure you want to delete this event.", "Yes", "No");

        if (answer == true)
        {

            await _apiService.DeleteObject("Api/Events/", EventId);
            await Navigation.PopAsync();

        }


    }

    private async void OnEditClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditEventPage(EventId));
    }

}