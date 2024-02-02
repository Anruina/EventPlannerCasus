using Library.DataAccessService;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{

    /// <summary>
    /// This controller allows you to create, modify and view events within the database.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
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
        public EventsController(UserManager<IdentityUser> userManager, DataAccessService dataAccessService)
        {

            _userManager = userManager;
            _dataAccessService = dataAccessService;

        }

        #endregion

        #region GET

        /// <summary>
        /// Returns all events within database.
        /// </summary>
        /// <returns>All events</returns>
        [HttpGet]
        public async Task<ActionResult<List<Event>?>> GetEvents()
        {

            List<Event>? events = await _dataAccessService.GetEvents();

            if (events == null)
                return NotFound();

            return events;

        }

        /// <summary>
        /// Gets specific user events that the user organizes
        /// </summary>
        /// <returns>List of events</returns>
        [HttpGet("User")]
        public async Task<ActionResult<List<Event>?>> GetUserEvents()
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            List<Event>? events = await _dataAccessService.GetEvents(user.Id);

            if (events == null)
                return NotFound();

            return events;

        }

        /// <summary>
        /// Gets specific event from database.
        /// </summary>
        /// <param name="id">Specific event from database</param>
        /// <returns>Specific event</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Event?>> GetEvent(int id)
        {

            Event? specificEvent = await _dataAccessService.GetEvent(id);

            if (specificEvent == null)
                return NotFound();

            return specificEvent;

        }

        #endregion

        #region POST

        /// <summary>
        /// Creates new event if the logged in user is an organizer.
        /// </summary>
        /// <param name="newEvent">New event to be created</param>
        /// <returns>Created event</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Event>> PostEvent(Event newEvent)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);
            if (currentUser == null || currentUser.Type != UserType.Organizer)
                return BadRequest();

            newEvent.OrganizerId = currentUser.Id;
            Event? createdEvent = await _dataAccessService.SaveEvent(newEvent);

            if (createdEvent == null)
                return BadRequest();

            return CreatedAtAction("GetEvent", new { id = createdEvent.Id }, createdEvent);

        }

        #endregion

        #region PUT

        /// <summary>
        /// Signs up user to event.
        /// </summary>
        /// <param name="id">Id of event to sign up to</param>
        /// <param name="currentUser">Current user logged in</param>
        /// <returns>No Content</returns>
        [HttpPut("SignUp/{id}")]
        [Authorize]
        public async Task<IActionResult> SignUp(int id, User currentUser)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            Event? currentEvent = await _dataAccessService.GetEvent(id);
            User? loggedInUser = await _dataAccessService.GetUser(user.Id);

            if (currentEvent == null || loggedInUser == null || loggedInUser.Id != currentUser.Id)
                return NotFound();

            currentEvent.Users?.Add(loggedInUser);
            await _dataAccessService.SaveEvent(currentEvent);

            return NoContent();

        }

        /// <summary>
        /// Signs out user to event.
        /// </summary>
        /// <param name="id">Id of event to sign out to</param>
        /// <param name="currentUser">Current user logged in</param>
        /// <returns>No Content</returns>
        [HttpPut("SignOut/{id}")]
        [Authorize]
        public async Task<IActionResult> SignOut(int id, User currentUser)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            Event? currentEvent = await _dataAccessService.GetEvent(id);
            User? loggedInUser = await _dataAccessService.GetUser(user.Id);

            if (currentEvent == null || loggedInUser == null || loggedInUser.Id != currentUser.Id)
                return NotFound();

            currentEvent.Users?.RemoveAll(u => u.Id == loggedInUser.Id);
            await _dataAccessService.SaveEvent(currentEvent);

            return NoContent();

        }

        /// <summary>
        /// Updates event in database.
        /// </summary>
        /// <param name="id">Id of event to be updated</param>
        /// <param name="updatedEvent">Updated event</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEvent(int id, Event updatedEvent)
        {

            if (id != updatedEvent.Id)
                return BadRequest();

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);
            if (currentUser == null || currentUser.Type != UserType.Organizer)
                return BadRequest();

            if ((await _dataAccessService.GetEvent(updatedEvent.Id))?.OrganizerId != currentUser.Id || await _dataAccessService.SaveEvent(updatedEvent) == null)
                return BadRequest();

            return NoContent();

        }

        #endregion

        #region DELETE

        /// <summary>
        /// Deletes event data from database.
        /// </summary>
        /// <param name="id">Id of event to delete</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEvent(int id)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);
            if (currentUser == null || currentUser.Type != UserType.Organizer)
                return BadRequest();

            Event? deleteEvent = await _dataAccessService.GetEvent(id);
            if (deleteEvent == null || deleteEvent.OrganizerId != currentUser.Id || await _dataAccessService.DeleteEvent(id) == false)
                return BadRequest();

            return NoContent();

        }

        #endregion

    }

}
