using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventInfoPage : ContentPage
{
	public EventInfoPage()
	{

		InitializeComponent();

		Library.Models.Event mainEvent = new Library.Models.Event() { Name = "EventName", MaxParticipants = 100, StartDate = new DateTime(2024, 10, 24, 10, 30, 0), EndDate = new DateTime(2024, 10, 24, 17, 0, 0) };
		EventData.BindingContext = mainEvent;

	}
}