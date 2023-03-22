using System.ComponentModel.DataAnnotations;

namespace SP23.P03.Web.Features.Sales
{
    public class SaleEventsDto
    {

        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string TicketDestination { get; set; } = string.Empty;

        public DateTimeOffset StartUtc { get; set; }
        public DateTimeOffset EndUtc { get; set; }
    }
}
