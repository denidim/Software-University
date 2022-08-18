using RealEstates.Data;
using RealEstates.Models;
using System;
using System.Linq;

namespace RealEstates.Services
{
    public class TagService : BaseService, ITagService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPropertiesService propertiesService;
        public TagService(ApplicationDbContext dbContext, IPropertiesService propertiesService)
        {
            this.dbContext = dbContext;
            this.propertiesService = propertiesService;
        }

        public void Add(string name, int? importance = null)
        {
            var tag = new Tag
            {
                Name = name,
                Importance = importance
            };

            this.dbContext.Tags.Add(tag);
            this.dbContext.SaveChanges();
        }

        // TODO: set better name
        public void BulkTagToPropertiesRelation()
        {
            var allProperties = dbContext.Properties.ToList();

            foreach (var property in allProperties)
            {
                var averagePriceForDistrict = this.propertiesService
                    .AveragePricePerSquareMeter(property.DistrictId);

                if (property.Price >= averagePriceForDistrict)
                {
                    var tag = GetTag("скъп-имот");
                    property.Tags.Add(tag);
                }
                else if (property.Price < averagePriceForDistrict)
                {
                    var tag = GetTag("евтин-имот");
                    property.Tags.Add(tag);
                }

                var currentDate = DateTime.Now.AddYears(-15);

                if (property.Year.HasValue && property.Year <= currentDate.Year)
                {
                    var tag = GetTag("старо-строителство");
                    property.Tags.Add(tag);
                }
                else if (property.Year.HasValue && property.Year > currentDate.Year)
                {
                    var tag = GetTag("ново-строителство");
                    property.Tags.Add(tag);
                }

                var averagePropertySize = this.propertiesService
                    .AverageSize(property.DistrictId);

                if (property.Size >= averagePropertySize)
                {
                    var tag = GetTag("голям-имот");
                    property.Tags.Add(tag);
                } 
                else if (property.Size < averagePropertySize)
                {
                    var tag = GetTag("малък-имот");
                    property.Tags.Add(tag);
                }

                if (property.Floor.HasValue && property.Floor.Value == 1)
                {
                    var tag = GetTag("първи-етаж");
                    property.Tags.Add(tag);
                } 
                else if (property.Floor.HasValue && property.Floor.Value > 6)
                {
                    var tag = GetTag("хубава-гледка");
                    property.Tags.Add(tag);
                }
            }

            dbContext.SaveChanges();
        }

        private Tag GetTag(string tagName)
            => dbContext.Tags.FirstOrDefault(x => x.Name == tagName);
    }
}
