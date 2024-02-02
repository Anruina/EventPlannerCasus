using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class TicketsViewPage : ContentPage
{

	private readonly ApiService _apiService;

	public TicketsViewPage()
	{

		InitializeComponent();
		_apiService = ServiceLocator.apiService;

		OnCreate();

	}

	private async void OnCreate()
	{

        User? user = await _apiService.GetSpecific<User>("Api/User");

		if (user != null)
			EventTicketListView.BindingContext = user.VisitedEvents;

    }

}