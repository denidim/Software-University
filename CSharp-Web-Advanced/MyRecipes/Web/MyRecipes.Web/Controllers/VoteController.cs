namespace MyRecipes.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Votes;

    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService voteService;

        public VoteController(IVoteService voteService)
        {
            this.voteService = voteService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PostVoteUpdatedGradeViewModel>> Post(PostVotesInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.voteService.SetVoteAsync(model.RecipeId, userId, model.Value);

            var averageGrades = this.voteService.GetAverageGrade(model.RecipeId);

            return new PostVoteUpdatedGradeViewModel { AverageVote = averageGrades };
        }
    }
}
