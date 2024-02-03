using Library.DataAccessService;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{

    /// <summary>
    /// This controller allows you to view, create, edit and delete activiteis within the database.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
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
        public ActivitiesController(UserManager<IdentityUser> userManager, DataAccessService dataAccessService)
        {

            _userManager = userManager;
            _dataAccessService = dataAccessService;

        }

        #endregion

        #region GET

        /// <summary>
        /// Returns all activities within database.
        /// </summary>
        /// <returns>All activities</returns>
        [HttpGet]
        public async Task<ActionResult<List<Activity>?>> GetActivities()
        {

            List<Activity>? activity = await _dataAccessService.GetActivites();

            if (activity == null)
                return NotFound();

            return activity;

        }

        /// <summary>
        /// Gets specific activity from database.
        /// </summary>
        /// <param name="id">Specific activity from database</param>
        /// <returns>Specific activity</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity?>> GetActivity(int id)
        {

            Activity? specificActivity = await _dataAccessService.GetActivity(id);

            if (specificActivity == null)
                return NotFound();

            return specificActivity;

        }

        #endregion

        #region POST

        /// <summary>
        /// Creates new activity if the logged in user is an organizer.
        /// </summary>
        /// <param name="newActivity">New activity to be created</param>
        /// <returns>Created activity</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Activity>> PostActivity(Activity newActivity)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);
            if (currentUser == null || currentUser.Type != UserType.Organizer || (await _dataAccessService.GetEvent(newActivity.EventId))?.OrganizerId != currentUser.Id)
                return BadRequest();

            Activity? createdActivity = await _dataAccessService.SaveActivity(newActivity);

            if (createdActivity == null)
                return BadRequest();

            return CreatedAtAction("GetActivity", new { id = createdActivity.Id }, createdActivity);

        }

        #endregion

        #region PUT

        /// <summary>
        /// Updates activity in database.
        /// </summary>
        /// <param name="id">Id of activity to be updated</param>
        /// <param name="updatedActivity">Updated activity</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutActivity(int id, Activity updatedActivity)
        {

            if (id != updatedActivity.Id)
                return BadRequest();

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);
            Event? currentEvent = await _dataAccessService.GetEvent(updatedActivity.EventId);

            if (currentUser == null || currentUser.Type != UserType.Organizer || currentEvent?.OrganizerId != currentUser.Id)
                return BadRequest();

            Activity? activity = currentEvent.Activities?.FirstOrDefault(a => a.Id == id);
            if (activity == null)
                return BadRequest();

            activity.Name = updatedActivity.Name;
            activity.StartTime = updatedActivity.StartTime;
            activity.EndTime = updatedActivity.EndTime;
            activity.Description = updatedActivity.Description;
            activity.Room = updatedActivity.Room;

            if (await _dataAccessService.SaveActivity(activity) == null)
                return BadRequest();

            return NoContent();

        }

        #endregion

        #region DELETE

        /// <summary>
        /// Deletes activity data from database.
        /// </summary>
        /// <param name="id">Id of activity to delete</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteActivity(int id)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);
            if (currentUser == null || currentUser.Type != UserType.Organizer)
                return BadRequest();

            Activity? deleteActivity = await _dataAccessService.GetActivity(id);

            if (deleteActivity == null)
                return BadRequest();

            Event? activityEvent = await _dataAccessService.GetEvent(deleteActivity.EventId);

            if (activityEvent == null || activityEvent.OrganizerId != currentUser.Id || await _dataAccessService.DeleteActivity(id) == false)
                return BadRequest();

            return NoContent();

        }

        #endregion

    }

}
