using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.Transactions;
using System.ComponentModel.DataAnnotations;

namespace SP23.P03.Web.Features.Tickets;

public class Ticket
{
    public int Id { get; set; }
    [Required, MaxLength(120)]
    public string TicketDeparture { get; set; } = string.Empty;
    [Required, MaxLength(120)]
    public string TicketDestination { get; set; } = string.Empty;
    [Required, MaxLength(120)]
    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public enum StatusType
    {
        Active,
        Hidden,
        Inactive
    }
    public StatusType Status { get; set; }
    public virtual ICollection<ProductUser> UserInfos { get; set; } = new List<ProductUser>();



    public class ProductConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(x => x.TicketDeparture)
                .IsRequired()
                .HasMaxLength(120);
            builder.Property(x => x.TicketDestination)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(x => x.Description)
                .IsRequired();


        }
    }
}