using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventInfoPage : ContentPage
{

	private readonly ApiService _apiService;
	private User? _user;

	public EventInfoPage()
	{

		InitializeComponent();
		_apiService = ServiceLocator.apiService;

		OnCreate();

	}

	private async void OnCreate()
	{

		_user = await _apiService.GetSpecific<User>("Api/User");
        Event boundEvent = (Event)BindingContext;

		if (_user?.VisitedEvents?.FirstOrDefault(e => e.Id == boundEvent.Id) != null)
		{

			SignUpButton.Clicked += OnSignOutClick;
			SignUpButton.Text = "Sign Out";

        }
		else
			SignUpButton.Clicked += OnSignUpClick;

    }

	private async void OnSignOutClick(object? sender, EventArgs e)
	{

		bool signOut = await DisplayAlert("Sign Up", "Are you sure you want to sign out for this event.", "Yes", "No");
		
		if (signOut)
		{

			Event boundEvent = (Event)BindingContext;
			_user?.VisitedEvents?.RemoveAll(e => e.Id == boundEvent.Id);

			await _apiService.UpdateObject<User>("Api/Events/SignOut/", boundEvent.Id, _user);

			await DisplayAlert("Sign Out", "You successfully signed out for this event.", "Ok");

            SignUpButton.Clicked += OnSignUpClick;
			SignUpButton.Text = "Sign Up";

        }

    }

    private async void OnSignUpClick(object? sender, EventArgs e)
	{

		Event boundEvent = (Event)BindingContext;
		await _apiService.UpdateObject<User>("Api/Events/SignUp/", boundEvent.Id, _user);

        SignUpButton.Clicked += OnSignOutClick;
        SignUpButton.Text = "Sign Out";

        await DisplayAlert("Sign Up", "You successfully signed up for this event.", "Ok");

    }

}