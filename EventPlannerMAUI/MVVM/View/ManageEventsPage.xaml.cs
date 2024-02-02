using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class ManageEventsPage : ContentPage
{

	private readonly ApiService _apiService;

	public ManageEventsPage()
	{

		InitializeComponent();
		_apiService = ServiceLocator.apiService;

		OnCreate();

	}

	private async void OnCreate()
	{

		User? user = await _apiService.GetSpecific<User>("Api/User");

		if (user != null && user.Type == UserType.Organizer)
            EventListView.ItemsSource = await _apiService.GetList<Event>("Api/Events/User");

	}

	private async void OnTappedEvent(object sender, EventArgs e)
	{

		ViewCell cell = sender as ViewCell;
		await Navigation.PushAsync(new NavigationPage(new EventDetailTabbedPage(((Event)cell.BindingContext).Id)));

	}

}