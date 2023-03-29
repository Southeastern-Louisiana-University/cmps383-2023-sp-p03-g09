using System.ComponentModel.DataAnnotations;

namespace SP23.P03.Web.Features.Tickets
{
    public class TicketDto
    {

        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string TicketDeparture { get; set; } = string.Empty;

        [Required, MaxLength(120)]
        public string TicketDestination { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;

       

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public decimal? SalePrice { get; set; }

        public DateTimeOffset? SaleEndsUtc { get; set; }
        
        public int? Status { get; set; }
  
      
    }
}
