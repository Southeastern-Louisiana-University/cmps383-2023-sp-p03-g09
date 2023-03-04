using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SP23.P03.Web.Features.Sales;
using SP23.P03.Web.Features.Products;
using SP23.P03.Web.Features.Tickets;

namespace SP23.P03.Web.Features.Sales;

public class SaleEvents
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset StartUtc { get; set; }
    public DateTimeOffset EndUtc { get; set; }

    public virtual ICollection<SaleEventsProduct> Products { get; set; } = new List<SaleEventsProduct>();
}

public class SaleEventConfiguration : IEntityTypeConfiguration<SaleEvents>
{
    public void Configure(EntityTypeBuilder<SaleEvents> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(120);
    }
}