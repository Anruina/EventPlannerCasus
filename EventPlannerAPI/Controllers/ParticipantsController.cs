using Library.DataAccessService;
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
        private readonly SignInManager<IdentityUser>? _signInManager;
        private readonly DataAccessService _dataAccessService;

        #endregion

        #region Contructor

        /// <summary>
        /// Sets dataAccessService, user manager and signin manager
        /// </summary>
        /// <param name="userManager">Used for creating and deleting users</param>
        /// <param name="signInManager">Used for loggin in and out</param>
        /// <param name="dataAccessService">Current DataAccessService used by program</param>
        public ParticipantsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, DataAccessService dataAccessService)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _dataAccessService = dataAccessService;

        }

        #endregion

        #region ACCOUNT

        

        #endregion

    }

}
