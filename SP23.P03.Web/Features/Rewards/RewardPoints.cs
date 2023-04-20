using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SP23.P03.Web.Features.Authorization;


namespace SP23.P03.Web.Features.Rewards
{
    public class RewardPoints
    {
        public int Id { get; set; }
        //public int Id { get; set; }
        public DateTime DateEarned { get; set; }
        public int UserId { get; set; }
        public int Points { get; set; }

        public string Type { get; set; } = string.Empty;

        public int milesTraveled { get; set; }

    }

    
    public class RewardPointsConfiguration : IEntityTypeConfiguration<RewardPoints>
    {
        public void Configure(EntityTypeBuilder<RewardPoints> builder)
        {
               

        }
    }
}
