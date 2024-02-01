using Library.DataAccessService;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{

    /// <summary>
    /// This controller allows you to create, modify and view planned activities within the database.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PlannedActivitiesController : ControllerBase
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
        public PlannedActivitiesController(UserManager<IdentityUser> userManager, DataAccessService dataAccessService)
        {

            _userManager = userManager;
            _dataAccessService = dataAccessService;

        }

        #endregion

        #region GET

        /// <summary>
        /// Returns all planned activities within database.
        /// </summary>
        /// <returns>All planned activities</returns>
        [HttpGet]
        public async Task<ActionResult<List<PlannedActivity>?>> GetPlannedActivities()
        {

            List<PlannedActivity>? plannedActivity = await _dataAccessService.GetPlannedActivity();

            if (plannedActivity == null)
                return NotFound();

            return plannedActivity;

        }

        /// <summary>
        /// Gets specific planned activity from database.
        /// </summary>
        /// <param name="id">Specific planned activity from database</param>
        /// <returns>Specific planned activity</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PlannedActivity?>> GetPlannedActivity(int id)
        {

            PlannedActivity? specificPlannedActivity = await _dataAccessService.GetPlannedActivity(id);

            if (specificPlannedActivity == null)
                return NotFound();

            return specificPlannedActivity;

        }

        #endregion

        #region POST

        /// <summary>
        /// Creates new planned activity if the logged in user is an organizer.
        /// </summary>
        /// <param name="newPlannedActivity">New planned activity to be created</param>
        /// <returns>Created planned activity</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Activity>> PostPlannedActivity(PlannedActivity newPlannedActivity)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);
            if (currentUser == null || currentUser.Type != UserType.Organizer || newPlannedActivity.Activity == null || (await _dataAccessService.GetEvent(newPlannedActivity.Activity.EventId))?.OrganizerId != currentUser.Id)
                return BadRequest();

            PlannedActivity? createdPlannedActivity = await _dataAccessService.SavePlannedActivity(newPlannedActivity);

            if (createdPlannedActivity == null)
                return BadRequest();

            return CreatedAtAction("GetPlannedActivity", new { id = createdPlannedActivity.Id }, createdPlannedActivity);

        }

        #endregion

        #region PUT

        /// <summary>
        /// Updates planned activity in database.
        /// </summary>
        /// <param name="id">Id of planned activity to be updated</param>
        /// <param name="updatedPlannedActivity">Updated planned activity</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPlannedActivity(int id, PlannedActivity updatedPlannedActivity)
        {

            if (id != updatedPlannedActivity.Id)
                return BadRequest();

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);
            if (currentUser == null || currentUser.Type != UserType.Organizer)
                return BadRequest();

            if (updatedPlannedActivity.Activity == null || (await _dataAccessService.GetEvent(updatedPlannedActivity.Activity.EventId))?.OrganizerId != currentUser.Id || await _dataAccessService.SavePlannedActivity(updatedPlannedActivity) == null)
                return BadRequest();

            return NoContent();

        }

        #endregion

        #region DELETE

        /// <summary>
        /// Deletes planned activity data from database.
        /// </summary>
        /// <param name="id">Id of planned activity to delete</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePlannedActivity(int id)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);
            if (currentUser == null || currentUser.Type != UserType.Organizer)
                return BadRequest();

            PlannedActivity? deletePlannedActivity = await _dataAccessService.GetPlannedActivity(id);

            if (deletePlannedActivity == null || deletePlannedActivity.Activity == null)
                return BadRequest();

            Event? plannedActivityEvent = await _dataAccessService.GetEvent(deletePlannedActivity.Activity.EventId);

            if (plannedActivityEvent == null || plannedActivityEvent.OrganizerId != currentUser.Id || await _dataAccessService.DeletePlannedActivity(id) == false)
                return BadRequest();

            return NoContent();

        }

        #endregion

    }

}
