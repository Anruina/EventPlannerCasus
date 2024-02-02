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

        User? user = await _apiService.GetSpecific<User>("Api/User");

        if (user != null)
            EventTicketListView.ItemsSource = user.VisitedEvents;

    }

    private async void OnOpenTicketTapped(object sender, EventArgs e)
    {

        ViewCell cell = sender as ViewCell;
        int id = ((Event)cell.BindingContext).Id;
        await Navigation.PushAsync(new QRTicketPage(id));

    }

}