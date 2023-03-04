using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.Transactions;
using SP23.P03.Web.Features.Sales;

namespace SP23.P03.Web.Features.Products;

public class Ticket
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public enum StatusType
    {
        Active,
        Hidden,
        Inactive
    }
    public StatusType Status { get; set; }
    public virtual ICollection<SaleEventsProduct> SaleEventProducts { get; set; } = new List<SaleEventsProduct>();
    public virtual ICollection<ProductUser> UserInfos { get; set; } = new List<ProductUser>();



    public class ProductConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(x => x.Description)
                .IsRequired();


        }
    }
}