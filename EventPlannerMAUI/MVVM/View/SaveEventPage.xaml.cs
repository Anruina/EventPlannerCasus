using EventPlannerMAUI.MobileApp;
using EventPlannerMAUI.MVVM.ViewModels;
using Library.ApiService;
using Library.Models;
using Plugin.LocalNotification;

namespace EventPlannerMAUI.MVVM.View;

public partial class SaveEventPage : ContentPage
{

    private SaveEventPageViewModel _viewModel;

	public SaveEventPage()
	{

		InitializeComponent();

        _viewModel = new SaveEventPageViewModel();
        BindingContext = _viewModel;

	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {

        _viewModel.CreateEvent?.Execute(null);

        // notify organiser that event has been created!
        var request = new NotificationRequest
        {

            NotificationId = 1337,
            Title = "New Event available!",
            Subtitle = "Zuyd Events",
            Description = "A new event has been created! Feel free to join the schoolspirit by attenting :) " +
            "Simply sign up by pressing the 'sign up' button!",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {

                NotifyTime = DateTime.Now.AddSeconds(5),
                NotifyRepeatInterval = TimeSpan.FromSeconds(60),

            }
        };

        await LocalNotificationCenter.Current.Show(request);
        await Navigation.PopAsync();

    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
       
        await Navigation.PopAsync();

    }

}