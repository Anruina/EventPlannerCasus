using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;
using PropertyChanged;

namespace EventPlannerMAUI.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class EventInfoPageViewModel
    {

        private readonly ApiService _apiService;

        public bool SignedIn { get; set; }
        public bool IsOwner { get; set; }

        public Event? CurrentEvent { get; set; }
        public User? CurrentUser { get; set; }

        public Command? SignUp { get; set; }
        public Command? SignOut { get; set; }
        public Command? Delete { get; set; }

        public EventInfoPageViewModel()
        {

            _apiService = ServiceLocator.apiService;

            SignUp = new Command(async () =>
            {

                if (CurrentUser != null && CurrentEvent != null)
                    await _apiService.UpdateObject<User>("Api/Events/SignUp/", CurrentEvent.Id, new User { Id = CurrentUser.Id });

            });

            SignOut = new Command(async () =>
            {

                if (CurrentUser != null && CurrentEvent != null)
                    await _apiService.UpdateObject<User>("Api/Events/SignOut/", CurrentEvent.Id, new User { Id = CurrentUser.Id });

            });

            Delete = new Command(async () =>
            {

                if (CurrentEvent != null)
                    await _apiService.DeleteObject("Api/Events/", CurrentEvent.Id);

            });

        }

        public async Task OnRefresh(int eventId)
        {

            CurrentEvent = await _apiService.GetSpecific<Event>("Api/Events/", eventId);
            CurrentUser = await _apiService.GetSpecific<User>("Api/User");

            if (CurrentUser != null && CurrentEvent?.Users != null)
                SignedIn = (CurrentEvent.Users.FirstOrDefault(u => u.Id == CurrentUser.Id) != null);
            else
                SignedIn = false;

            IsOwner = (CurrentEvent.OrganizerId == CurrentUser.Id);

        }

    }

}
