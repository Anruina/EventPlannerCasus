using Library.DataAccessService;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{

    /// <summary>
    /// This controller allows you to modify and view organizers within the database.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizersController : ControllerBase
    {

        #region Properties

        private readonly UserManager<IdentityUser>? _userManager;
        private readonly DataAccessService _dataAccessService;

        #endregion

        #region Constructor

        /// <summary>
        /// Sets dataAccessService, user manager and signin manager
        /// </summary>
        /// <param name="userManager">Used for creating and deleting users</param>
        /// <param name="dataAccessService">Current DataAccessService used by program</param>
        public OrganizersController(UserManager<IdentityUser> userManager, DataAccessService dataAccessService)
        {

            _userManager = userManager;
            _dataAccessService = dataAccessService;

        }

        #endregion

        #region GET

        /// <summary>
        /// Returns specific organizer with private data.
        /// </summary>
        /// <returns>Specific organizer</returns>
        [HttpGet]
        public async Task<ActionResult<Organizer>> GetOrganizer()
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            Organizer? organizer = await _dataAccessService.GetOrganizer(user.Id);

            if (organizer == null)
                return NotFound();

            return organizer;

        }

        #endregion

        #region POST

        /// <summary>
        /// Participant gets removed and converted to organizer.
        /// </summary>
        /// <param name="id">Id of participant that has to become organizer</param>
        /// <returns>Created organizer</returns>
        [HttpPost("{id}")]
        [Authorize]
        public async Task<ActionResult<Organizer>> PostOrganizer(int id)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            Participant? participant = await _dataAccessService.GetParticipant(user.Id);
            if (participant == null || participant.Id != id || participant.AuthenticationId != user.Id)
                return BadRequest();

            Organizer newOrganizer = new Organizer() { Name = participant.Name, MailAddress = participant.MailAddress, PhoneNumber = participant.PhoneNumber, Address = participant.Address, AuthenticationId = participant.AuthenticationId, VisitedEvents = participant.VisitedEvents, VisitedActivities = participant.VisitedActivities };

            await _dataAccessService.DeleteParticipant(user.Id);
            Organizer? createdOrganizer = await _dataAccessService.SaveOrganizer(newOrganizer);

            if (createdOrganizer == null)
                return BadRequest();

            return CreatedAtAction("GetOrganizer", new { id = createdOrganizer.Id }, createdOrganizer);

        }

        #endregion

        #region PUT

        /// <summary>
        /// Updates current logged in organizer.
        /// </summary>
        /// <param name="id">Id of current logged in organizer</param>
        /// <param name="organizer">Updated organizer</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoggedInUser(int id, Organizer organizer)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            if (organizer.Id != id || organizer.AuthenticationId != user.Id)
                return BadRequest();

            await _dataAccessService.SaveOrganizer(organizer);

            return NoContent();

        }

        #endregion

    }

}