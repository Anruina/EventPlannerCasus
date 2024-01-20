using Library.DataAccessService;
using Library.Models;
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

        private readonly DataAccessService _dataAccessService;

        #endregion

        #region Constructor

        /// <summary>
        /// Sets dataAccessService, user manager and signin manager
        /// </summary>
        /// <param name="dataAccessService">Current DataAccessService used by program</param>
        public EventsController(DataAccessService dataAccessService)
        {

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

            List<Event>? events = null;

            return events;

        }

        #endregion

        #region POST

        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion

    }

}
