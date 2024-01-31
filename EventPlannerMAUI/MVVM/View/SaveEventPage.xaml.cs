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
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EventInfoPage());
    }
}