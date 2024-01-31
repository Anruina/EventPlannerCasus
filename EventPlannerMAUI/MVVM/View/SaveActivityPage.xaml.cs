namespace EventPlannerMAUI.MVVM.View;

public partial class SaveActivityPage : ContentPage
{
	public SaveActivityPage()
	{
		InitializeComponent();
	}

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EventDetailActivitySchedule());
    }
}