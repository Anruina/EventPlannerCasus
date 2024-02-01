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

            User user = new User
            {

                Name = newAccountModel.Username,
                VisitedActivities = new List<Activity>(),
                VisitedEvents = new List<Event>(),
                AuthenticationId = newUser.Id,
                Type = UserType.Participant

            };

            await _dataAccessService.SaveUser(user);

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

            User? deletedUser = await _dataAccessService.GetUser(userId);
            if (deletedUser == null)
                return BadRequest();
            else
                await _dataAccessService.DeleteUser(userId);

            return Ok("Deleted account.");

        }

        #endregion

        #region GET

        /// <summary>
        /// Returns specific user with private data.
        /// </summary>
        /// <returns>Specific user</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<User>> GetUser()
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            User? currentUser = await _dataAccessService.GetUser(user.Id);

            if (currentUser == null)
                return NotFound();

            return currentUser;

        }

        #endregion

        #region PUT

        /// <summary>
        /// Updates current logged in user.
        /// </summary>
        /// <param name="id">Id of current logged in user</param>
        /// <param name="updatedUser">Updated user</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoggedInUser(int id, User updatedUser)
        {

            if (_userManager == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: UserManager is null.");

            IdentityUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound("No user was found.");

            if (updatedUser.Id != id || updatedUser.AuthenticationId != user.Id)
                return BadRequest();

            await _dataAccessService.SaveUser(updatedUser);

            return NoContent();

        }

        #endregion

    }

}
