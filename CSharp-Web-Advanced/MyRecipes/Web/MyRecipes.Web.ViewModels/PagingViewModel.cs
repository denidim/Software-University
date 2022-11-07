namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public int RecipesCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.RecipesCount / this.ItemsPerPage);

        public bool HasPrevious => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int NextPageNumber => this.PageNumber + 1;
    }
}
