using System.ComponentModel.DataAnnotations;
namespace SP23.P03.Web.Features.Sales
{
    public class SaleEventsProductsDto
    {

        [Range(0.00, double.MaxValue)]
        public decimal SaleEventsPrice { get; set; }
    }
}
