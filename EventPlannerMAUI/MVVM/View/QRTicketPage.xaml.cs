using Camera.MAUI;
using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class QRTicketPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly int _eventId;

    public QRTicketPage(int eventId)
    {
        InitializeComponent();

        _apiService = ServiceLocator.apiService;
        _eventId = eventId;

        GenerateQRCode();

    }

    private async void GenerateQRCode()
    {
        Event? currentEvent = await _apiService.GetSpecific<Event>("Api/Events/", _eventId);
        QRcode.Barcode = $"Entry has been granted for {currentEvent.Name} on {currentEvent.StartDate} till {currentEvent.EndDate}";

        BindingContext = currentEvent;

    }

    private void QR_REFRESH_CLICKED(object sender, EventArgs e)
    {
        GenerateQRCode();
    }

}