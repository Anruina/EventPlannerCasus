using Camera.MAUI;

namespace EventPlannerMAUI.MVVM.View;

public partial class QRTicketPage : ContentPage
{
	public QRTicketPage()
	{
        InitializeComponent();
    }

    private void QR_REFRESH_CLICKED(object sender, EventArgs e)
    {
        QRcode.Barcode = "hello";
    }
}