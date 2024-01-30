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

        if (e.Status == GestureStatus.Started)
        {

            MapView.AnchorX = 0;
            MapView.AnchorY = 0;

        }
        else if (e.Status == GestureStatus.Running)
        {

            if ((MapView.Scale < 1.8f && e.Scale >= 1.0f) || (MapView.Scale > 0.85f && e.Scale <= 1.0f))
            {

                MapView.WidthRequest *= e.Scale;
                MapView.HeightRequest *= e.Scale;
                MapView.Scale *= e.Scale;

            }

        }

    }

    private void OnZoomInClick(object sender, EventArgs e)
    {

        if (MapView.Scale < 1.8f)
        {

            MapView.WidthRequest *= 1.1f;
            MapView.HeightRequest *= 1.1f;

            MapView.Scale *= 1.1f;

        }

    }

    private void OnZoomOutClick(object sender, EventArgs e)
    {

        if (MapView.Scale > 0.85f)
        {

            MapView.WidthRequest /= 1.1f;
            MapView.HeightRequest /= 1.1f;

            MapView.Scale /= 1.1f;

        }

    }

}