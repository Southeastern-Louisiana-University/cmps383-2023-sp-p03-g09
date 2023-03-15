using Microsoft.AspNetCore.Identity;
using SP23.P03.Web.Features.TrainStations;
using SP23.P03.Web.Features.Transactions;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.Rewards;
namespace SP23.P03.Web.Features.Authorization;

public class User : IdentityUser<int>
{
    public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();

    public virtual ICollection<TrainStation> ManageStations { get; set; } = new List<TrainStation>();

    public virtual ICollection<ProductUser> Tickets { get; set; } = new List<ProductUser>();

    //public virtual ICollection<RewardPoints> UserId { get; set; } = new List<RewardPoints>();

}