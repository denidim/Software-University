namespace MyRecipes.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task WhenUserVote2TimesOnly1VoteShouldBeCounted()
        {
            var list = new List<Vote>();

            var mockRepo = new Mock<IRepository<Vote>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());

            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>()))
                .Callback((Vote vote) => list.Add(vote));

            var service = new VoteService(mockRepo.Object);

            await service.SetVoteAsync(1, "1", 1);
            await service.SetVoteAsync(1, "1", 5);

            Assert.Single(list);
            Assert.Equal(5, list.First().Value);
        }

        [Fact]
        public async Task When2UserVoteForTheSameRecipeTheAverageVoteShouldBeCorect()
        {
            var list = new List<Vote>();

            var mockRepo = new Mock<IRepository<Vote>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());

            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>()))
                .Callback((Vote vote) => list.Add(vote));

            var service = new VoteService(mockRepo.Object);

            await service.SetVoteAsync(1, "Pesho", 5);
            await service.SetVoteAsync(1, "Niki", 1);
            await service.SetVoteAsync(1, "Pesho", 2);

            mockRepo.Verify(x => x.AddAsync(It.IsAny<Vote>()), Times.Exactly(2));

            Assert.Equal(2, list.Count);
            Assert.Equal(1.5, service.GetAverageGrade(1));
        }
    }
}
