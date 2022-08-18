
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services;
using RealEstates.Services.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("3. Average price per square meter");
                Console.WriteLine("4. Add tag");
                Console.WriteLine("5. Bulk tag to poperties");
                Console.WriteLine("6. Property Full Info");
                Console.WriteLine("0. EXIT");
                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option == 0)
                {
                    break;
                }
                
                if (parsed && option >= 1 && option <= 6)
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                        case 3:
                            AveragePricePerSquareMeter(db);
                            break;
                        case 4:
                            AddTag(db);
                            break;
                        case 5:
                            BulkTagToProperties(db);
                            break;
                        case 6:
                            PropertyFullInfo(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void PropertyFullInfo(ApplicationDbContext db)
        {
            Console.WriteLine("Count of properties:");
            int count = int.Parse(Console.ReadLine());
            IPropertiesService propertiesService = new PropertiesService(db);
            var result = propertiesService.GetFullData(count).ToArray();
            var xmlSerializer = new XmlSerializer(typeof(PropertyInfoFullData[]));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, result);
            Console.WriteLine(stringWriter.ToString().TrimEnd());
        }

        private static void BulkTagToProperties(ApplicationDbContext db)
        {
            Console.WriteLine("Bulk operation started!");
            IPropertiesService propertiesService = new PropertiesService(db);
            ITagService tagService = new TagService(db, propertiesService);
            tagService.BulkTagToPropertiesRelation();
            Console.WriteLine("Bulk operation finished!");
        }

        private static void AddTag(ApplicationDbContext db)
        {
            Console.WriteLine("Tag name:");
            string tagName = Console.ReadLine();
            Console.WriteLine("Importance (optional):");
            bool isParsed = int.TryParse(Console.ReadLine(), out int tagImportance);
            int? importance = isParsed ? tagImportance : null;

            IPropertiesService propertiesService = new PropertiesService(db);
            ITagService tagService = new TagService(db, propertiesService);
            tagService.Add(tagName, importance);
        }

        private static void AveragePricePerSquareMeter(ApplicationDbContext dbContext)
        {
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            Console.WriteLine($"Average price per square meter: {propertiesService.AveragePricePerSquareMeter():0.00}€/m²");
        }

        private static void MostExpensiveDistricts(ApplicationDbContext db)
        {
            Console.Write("Districts count:");
            int count = int.Parse(Console.ReadLine());
            IDistrictsService districtsService = new DistrictsService(db);
            var districts = districtsService.GetMostExpensiveDistricts(count);
            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePricePerSquareMeter:0.00}€/m² ({district.PropertiesCount})");
            }
        }

        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.Write("Min price:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price:");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.Write("Min size:");
            int minSize = int.Parse(Console.ReadLine());
            Console.Write("Max size:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(db);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType} => {property.Price}€ => {property.Size}m²");
            }
        }
    }
}
