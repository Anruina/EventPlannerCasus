using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventDetailTabbedPage : TabbedPage
{

    private readonly int _eventId;

	public EventDetailTabbedPage(int EventId)
	{

        InitializeComponent();
        _eventId = EventId;

        OnCreate();

    }

    private void OnCreate()
    {
        
        EventInfoPage? eventInfoPage = Children.OfType<EventInfoPage>().FirstOrDefault();
        EventDetailActivitySchedule? activitySchedule = Children.OfType<EventDetailActivitySchedule>().FirstOrDefault();

        if (eventInfoPage != null)
            eventInfoPage.OnSetEventId(_eventId);

        if (activitySchedule != null)
            activitySchedule.OnSetEventId(_eventId);

    }

}