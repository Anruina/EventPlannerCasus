using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventInfoPage : ContentPage
{
	public EventInfoPage()
	{

		InitializeComponent();

		Event mainEvent = new Event() { Name = "EventName", MaxParticipants = 100, StartDate = new DateTime(2024, 10, 24, 10, 30, 0), EndDate = new DateTime(2024, 10, 24, 17, 0, 0), Description="This is an event description :)" };
		EventData.BindingContext = mainEvent;

	}
}