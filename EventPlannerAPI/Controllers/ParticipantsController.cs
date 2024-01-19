using Library.DataAccessService;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {

        #region Properties

        private readonly UserManager<IdentityUser>? _userManager;
        private readonly DataAccessService _dataAccessService;

        #endregion

        #region Contructor

        /// <summary>
        /// Sets dataAccessService, user manager and signin manager
        /// </summary>
        /// <param name="userManager">Used for creating and deleting users</param>
        /// <param name="dataAccessService">Current DataAccessService used by program</param>
        public ParticipantsController(UserManager<IdentityUser> userManager, DataAccessService dataAccessService)
        {

            _userManager = userManager;
            _dataAccessService = dataAccessService;

        }

        #endregion

        #region GET

        /// <summary>
        /// Returns specific participant with private data.
        /// </summary>
        /// <returns>Specific participant</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Participant>> GetParticapant()
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            Participant? participant = await _dataAccessService.GetParticipant(user.Id);

            if (participant == null)
                return NotFound();

            return participant;

        }

        #endregion

        #region PUT

        /// <summary>
        /// Updates current logged in participant.
        /// </summary>
        /// <param name="id">Id of current logged in participant</param>
        /// <param name="participant">Updated participant</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateLoggedInUser(int id, Participant participant)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            if (participant.Id != id || participant.AuthenticationId != user.Id)
                return BadRequest();

            await _dataAccessService.SaveParticipant(participant);

            return NoContent();

        }

        #endregion

    }

}
