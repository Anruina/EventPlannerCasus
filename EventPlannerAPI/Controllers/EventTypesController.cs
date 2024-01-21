using Library.DataAccessService;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{

    /// <summary>
    /// This controller allows you to view, create and edit event types within the database.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypesController : ControllerBase
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
        public EventTypesController(UserManager<IdentityUser> userManager, DataAccessService dataAccessService)
        {

            _userManager = userManager;
            _dataAccessService = dataAccessService;

        }

        #endregion

        #region GET

        /// <summary>
        /// Gets all event types from database.
        /// </summary>
        /// <returns>All event types</returns>
        [HttpGet]
        public async Task<ActionResult<List<EventType>?>> GetEventTypes()
        {

            List<EventType>? eventTypes = await _dataAccessService.GetEventTypes();

            if (eventTypes == null)
                return NotFound();

            return eventTypes;

        }

        /// <summary>
        /// Gets specific event type from database.
        /// </summary>
        /// <param name="id">Id of specific event type</param>
        /// <returns>Specific event type</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EventType>> GetEventType(int id)
        {

            EventType? eventType = await _dataAccessService.GetEventType(id);

            if (eventType == null)
                return NotFound();

            return eventType;

        }

        #endregion

        #region POST

        /// <summary>
        /// Creates new event type if the logged in user is an organizer.
        /// </summary>
        /// <param name="newEventType">New event type to be created</param>
        /// <returns>Created event type</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EventType>> PostEventType(EventType newEventType)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            Organizer? organizer = await _dataAccessService.GetOrganizer(user.Id);
            if (organizer == null)
                return BadRequest();

            EventType? createdEventType = await _dataAccessService.SaveEventType(newEventType);

            if (createdEventType == null)
                return BadRequest();

            return CreatedAtAction("GetEventType", new { id = createdEventType.Id }, createdEventType);

        }

        #endregion

        #region PUT

        /// <summary>
        /// Updates event type in database.
        /// </summary>
        /// <param name="id">Id of event type to be updated</param>
        /// <param name="updatedEventType">Updated event type</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEventType(int id, EventType updatedEventType)
        {

            if (id != updatedEventType.Id)
                return BadRequest();

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            Organizer? organizer = await _dataAccessService.GetOrganizer(user.Id);
            if (organizer == null)
                return BadRequest();

            if ((await _dataAccessService.GetEvent(updatedEventType.Id))?.Organizer != organizer || await _dataAccessService.SaveEventType(updatedEventType) == null)
                return BadRequest();

            return NoContent();

        }

        #endregion

    }

}
