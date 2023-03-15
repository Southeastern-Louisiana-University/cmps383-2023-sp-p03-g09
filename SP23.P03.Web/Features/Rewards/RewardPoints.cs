using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SP23.P03.Web.Features.Rewards
{
    public class RewardPoints
    {
        public int PointsId { get; set; }
        public DateTime DateEarned { get; set; }
        public int UserId { get; set; }
        public int AmountOfPoints { get; set; }

        public string Type { get; set; } = string.Empty;    

    }



    public class RewardPointsConfiguration : IEntityTypeConfiguration<RewardPoints>
    {
        public void Configure(EntityTypeBuilder<RewardPoints> builder)
        {
            builder.Property(x => x.AmountOfPoints)
                 .HasColumnType("(1,Receive, 25)");

            builder.Property(x => x.AmountOfPoints)
                 .HasColumnType("(1,Redeem, 50)");
        }
    }
}
