using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class ActivityDetailPage : ContentPage
{

	private readonly ApiService _apiService;
	private readonly int _activityId;

	public ActivityDetailPage(int activityId)
	{

		InitializeComponent();

		_apiService = ServiceLocator.apiService;
        _activityId = activityId;

		OnCreate();

	}

	private async void OnCreate()
	{

		Activity? currentActivity = await _apiService.GetSpecific<Activity>("Api/Activities/", _activityId);

		if (currentActivity != null)
			BindingContext = currentActivity;

    }

}