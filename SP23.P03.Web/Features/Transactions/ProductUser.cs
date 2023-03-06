using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.Tickets;
using SP23.P03.Web.Features.Products;
using SP23.P03.Web.Features.Sales;

namespace SP23.P03.Web.Features.Transactions
{
    public class ProductUser
    {
        public virtual User User { get; set; } = null!;
        public int UserId { get; set; }
        public virtual Ticket Ticket { get; set; } = null!;
        public int TicketId { get; set; }
        public virtual Orders? Orders { get; set; }
        public decimal Price { get; set; }

        public string Tickets { get; set; }

    }

    public class ProductUserConfiguration : IEntityTypeConfiguration<ProductUser>
    {
        public void Configure(EntityTypeBuilder<ProductUser> builder)
        {
            builder.HasKey(x => new { x.UserId, x.TicketId });

            builder
                .HasOne(x => x.Ticket)
                .WithMany(x => x.UserInfos)
                .HasForeignKey(x => x.TicketId);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserId);
        }
    }
}
