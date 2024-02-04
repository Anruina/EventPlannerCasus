using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;
using EventPlannerMAUI.MVVM.ViewModels;
using Plugin.LocalNotification;


namespace EventPlannerMAUI.MVVM.View;

public partial class EventInfoPage : ContentPage
{

    private EventInfoPageViewModel _viewModel;

	public EventInfoPage()
	{

		InitializeComponent();
        _viewModel = new EventInfoPageViewModel();

    }

    protected override void OnAppearing()
    {
        
        base.OnAppearing();

        if (_viewModel.CurrentEvent != null)
            OnSetEventId(_viewModel.CurrentEvent.Id);

    }

    public async void OnSetEventId(int eventId)
	{

        await _viewModel.OnRefresh(eventId);
        BindingContext = _viewModel.CurrentEvent;


        if (_viewModel.SignedIn)
        {

            SignUpButton.Clicked += OnSignOutClick;
            SignUpButton.Text = "Sign Out";

        }
        else
            SignUpButton.Clicked += OnSignUpClick;

        if (_viewModel.IsOwner)
        {

            DeleteButton.IsVisible = true;
            EditButton.IsVisible = true;

        }

    }

    private async void OnSignOutClick(object? sender, EventArgs e)
	{

		bool signOut = await DisplayAlert("Sign Up", "Are you sure you want to sign out for this event.", "Yes", "No");
		
		if (signOut)
		{

            _viewModel?.SignOut?.Execute(null);
			await DisplayAlert("Sign Out", "You successfully signed out for this event.", "Ok");

            SignUpButton.Clicked += OnSignUpClick;
			SignUpButton.Text = "Sign Up";

        }

    }

    private async void OnSignUpClick(object? sender, EventArgs e)
    {

        _viewModel?.SignUp?.Execute(null);

        SignUpButton.Clicked += OnSignOutClick;
        SignUpButton.Text = "Sign Out";

        await DisplayAlert("Sign Up", "You successfully signed up for this event.", "Ok");

        //push notification that ticket is ready
        var request = new NotificationRequest
        {
            NotificationId = 1337,
            Title = $"You joined a event!",
            Subtitle = "Zuyd Events",
            Description = "You're QR ticket for entry has been created. You can find it under Tickets in the menu. Choose the event for which you want the ticket to show.",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5)
            }
        };

        await LocalNotificationCenter.Current.Show(request);

    }

    private async void OnDeleteClick(object sender, EventArgs e)
    {

        bool answer = await DisplayAlert("Delete Event", "Are you sure you want to delete this event.", "Yes", "No");

        if (answer == true)
        {

            _viewModel?.Delete?.Execute(null);
            await Navigation.PopAsync();

        }

    }

    private async void OnEditClick(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new EditEventPage(_viewModel.CurrentEvent.Id));

    }

}