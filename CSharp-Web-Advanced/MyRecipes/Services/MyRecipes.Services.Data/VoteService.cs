namespace MyRecipes.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;

    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> votesRepo;

        public VoteService(IRepository<Vote> votesRepo)
        {
            this.votesRepo = votesRepo;
        }

        public double GetAverageGrade(int recipeId)
        {
            return this.votesRepo.All().Where(x => x.RecipeId == recipeId)
                .Average(x => x.Value);
        }

        public async Task SetVoteAsync(int recipeId, string userId, byte value)
        {
            var vote = await this.votesRepo
                .All()
                .FirstOrDefaultAsync(x => x.RecipeId == recipeId && x.UserId == userId);

            if (vote == null)
            {
                vote = new Vote
                {
                    RecipeId = recipeId,
                    UserId = userId,
                };

                await this.votesRepo.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepo.SaveChangesAsync();
        }
    }
}
