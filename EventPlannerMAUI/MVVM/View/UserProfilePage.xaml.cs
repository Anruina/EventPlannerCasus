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

		User? user = await _apiService.GetSpecific<User>("Api/User");

		if (user != null)
		{

			if (user.Address == null)
				user.Address = new Address() { City = "None", Country = "None", PostalCode = "None", Province = "None", Street = "None" };

			UserDataStackLayout.BindingContext = user;

		}

	}

	protected override void OnAppearing()
	{

		base.OnAppearing();

		OnCreate();

	}

	private async void OnBecomeOrganizerClick(object sender, EventArgs e)
	{

		User? user = await _apiService.GetSpecific<User>("Api/User");

		if (user == null || user.Type == UserType.Organizer)
		{

			await DisplayAlert("Account Failure", "Account already is an organizer.", "Ok");

		}
		else
		{

			user.Type = UserType.Organizer;
			
			await _apiService.UpdateObject<User>("Api/User/", user.Id, user);
			await DisplayAlert("Account Upgrade", "Account has been upgraded to organizer.", "Ok");
			
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