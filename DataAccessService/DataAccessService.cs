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

        #region Participant

        #region Get
        /// <summary>
        /// Gets participant by authenticationId of the participant.
        /// </summary>
        /// <param name="authenticationId"></param>
        /// <returns>Participant with sensitive data</returns>
        public async Task<Participant?> GetParticipant(string authenticationId)
        {

           if (_applicationContext?.Participants == null)
                return null;

           Participant? participant = await _applicationContext.Participants.Include(p => p.VisitedActivities).Include(p => p.VisitedEvents).FirstOrDefaultAsync(p => p.AuthenticationId == authenticationId);

           return participant;

        }

        #endregion

        #region Save
        /// <summary>
        /// Create & Update Participant
        /// </summary>
        /// <param name="participant"></param>
        /// <returns></returns>
        public async Task<Participant?> SaveParticipant(Participant participant)
        {

            if(_applicationContext?.Participants == null)
                return null;

            _applicationContext.Participants.Update(participant);
            await _applicationContext.SaveChangesAsync();

            return participant;

        }

        #endregion

        #region Delete
        /// <summary>
        /// Deletes a participant based on the authenticationId.
        /// check if participant exists, then gets the participant info, if info is not found returns a false otherwise deletes the participant.
        /// </summary>
        /// <param name="authenticationId"></param>
        /// <returns>true/false</returns>
        public async Task<bool> DeleteParticipant(string authenticationId)
        {

            if (_applicationContext?.Participants == null)
                return false;

            Participant? participant = await _applicationContext.Participants.FirstOrDefaultAsync(p => p.AuthenticationId == authenticationId);

            if (participant == null)
                return false;

            _applicationContext.Participants.Remove(participant);
            await _applicationContext.SaveChangesAsync();

            return true;

        }

        #endregion

        #endregion

        #region Organizer

        #region Get
        public async Task<Organizer?> GetOrganizer(string authenticationId)
        {

            if(_applicationContext?.Organizers == null)
                return null;

            Organizer? organizer = await _applicationContext.Organizers.Include(o => o.OrganizedEvents).FirstOrDefaultAsync(o => o.AuthenticationId == authenticationId);
            
            return organizer;

        }
        #endregion

        #region Save
        public async Task<Organizer?> SaveOrganizer(Organizer organizer)
        {

            if (_applicationContext?.Organizers == null)
                return null;

            _applicationContext.Organizers.Update(organizer);
            await _applicationContext.SaveChangesAsync();

            return organizer;

        }

        #endregion

        #region Delete
        public async Task<bool> DeleteOrganizer(string authenticationId)
        {

            if (_applicationContext?.Organizers == null)
                return false;

            Organizer? organizer = await _applicationContext.Organizers.FirstOrDefaultAsync(p => p.AuthenticationId == authenticationId);

            if (organizer == null)
                return false;

            _applicationContext.Organizers.Remove(organizer);
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

            Activity? activity = await _applicationContext.Activities.Include(a => a.Event).Include(a => a.PlannedActivities).FirstOrDefaultAsync(a => a.Id == id);

            if (activity == null)
                return null;

            return activity;

        }

        public async Task<List<Activity>?> GetAllActivites()
        {

            if (_applicationContext?.Activities == null)
                return null;

            return await _applicationContext.Activities.Include(a => a.Event).Include(a => a.PlannedActivities).ToListAsync();

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
        public async Task<Event?> GetEvent(int id)
        {

            if (_applicationContext?.Events == null)
                return null;

            Event? evenement = await _applicationContext.Events.Include(e => e.Activities).Include(e => e.PlannedActivities).Include(e => e.Type).FirstOrDefaultAsync(e => e.Id == id);

            if (evenement == null)
                return null;

            return evenement;

        }

        public async Task<List<Event>?> GetAllEvents ()
        {

            if (_applicationContext?.Events == null)
                return null;

            return await _applicationContext.Events.Include(e => e.Activities).Include(e => e.PlannedActivities).Include(e => e.Type).ToListAsync();

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

            Event? evenement = await _applicationContext.Events.FirstOrDefaultAsync(a => a.Id == eventementId);

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
        public async Task<EventType?> GetEventType(int id)
        {

            if (_applicationContext?.EventTypes == null)
                return null;

            EventType? eventType = await _applicationContext.EventTypes.Include(et => et.Events).FirstOrDefaultAsync(et => et.Id == id);

            if (eventType == null)
                return null;

            return eventType;

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

            EventType? eventType = await _applicationContext.EventTypes.FirstOrDefaultAsync(a => a.Id == eventTypeId);

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
        #endregion

        #region Save
        #endregion

        #region Delete
        #endregion

        #endregion

        #region PlannedActivity

        #region Get & Get All
        #endregion

        #region Save
        #endregion

        #region Delete
        #endregion

        #endregion

        #endregion
    }
}
