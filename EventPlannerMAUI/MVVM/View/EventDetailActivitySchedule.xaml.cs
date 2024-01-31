namespace EventPlannerMAUI.MVVM.View;

public partial class EventDetailActivitySchedule : ContentPage
{

	public EventDetailActivitySchedule()
	{
	
		InitializeComponent();

	}

	private void CreateNewActivity_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new SaveActivityPage());
	}

}