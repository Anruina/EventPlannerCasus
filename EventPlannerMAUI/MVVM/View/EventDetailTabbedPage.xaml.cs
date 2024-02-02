using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventDetailTabbedPage : TabbedPage
{

    private readonly ApiService _apiService;
    private readonly int _eventId;

	public EventDetailTabbedPage(int EventId)
	{

        InitializeComponent();
        
        _apiService = ServiceLocator.apiService;
        _eventId = EventId;

        OnCreate();

    }

    private async void OnCreate()
    {

        Event? currentEvent = await _apiService.GetSpecific<Event>("Api/Events/", _eventId);
        
        EventInfoPage? eventInfoPage = Children.OfType<EventInfoPage>().FirstOrDefault();
        EventDetailActivitySchedule? activitySchedule = Children.OfType<EventDetailActivitySchedule>().FirstOrDefault();

        if (eventInfoPage != null)
            eventInfoPage.OnSetEventId(_eventId);

        if (activitySchedule != null)
            activitySchedule.EventId = _eventId;

    }

}