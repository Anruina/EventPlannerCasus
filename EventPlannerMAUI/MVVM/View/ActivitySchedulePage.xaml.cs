namespace EventPlannerMAUI.MVVM.View;

public partial class ActivitySchedulePage : ContentPage
{
	public ActivitySchedulePage()
	{
		InitializeComponent();
	}
	
	private async void CreateNewActivity_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SaveActivityPage());
	}
}