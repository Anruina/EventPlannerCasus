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

		ShowTickets();

	}

	private void OnRefresh(object sender, EventArgs e)
	{

		ShowTickets();

    }

    private async void ShowTickets()
	{

        List<Event>? visitedEvents = await _apiService.GetSpecific<List<Event>>("Api/Events/VisitedEvents");

        if (visitedEvents != null)
            EventTicketListView.ItemsSource = visitedEvents;

    }

    private async void OnOpenTicketTapped(object sender, EventArgs e)
    {

        ViewCell cell = sender as ViewCell;
        int id = ((Event)cell.BindingContext).Id;
        await Navigation.PushAsync(new QRTicketPage(id));

    }

}