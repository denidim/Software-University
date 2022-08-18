namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(XmlImportBookDto[]),
                new XmlRootAttribute("Books"));

            StringReader reader;
            XmlImportBookDto[] bookDto;

            using (reader = new StringReader(xmlString))
            {
                bookDto = (XmlImportBookDto[])serializer.Deserialize(reader);

            }

            foreach (var book in bookDto)
            {

                if (!IsValid(book))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currBook = new Book
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = DateTime.ParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                };

                context.Books.Add(currBook);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedBook,book.Name,book.Price));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var dto = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            foreach (var item in dto)
            {
                if (!IsValid(item) || !item.Books.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (context.Authors.Any(x => x.Email == item.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var couner = 0;
                foreach (var book in item.Books)
                {
                    if (context.Books.Find(book.Id) == null)
                    {
                        continue;
                    }
                    else
                    {
                        couner++;
                    }

                }
                if(couner == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var author = new Author
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone = item.Phone,
                    Email = item.Email,
                };
                context.Authors.Add(author);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedAuthor,string.Join("," , item.FirstName,item.LastName), couner));
            }
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}