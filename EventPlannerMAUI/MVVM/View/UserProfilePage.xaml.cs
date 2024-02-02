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

	protected override void OnAppearing()
	{

		base.OnAppearing();

		OnCreate();

	}

	private async void OnBecomeOrganizerClick(object sender, EventArgs e)
	{

		Participant? participant = await _apiService.GetSpecific<Participant>("Api/Participants");

		if (participant == null)
		{

			await DisplayAlert("Account Failure", "Account already is an organizer.", "Ok");

		}
		else
		{

			Participant? organizer = await _apiService.CreateObject<Participant>("Api/Organizers/", participant);

			if (organizer != null)
				await DisplayAlert("Account Upgrade", "Account has been upgraded to organizer.", "Ok");
			else
                await DisplayAlert("Account Failure", "Could not upgrade account to an organizer.", "Ok");

        }

    }

	private async void OnDeleteClick(object sender, EventArgs e)
	{

		bool answer = await DisplayAlert("Account Deletion", "Are you sure you want to delete this account?", "Yes", "No");

		if (answer)
		{

			await _apiService.DeleteObject("Api/User/Account");

			SecureStorage.Remove("Username");
			SecureStorage.Remove("Password");

		}

	}

}