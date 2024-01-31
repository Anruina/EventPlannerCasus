namespace EventPlannerMAUI.MVVM.View;

public partial class SaveEventPage : ContentPage
{
	public SaveEventPage()
	{
		InitializeComponent();
	}

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EventInfoPage());
    }
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EventInfoPage());
    }
}