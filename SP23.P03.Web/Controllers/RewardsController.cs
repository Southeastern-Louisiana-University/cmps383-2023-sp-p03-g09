using Microsoft.AspNetCore.Http;
// ---- allows you to use authentication/authorization
using Microsoft.AspNetCore.Authorization;
//------
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP23.P03.Web.Data;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.Rewards;
using SP23.P03.Web.Features.TrainStations;
using System.Reflection.Metadata.Ecma335;
using static System.Collections.Specialized.BitVector32;
using SP23.P03.Web.Extensions;

namespace SP23.P03.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {

        //takes dataContext of the entire database.
        private readonly DataContext dataContext;
        private readonly DbSet<RewardPoints> Rewards;
        private readonly DbSet<User> users;


        public RewardsController(DataContext dataContext)
        {

            // takes original dataContext and names it into rewards
            this.dataContext = dataContext;
            Rewards = dataContext.Set<RewardPoints>();

        }


        //Gets a log history of all transaction points users have acquired.
        [HttpGet]
        [Route("Points-Log-History")]
        [Authorize(Roles = RoleNames.Admin)]
        public IQueryable<RewardPointsDto> GetAllRewards()
        {
            return GetRewardPointsDtos(Rewards);
        }

        // 
        [HttpGet]
        [Route("Each-Individual-Point")]
        public ActionResult<RewardPointsDto> GetPointsId(int id)
        {
            var result = GetRewardPointsDtos(Rewards.Where(x => x.Id == id)).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }





        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public ActionResult GetPointsSingleUser()
        {
            var totalPoints = Rewards.Where(x => x.UserId == User.GetCurrentUserId()).Sum(y => y.Points);

            return Ok(totalPoints);
        }


        [HttpPost]
        [Authorize]
        public ActionResult<RewardPointsDto> ModifyPoints(RewardPointsDto dto)
        {
            if (!IsValid(dto))
            {
                return BadRequest("Points must be 25 or -75.");
            }

            // Get points of the current user
            var rewardPoints = dataContext.Set<RewardPoints>().Where(x => x.UserId == dto.userId).Sum(y => y.Points);
            // If points subtracted equals > 0 (negative), return bad request
            if (rewardPoints + dto.Points < 0)
            {
                return BadRequest("User does not have sufficient points.");
            }

            var reward = new RewardPoints
            {
                DateEarned = DateTime.Now,
                UserId = dto.userId,
                Points = dto.Points,
            };
            Rewards.Add(reward);
            dataContext.SaveChanges();

            dto.PointsId = reward.Id;
            dto.DateEarned = reward.DateEarned;

            return CreatedAtAction(nameof(GetPointsId), new { id = dto.PointsId }, dto);
            //return Ok(dto);
        }

        private bool IsValid(RewardPointsDto dto)
        {
            //points awarded must be 25 at a time, points redeemed must be -75 at a time
            return dto.Points == 25 || dto.Points == -75;
        }





        private static IQueryable<RewardPointsDto> GetRewardPointsDtos(IQueryable<RewardPoints> rewards)
        {
            return rewards
                .Select(x => new RewardPointsDto
                {
                    PointsId = x.Id,
                    userId = x.UserId,
                    Points = x.Points,
                });
        }


    }
}
