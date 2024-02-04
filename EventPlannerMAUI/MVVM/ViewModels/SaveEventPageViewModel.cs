using EventPlannerMAUI.MobileApp;
using Library.ApiService;
using Library.Models;
using PropertyChanged;
using System.Windows.Input;

namespace EventPlannerMAUI.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class SaveEventPageViewModel
    {

        private readonly ApiService _apiService;

        public ICommand? CreateEvent { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }
        public string? EventCity { get; set; }
        public string? EventCountry { get; set; }
        public string? EventPostalCode { get; set; }
        public string? EventProvince { get; set; }
        public string? EventStreet { get; set; }
        public string? EventStreetNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? MaxParticipants { get; set; }
        public string? EventTypeName { get; set; }

        public SaveEventPageViewModel()
        {

            _apiService = ServiceLocator.apiService;

            CreateEvent = new Command(async () =>
            {

                User? user = await _apiService.GetSpecific<User>("Api/User");

                Event newEvent = new Event()
                {

                    Name = EventName,
                    Description = EventDescription,
                    Address = new Address()
                    {

                        City = EventCity,
                        Country = EventCountry,
                        PostalCode = EventPostalCode,
                        Province = EventProvince,
                        Street = EventStreet,
                        StreetNumber = EventStreetNumber,

                    },
                    StartDate = new DateTime(DateOnly.FromDateTime((DateTime)StartDate), TimeOnly.FromTimeSpan((TimeSpan)StartTime)),
                    EndDate = new DateTime(DateOnly.FromDateTime((DateTime)EndDate), TimeOnly.FromTimeSpan((TimeSpan)EndTime)),
                    OrganizerId = user.Id,
                    MaxParticipants = int.Parse(MaxParticipants),
                    Type = new EventType() { Name = EventTypeName }

                };

                Event? createdEvent = await _apiService.CreateObject<Event>("Api/Events", newEvent);

            });

        }

    }

}
