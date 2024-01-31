namespace EventPlannerMAUI.MVVM.View;

public partial class SaveEventPage : ContentPage
{
	public SaveEventPage()
	{
		InitializeComponent();
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
       
        await Navigation.PopAsync();

    }

}