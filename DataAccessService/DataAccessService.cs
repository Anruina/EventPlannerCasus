using Library.Models;
using Library.DataContext;
using Microsoft.EntityFrameworkCore;
using Library.DataContext.Data;
using System.Runtime.CompilerServices;

namespace Library.DataAccessService
{

    /// <summary>
    /// This class functions as CRUD. Applications will interact with this class to communicate to the database.
    /// </summary>
    public class DataAccessService
    {

        #region Properties

        private readonly ApplicationDbContext? _applicationContext;

        #endregion
        
        #region Constructor
        
        /// Initializes the _applicationContext
        public DataAccessService(ApplicationDbContext? applicationContext)
        {

            _applicationContext = applicationContext;
        
        }

        #endregion

        #region Methods

        #region User

        #region Get

        public async Task<User?> GetUser(string authenticationId)
        {

            if(_applicationContext?.Users == null)
                return null;

            User? user = await _applicationContext.Users.Include(u => u.VisitedEvents).Include(u => u.Address).Include(u => u.VisitedActivities).FirstOrDefaultAsync(o => o.AuthenticationId == authenticationId);
            
            return user;

        }

        #endregion

        #region Save

        public async Task<User?> SaveUser(User user)
        {

            if (_applicationContext?.Users == null)
                return null;

            _applicationContext.Users.Update(user);
            await _applicationContext.SaveChangesAsync();

            return user;

        }

        #endregion

        #region Delete
        public async Task<bool> DeleteUser(string authenticationId)
        {

            if (_applicationContext?.Users == null)
                return false;

            User? user = await _applicationContext.Users.FirstOrDefaultAsync(p => p.AuthenticationId == authenticationId);

            if (user == null)
                return false;

            _applicationContext.Users.Remove(user);
            await _applicationContext.SaveChangesAsync();

            return true;

        }
        #endregion

        #endregion

        #region Activity

        #region Get & Get All
        public async Task<Activity?> GetActivity(int id)
        {

            if (_applicationContext?.Activities == null)
                return null;

            Activity? activity = await _applicationContext.Activities.Include(a => a.Event).FirstOrDefaultAsync(a => a.Id == id);

            if (activity == null)
                return null;

            return activity;

        }

        public async Task<List<Activity>?> GetActivites()
        {

            if (_applicationContext?.Activities == null)
                return null;

            return await _applicationContext.Activities.Include(a => a.Event).ToListAsync();

        }

        #endregion

        #region Save
        public async Task<Activity?> SaveActivity(Activity activity)
        {
            if (_applicationContext?.Activities == null)
                return null;

            _applicationContext.Activities.Update(activity);
            await _applicationContext.SaveChangesAsync();

            return activity;
        }
        #endregion

        #region Delete
        public async Task<bool?> DeleteActivity(int activityId)
        {

            if (_applicationContext?.Activities == null)
                return false;

            Activity? activity = await _applicationContext.Activities.FirstOrDefaultAsync(a => a.Id == activityId);

            if (activity == null)
                return false;

            _applicationContext.Activities.Remove(activity);
            await _applicationContext.SaveChangesAsync();

            return true;

        }
        #endregion

        #endregion

        #region Event

        #region Get & Get All

        public async Task<List<Event>?> GetEvents()
        {

            if (_applicationContext?.Events == null)
                return null;

            return await _applicationContext.Events.Include(e => e.Activities).Include(e => e.Address).Include(e => e.Type).ToListAsync();

        }

        public async Task<List<Event>?> GetEvents(string authenticationId)
        {

            if (_applicationContext?.Events == null || _applicationContext?.Users == null)
                return null;

            User? currentUser = await _applicationContext.Users.FirstOrDefaultAsync(u => u.AuthenticationId == authenticationId);

            if (currentUser == null)
                return null;

            return await _applicationContext.Events.Include(e => e.Activities).Include(e => e.Address).Include(e => e.Type).Where(e => e.OrganizerId == currentUser.Id).ToListAsync();

        }

        public async Task<Event?> GetEvent(int id)
        {

            if (_applicationContext?.Events == null)
                return null;

            Event? evenement = await _applicationContext.Events.Include(e => e.Activities).Include(e => e.Address).Include(e => e.Type).Include(e => e.Users).FirstOrDefaultAsync(e => e.Id == id);

            return evenement;

        }

        #endregion

        #region Save
        public async Task<Event?> SaveEvent(Event evenement)
        {

            if (_applicationContext?.Events == null)
                return null;

            _applicationContext.Events.Update(evenement);
            await _applicationContext.SaveChangesAsync();

            return evenement;
        }

        #endregion

        #region Delete
        public async Task<bool?> DeleteEvent(int eventementId)
        {

            if (_applicationContext?.Events == null)
                return false;

            Event? evenement = await _applicationContext.Events.FirstOrDefaultAsync(e => e.Id == eventementId);

            if (evenement == null)
                return false;

            _applicationContext.Events.Remove(evenement);
            await _applicationContext.SaveChangesAsync();

            return true;

        }

        #endregion

        #endregion

        #region EventType

        #region Get

        public async Task<List<EventType>?> GetEventTypes()
        {

            if (_applicationContext?.EventTypes == null)
                return null;

            return await _applicationContext.EventTypes.Include(et => et.Events).ToListAsync();

        }

        public async Task<EventType?> GetEventType(int id)
        {

            if (_applicationContext?.EventTypes == null)
                return null;

            return await _applicationContext.EventTypes.Include(et => et.Events).FirstOrDefaultAsync(et => et.Id == id);

        }

        #endregion

        #region Save
        public async Task<EventType?> SaveEventType(EventType eventType)
        {
            if (_applicationContext?.EventTypes == null)
                return null;

            _applicationContext.EventTypes.Update(eventType);
            await _applicationContext.SaveChangesAsync();

            return eventType;
        }

        #endregion

        #region Delete
        public async Task<bool?> DeleteEventType(int eventTypeId)
        {

            if (_applicationContext?.EventTypes == null)
                return false;

            EventType? eventType = await _applicationContext.EventTypes.FirstOrDefaultAsync(et => et.Id == eventTypeId);

            if (eventType == null)
                return false;

            _applicationContext.EventTypes.Remove(eventType);
            await _applicationContext.SaveChangesAsync();

            return true;

        }
        #endregion

        #endregion

        #region Address

        #region Get & Get All
        public async Task<Address?> GetAddress(int id)
        {

            if (_applicationContext?.Addresses == null)
                return null;

            Address? address = await _applicationContext.Addresses.Include(a => a.Events).Include(a => a.Users).FirstOrDefaultAsync(a => a.Id == id);

            if (address == null)
                return null;

            return address;

        }

        public async Task<List<Address>?> GetAddress()
        {

            if (_applicationContext?.Addresses == null)
                return null;

            return await _applicationContext.Addresses.Include(a => a.Events).Include(a => a.Users).ToListAsync();

        }
        #endregion

        #region Save
        public async Task<Address?> SaveAddress(Address address)
        {
            if (_applicationContext?.Addresses == null)
                return null;

            _applicationContext.Addresses.Update(address);
            await _applicationContext.SaveChangesAsync();

            return address;
        }

        #endregion

        #region Delete
        public async Task<bool?> DeleteAddress(int addressId)
        {

            if (_applicationContext?.Addresses == null)
                return false;

            Address? address = await _applicationContext.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);

            if (address == null)
                return false;

            _applicationContext.Addresses.Remove(address);
            await _applicationContext.SaveChangesAsync();

            return true;

        }
        #endregion

        #endregion

        #endregion

    }
}
