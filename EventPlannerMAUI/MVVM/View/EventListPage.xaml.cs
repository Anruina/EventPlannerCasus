using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace EventPlannerMAUI.MVVM.View
{
    public partial class EventListPage : ContentPage
    {

        public EventListPage()
        {

            InitializeComponent();

        }

        public EventListPage(ObservableCollection<Event> events)
        {
            InitializeComponent();

            // Toon de evenementen in de EventListPage
            eventListView.ItemsSource = events;
        }
    }
}
