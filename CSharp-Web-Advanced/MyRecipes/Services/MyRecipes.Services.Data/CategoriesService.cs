namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepo;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepo)
        {
            this.categoriesRepo = categoriesRepo;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllKeyValuePairs()
        {

            return this.categoriesRepo.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList()
            .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
