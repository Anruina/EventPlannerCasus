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

	public async void OnSetEventId(int eventId)
	{

        EventId = eventId;
        Event? currentEvent = await _apiService.GetSpecific<Event>("Api/Events/", EventId);

        if (currentEvent != null)
        {

            BindingContext = currentEvent;
            _user = await _apiService.GetSpecific<User>("Api/User");

            if (_user?.VisitedEvents?.FirstOrDefault(e => e.Id == EventId) != null)
            {

                SignUpButton.Clicked += OnSignOutClick;
                SignUpButton.Text = "Sign Out";

            }
            else
                SignUpButton.Clicked += OnSignUpClick;

        }

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

}