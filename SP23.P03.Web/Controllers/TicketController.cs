using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP23.P03.Web.Data;
using SP23.P03.Web.Features.Tickets;



namespace SP23.P03.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly DbSet<Ticket> tickets;
        private readonly DataContext dataContext;

        public TicketController(DataContext dataContext)
        {
            this.dataContext = dataContext;
            tickets = dataContext.Set<Ticket>();
        }

        [HttpGet]
        public IQueryable<TicketDto> GetAllTickets()
        {
            return GetTicketDtos(tickets);
        
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<TicketDto> GetTicketbyId(int id)
        {
            var result = GetTicketDtos(tickets.Where(x => x.Id == id)).FirstOrDefault();
            
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        private static IQueryable<TicketDto> GetTicketDtos(IQueryable<Ticket> tickets)
        {
            return tickets
                .Select(x => new TicketDto
                {
                    TicketDestination = x.TicketDestination,
                    TicketDeparture = x.TicketDeparture,
                    Price= x.Price,

                });


        }


    }
}
