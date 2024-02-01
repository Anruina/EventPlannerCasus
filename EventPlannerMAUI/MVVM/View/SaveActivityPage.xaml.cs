using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class SaveActivityPage : ContentPage
{

    private readonly ApiService _apiService;
    private readonly int _eventId;

	public SaveActivityPage(int eventId)
	{

		InitializeComponent();

        _apiService = ServiceLocator.apiService;
        _eventId = eventId;

	}

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {

        Activity newActivity = new Activity()
        {



        };

        Navigation.PushAsync(new EventDetailActivitySchedule());

    }

}