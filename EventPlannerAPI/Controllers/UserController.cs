using Library.ApiModels;
using Library.DataAccessService;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{

    /// <summary>
    /// This controller allows you to create, modify and view users within the database.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Properties

        private readonly UserManager<IdentityUser>? _userManager;
        private readonly SignInManager<IdentityUser>? _signInManager;
        private readonly DataAccessService _dataAccessService;

        #endregion

        #region Constructor

        /// <summary>
        /// Sets dataAccessService, user manager and signin manager
        /// </summary>
        /// <param name="userManager">Used for creating and deleting users</param>
        /// <param name="signInManager">Used for loggin in and out</param>
        /// <param name="dataAccessService">Current DataAccessService used by program</param>
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, DataAccessService dataAccessService)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _dataAccessService = dataAccessService;

        }

        #endregion

        #region Account

        /// <summary>
        /// Registers a new user to the database.
        /// </summary>
        /// <param name="newAccountModel">Username and password of the new user</param>
        /// <returns>Was able to create user</returns>
        [HttpPost("register")]
        public async Task<ActionResult<AccountModel>> Register([FromBody] AccountModel newAccountModel)
        {

            if (string.IsNullOrEmpty(newAccountModel.Username) || string.IsNullOrEmpty(newAccountModel.Password))
                return BadRequest("Email and password are required.");

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser newUser = new IdentityUser
            {

                UserName = newAccountModel.Username,
                Email = newAccountModel.Username

            };

            var result = await _userManager.CreateAsync(newUser, newAccountModel.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            Participant newParticipant = new Participant
            {

                Name = newAccountModel.Username,
                VisitedActivities = new List<PlannedActivity>(),
                VisitedEvents = new List<Event>(),
                AuthenticationId = newUser.Id

            };

            await _dataAccessService.SaveParticipant(newParticipant);

            return new AccountModel { Username = "", Password = "" };

        }

        /// <summary>
        /// Login to API with user.
        /// </summary>
        /// <param name="newAccountModel">Username and password of user</param>
        /// <returns>Was able to login with username and password</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AccountModel>> Login([FromBody] AccountModel newAccountModel)
        {

            if (string.IsNullOrEmpty(newAccountModel.Username) || string.IsNullOrEmpty(newAccountModel.Password))
                return BadRequest("Email and password are required.");

            if (_signInManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: signInManager is null.");

            var result = await _signInManager.PasswordSignInAsync(newAccountModel.Username, newAccountModel.Password, false, false);

            if (!result.Succeeded)
                return BadRequest("Invalid login attempt. Details: " + string.Join(", ", result.ToString()));

            return new AccountModel { Username = "", Password = "" };

        }

        /// <summary>
        /// Logs out user from api.
        /// </summary>
        /// <returns>Was logout succesful</returns>
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {

            if (_signInManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: signInManager is null.");

            await _signInManager.SignOutAsync();

            return Ok("Logout succesful");

        }

        /// <summary>
        /// Deletes user account
        /// </summary>
        /// <returns>Was able to delete user</returns>
        [Authorize]
        [HttpDelete("account")]
        public async Task<IActionResult> DeleteAccount()
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            if (_signInManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: signInManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found to delete.");

            string userId = user.Id;

            await _signInManager.SignOutAsync();
            IdentityResult result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return BadRequest("\"Failed to delete account. Details: " + result.Errors.ToString());

            Participant? participant = await _dataAccessService.GetParticipant(userId);
            if (participant == null)
            {

                if (await _dataAccessService.GetOrganizer(userId) == null)
                    return BadRequest();

                await _dataAccessService.DeleteOrganizer(userId);

            }
            else
                await _dataAccessService.DeleteParticipant(userId);

            return Ok("Deleted account.");

        }

        #endregion

    }

}
