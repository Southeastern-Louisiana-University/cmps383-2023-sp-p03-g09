using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SP23.P03.Web.Features.Products;
using SP23.P03.Web.Features.Tickets;
using SP23.P03.Web.Features.Sales;

namespace SP23.P03.Web.Features.Sales;

public class SaleEventsProduct
{
    public int Id { get; set; }
    public decimal SaleEventPrice { get; set; }

    public int TicketId { get; set; }
    public virtual Ticket? Ticket { get; set; }

    public int SaleEventId { get; set; }
    public virtual SaleEvents? SaleEvents { get; set; }
}

public class SaleEventsProductConfiguration : IEntityTypeConfiguration<SaleEventsProduct>
{
    public void Configure(EntityTypeBuilder<SaleEventsProduct> builder)
    {
    }
}