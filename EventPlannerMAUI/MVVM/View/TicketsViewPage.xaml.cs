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

        Participant? participant = await _apiService.GetSpecific<Participant>("Api/Participants");

		if (participant != null)
			EventTicketListView.BindingContext = participant.VisitedEvents;

    }

}