using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SP23.P03.Web.Data;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.Tickets;
using SP23.P03.Web.Features.Sales;
using SP23.P03.Web.Features.Products;

namespace SP23.P03.Web.Controllers;

[Route("api/SaleEvents")]
[ApiController]
public class SaleEventsController : ControllerBase
{
    private readonly DataContext dataContext;

    public SaleEventsController(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

 
    
    [HttpPut("{saleEventId}/add-ticket/{ticketId}"), Authorize(Roles = RoleNames.Admin)]
    public ActionResult<SaleEventsDto> AddProductToSale(int saleEventId, int productId, SaleEventsProductsDto body)
    {
        var saleEvents = dataContext.Set<SaleEvents>();
        var products = dataContext.Set<Ticket>();

        var product = products.FirstOrDefault(x => x.Id == productId);
        var saleEvent = saleEvents.FirstOrDefault(x => x.Id == saleEventId);

        if (product == null || saleEvent == null)
        {
            return NotFound();
        }

        var productSales = dataContext.Set<SaleEventsProduct>();
        productSales.Add(new SaleEventsProduct
        {
            Ticket = product,
            SaleEvents = saleEvent,
            SaleEventPrice = body.SaleEventsPrice
        });
        dataContext.SaveChanges();
        return Ok();
    }

    [HttpGet("{id}")]
    public ActionResult<SaleEventsDto> GetSaleEventById(int id)
    {
        var saleEvents = dataContext.Set<SaleEvents>();
        var result = GetSaleEventDtos(saleEvents).FirstOrDefault(x => x.Id == id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    // fixed
    [HttpPost, Authorize(Roles = RoleNames.Admin)]
    public ActionResult<SaleEventsDto> CreateSalesEvent(SaleEventsDto saleEventDto)
    {
        if (saleEventDto.StartUtc >= saleEventDto.EndUtc)
        {
            return BadRequest("You have a Bad Request");
        }

        var hasOverlap = dataContext
            .Set<SaleEvents>()
            .Any(x => x.StartUtc <= saleEventDto.StartUtc && saleEventDto.StartUtc <= x.EndUtc ||
                      x.StartUtc <= saleEventDto.EndUtc && saleEventDto.EndUtc <= x.EndUtc ||
                      saleEventDto.StartUtc <= x.StartUtc && x.StartUtc <= saleEventDto.EndUtc ||
                      saleEventDto.StartUtc <= x.EndUtc && x.EndUtc <= saleEventDto.EndUtc);

        if (hasOverlap)
        {
            return BadRequest();
        }

        var saleEvent = new SaleEvents
        {
            TicketDestination = saleEventDto.TicketDestination,
            StartUtc = saleEventDto.StartUtc,
            EndUtc = saleEventDto.EndUtc
        };

        dataContext.Add(saleEvent);
        dataContext.SaveChanges();
        saleEventDto.Id = saleEvent.Id;

        return CreatedAtAction(nameof(GetSaleEventById), new { id = saleEventDto.Id }, saleEventDto);
    }
    [HttpGet("active")]
    public ActionResult<SaleEventsDto> GetActiveSale()
    {
        var saleEvents = dataContext.Set<SaleEvents>();
        var timeNow = DateTime.Now;
        var result = GetSaleEventDtos(saleEvents).FirstOrDefault(x => x.StartUtc <= timeNow && timeNow <= x.EndUtc);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }


    private static IQueryable<SaleEventsDto> GetSaleEventDtos(IQueryable<SaleEvents> saleEvents)
    {
        return saleEvents
            .Select(x => new SaleEventsDto
            {
                Id = x.Id,
                TicketDestination = x.TicketDestination,
                StartUtc = x.StartUtc,
                EndUtc = x.EndUtc,
            });
    }
}
