using Library.DataAccessService;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{

    /// <summary>
    /// This controller allows you to view addressed within the database.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {

        #region Properties

        private readonly DataAccessService _dataAccessService;

        #endregion

        #region Constructor

        /// <summary>
        /// Sets dataAccessService, user manager and signin manager
        /// </summary>
        /// <param name="dataAccessService">Current DataAccessService used by program</param>
        public AddressesController(DataAccessService dataAccessService)
        {

            _dataAccessService = dataAccessService;

        }

        #endregion

        #region GET

        /// <summary>
        /// Gets all addresses from database.
        /// </summary>
        /// <returns>All addresses</returns>
        [HttpGet]
        public async Task<ActionResult<List<Address>?>> GetAddresses()
        {

            List<Address>? addresses = await _dataAccessService.GetAddress();

            if (addresses == null)
                return NotFound();

            return addresses;

        }

        /// <summary>
        /// Gets specific address from database.
        /// </summary>
        /// <param name="id">Id of specific address</param>
        /// <returns>Specific address</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {

            Address? address = await _dataAccessService.GetAddress(id);

            if (address == null)
                return NotFound();

            return address;

        }

        #endregion

    }

}
