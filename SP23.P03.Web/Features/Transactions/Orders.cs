using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.Transactions;

namespace SP23.P03.Web.Features.Transactions
{
    public class Orders
    {
        public int Id { get; set; }
        public virtual User? User { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}



public class OrderConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.Property(x => x.Amount)
             .HasColumnType("decimal(18, 2)");
    }
}
