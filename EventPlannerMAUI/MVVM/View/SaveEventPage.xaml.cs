namespace EventPlannerMAUI.MVVM.View;

public partial class SaveEventPage : ContentPage
{
	public SaveEventPage()
	{
		InitializeComponent();
	}

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EventListPage());
    }
    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
       await Navigation.PopAsync();
    }
}