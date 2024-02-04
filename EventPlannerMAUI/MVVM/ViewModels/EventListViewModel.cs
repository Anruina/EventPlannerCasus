using Library.Models;
using System.Windows.Input;
using PropertyChanged;
using Library.ApiService;
using EventPlannerMAUI.MobileApp;

namespace EventPlannerMAUI.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class EventListViewModel
    {

        private readonly ApiService _apiService;

        private List<Event>? _events { get; set; }
        public List<Event>? Events { get; set; }
        public bool IsOrganizer { get; set; }

        public ICommand? SearchEvent { get; set; }
        public string? SearchText { get; set; }

        public EventListViewModel()
        {

            _apiService = ServiceLocator.apiService;

            SearchEvent = new Command(() =>
            {
                
                if (SearchText != null)
                    Events = _events?.Where(e => e.Name != null && e.Name.ToLower().Contains(SearchText.ToLower())).ToList();

            });

            OnRefresh();

        }

        public async void OnRefresh()
        {

            _events = await _apiService.GetList<Event>("Api/Events");
            Events = _events;

            User? user = await _apiService.GetSpecific<User>("Api/User");

            IsOrganizer = (user != null && user.Type == UserType.Organizer);

        }


    }

}
