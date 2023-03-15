using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SP23.P03.Web.Features.Authorization;


namespace SP23.P03.Web.Features.Rewards
{
    public class RewardPoints
    {
        public int PointsId { get; set; }
        public DateTime DateEarned { get; set; }
        public int UserId { get; set; }
        public int PointsTotal { get; set; }

        public string Type { get; set; } = string.Empty;    

    }

    public virtual ICollection<User> PointsTotal { get; set; } = new List<User>();
    public class RewardPointsConfiguration : IEntityTypeConfiguration<RewardPoints>
    {
        public void Configure(EntityTypeBuilder<RewardPoints> builder)
        {
           builder
         .HasKey(x => x.UserId);
                

        }
    }
}
