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

            MapView.Scale *= e.Scale;

            if (MapView.Scale > 1.6f || MapView.Scale < 0.85f)
                MapView.Scale /= e.Scale;
            else
            {

                MapView.WidthRequest *= e.Scale;
                MapView.HeightRequest *= e.Scale;

            }

        }

    }

    private void OnMapPan(object sender, PanUpdatedEventArgs e)
    {

        if ((e.TotalX < 0.0f && MapView.TranslationX > -MapView.WidthRequest + 500) || (e.TotalX > 0.0f && MapView.TranslationX < 0))
            MapView.TranslationX += e.TotalX;

        if ((e.TotalY < 0.0f && MapView.TranslationY > -MapView.HeightRequest + 850) || (e.TotalY > 0.0f && MapView.TranslationY < MapView.HeightRequest - 700))
            MapView.TranslationY += e.TotalY;

    }

}