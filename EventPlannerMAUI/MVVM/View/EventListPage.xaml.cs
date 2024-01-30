using System.Collections.ObjectModel;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventListPage : ContentPage
{

    // Verzameling voor het bijhouden van evenementen
    private ObservableCollection<Event> events;

    public EventListPage()
    {

        InitializeComponent();

        // Instantieer de verzameling
        events = new ObservableCollection<Event>();

        // Voeg wat dummy-evenementen toe voor testdoeleinden
        events.Add(new Event { Title = "Evenement 1 (Afbeeldingsdetectie)", Date = "1 januari 2024", Time = "10:00-11:00", Location = "B.3.206", Description = "In dit project wordt gedomstreerd hoe je iemand kan herkennen in een afbeelding" });
        events.Add(new Event { Title = "Evenement 2 (Nummerherkenning)", Date = "1 januari 2024", Time = "11:00-12:00", Location = "B.3.217", Description = "Dit is evenement 2." });
        events.Add(new Event { Title = "Pauze", Date = "1 januari 2024", Time = "12:00-13:00", Location = "Kantine", Description = "Algemene pauze voor bezoekers en sprekers" });
        events.Add(new Event { Title = "Evenement 3 (Covid-19 en Data science )", Date = "1 januari 2024", Time = "13:00-14:00", Location = "B.3.217", Description = "Dit is evenement 3." });
        events.Add(new Event { Title = "Evenement 4 (Flesdetectie)", Date = "1 januari 2024", Time = "14:00-15:00", Location = "B.3.306", Description = "Dit is evenement 4." });

        // Koppel de verzameling aan de ListView
        eventListView.ItemsSource = events;

    }

    private async void OnAddEventClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new SaveEventPage());

    }

    private async void ShowMap(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new NavigationPage(new EventDetailTabbedPage()));

    }

    // Een eenvoudige klasse om evenementgegevens bij te houden
    public class Event
    {
        public string? Title { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
    }

}