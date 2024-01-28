using EventPlannerMAUI.MobileApp;
using Library.ApiModels;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class UserProfilePage : ContentPage
{

	private readonly ApiService _apiService;

	public UserProfilePage()
	{

		InitializeComponent();
		_apiService = ServiceLocator.apiService;

		OnCreate();

	}

	private async void OnCreate()
	{

		if (ServiceLocator.LoggedIn)
		{

			Participant? participant = await _apiService.GetSpecific<Participant>("Api/Participants");

			if (participant != null)
			{

				if (participant.Address == null)
					participant.Address = new Address() { City = "None", Country = "None", PostalCode = "None", Province = "None", Street = "None" }; 

				UserDataStackLayout.BindingContext = participant;

			}
			else
			{

				Organizer? organizer = await _apiService.GetSpecific<Organizer>("Api/Organizers");

				if (organizer != null)
					UserDataStackLayout.BindingContext = organizer;

			}

		}

	}

    protected override void OnAppearing()
    {
        
		base.OnAppearing();

		OnCreate();

    }

	private async void OnDeleteClick(object sender, EventArgs e)
	{

		bool answer = await DisplayAlert("Account Deletion", "Are you sure you want to delete this account?", "Yes", "No");

		if (answer)
		{

			await _apiService.DeleteObject("Api/User/Account");
			ServiceLocator.LoggedIn = false;

			SecureStorage.Remove("Username");
			SecureStorage.Remove("Password");

		}

	}

    private async void OnLogoutClick(object sender, EventArgs e)
	{

        bool answer = await DisplayAlert("Logout", "Are you sure you want to logout of this account?", "Yes", "No");

		if (answer)
		{

			await _apiService.CreateObject<AccountModel>("Api/Logout", null);
			ServiceLocator.LoggedIn = false;

			SecureStorage.Remove("Username");
			SecureStorage.Remove("Password");

		}

    }

}