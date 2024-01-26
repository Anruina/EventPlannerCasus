namespace EventPlannerMAUI.MVVM.View;

public partial class EventDetailMap : ContentPage
{
	
    public EventDetailMap()
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

}