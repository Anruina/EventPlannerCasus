namespace EventPlannerMAUI.MVVM.View;

public partial class EventDetailMapPage : ContentPage
{
	
    public EventDetailMapPage()
	{
	
        InitializeComponent();

	}

    private void OnRefresh(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(StartPos.Text) && !string.IsNullOrEmpty(EndPos.Text))
        {

            MainMapPath.StartPos = StartPos.Text;
            MainMapPath.EndPos = EndPos.Text;
            MainMapPath.Emergency = false;

            MapView.Invalidate();

        }

    }

    private void OnEmergencyClick(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(StartPos.Text))
        {

            MainMapPath.Emergency = true;
            MapView.Invalidate();

        }

    }

    private void OnMapPinch(object sender, PinchGestureUpdatedEventArgs e)
    {

        if (e.Status == GestureStatus.Running)
        {

            if (e.Scale > 1.0f)
                MapView.Scale += 0.01f;
            else
                MapView.Scale -= 0.01f;

        }

    }

}