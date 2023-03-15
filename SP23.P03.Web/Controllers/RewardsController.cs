using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP23.P03.Web.Data;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.Rewards;
using SP23.P03.Web.Features.TrainStations;
using System.Reflection.Metadata.Ecma335;

namespace SP23.P03.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {   

        //takes dataContext of the entire database.
        private readonly DataContext dataContext;
        private readonly DbSet<RewardPoints> rewards;
        private readonly DbSet<User> users;


        public RewardsController(DataContext dataContext) {

            // takes original dataContext and names it into rewards
            this.dataContext = dataContext;
            rewards = dataContext.Set<RewardPoints>();

        }


        //Get All Reward Points for a user
        [HttpGet]
        public IQueryable<RewardPointsDto> GetAllRewards()
        {
            return GetRewardPointsDtos(rewards);
        }

        [HttpPost]
        public ActionResult<RewardPointsDto> AddPoints(RewardPointsDto dto)
        {

            var totalPoints = rewards.Where(x => x.UserId == dto.userId).Sum(y => y.Points);


            return null;


        }

       


















        private static IQueryable<RewardPointsDto> GetRewardPointsDtos(IQueryable<RewardPoints> rewards)
        {
            return rewards
                .Select(x => new RewardPointsDto
                {
                    PointsId = x.PointsId,
                    userId = x.UserId,
                    Points = x.Points,
                });
        }


    }
}
