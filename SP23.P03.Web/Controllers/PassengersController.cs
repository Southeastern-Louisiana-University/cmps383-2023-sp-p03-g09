using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP23.P03.Web.Data;
using SP23.P03.Web.Extensions;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.Passengers;

namespace SP23.P03.Web.Controllers
{
    [Route("api/passengers")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly DbSet<Passenger> passengers;
        private readonly DataContext dataContext;
        private readonly UserManager<User> userManager;

        public PassengersController(DataContext dataContext, UserManager<User> userManager)
        {
            passengers = dataContext.Set<Passenger>();
            this.dataContext = dataContext;
            this.userManager = userManager;
        }

        [HttpGet("{id}")]
        [Authorize]

        public ActionResult<PassengerDto> GetPassengerById([FromRoute] int id)
        {
            var passenger = passengers.FirstOrDefault(x => x.Id == id);

            if (passenger == null)
            {
                return NotFound();
            }

            if (!(User.IsInRole(RoleNames.Admin) || passenger.OwnerId == User.GetCurrentUserId()))
            {
                return Forbid();
            }

            var passengerDto = new PassengerDto
            {
                Id = passenger.Id,
                OwnerId = passenger.OwnerId,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                Birthday = passenger.Birthday,
               //add age and age group??
            };

            return Ok(passengerDto);
        }
    }
}
