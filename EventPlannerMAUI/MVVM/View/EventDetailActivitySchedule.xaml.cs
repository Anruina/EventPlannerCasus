namespace EventPlannerMAUI.MVVM.View;

public partial class EventDetailActivitySchedule : ContentPage
{

	public EventDetailActivitySchedule()
	{
	
		InitializeComponent();

	}

	private async void OnAddActivityClick(object sender, EventArgs e)
	{

		await Navigation.PushAsync(new SaveActivityPage());

	}

}