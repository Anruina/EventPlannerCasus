using Library.Models;
using Library.DataContext;
using Microsoft.EntityFrameworkCore;
using Library.DataContext.Data;

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

        #endregion
    }
}
