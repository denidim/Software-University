namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var XmlSerialize = new XmlSerializer(typeof(XmlImportCountriesDto[]), new XmlRootAttribute("Countries"));

            XmlImportCountriesDto[] countriesDto = null;

            using (var reader = new StringReader(xmlString))
            {
                countriesDto = (XmlImportCountriesDto[])XmlSerialize.Deserialize(reader);
            };

            foreach (var country in countriesDto)
            {
                if (!IsValid(country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;  
                }

                var countries = new Country
                {
                    CountryName = country.CountryName,
                    ArmySize = country.ArmySize,
                };

                context.Countries.Add(countries);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportCountry,countries.CountryName,countries.ArmySize));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var XmlSerialize = new XmlSerializer(typeof(List<XmlImportManufacturerDto>), new XmlRootAttribute("Manufacturers"));
            List<XmlImportManufacturerDto> manufacturerDto = null;
            using (var reader = new StringReader(xmlString))
            {
                manufacturerDto = (List<XmlImportManufacturerDto>)XmlSerialize.Deserialize(reader);
            };
            foreach (var manif in manufacturerDto)
            {
                if (!IsValid(manif) || context.Manufacturers.Any(x => x.ManufacturerName == manif.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var manufacturer = new Manufacturer()
                {
                    ManufacturerName = manif.ManufacturerName,
                    Founded = manif.Founded,
                };
                var founded = manif.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var country = founded[founded.Length - 1];
                var district = founded[founded.Length - 2];
                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manif.ManufacturerName, string.Join(", ", district, country)));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var XmlSerialize = new XmlSerializer(typeof(List<XmlImportShellsDto>), new XmlRootAttribute("Shells"));
            List<XmlImportShellsDto> shellDto = null;
            using (var reader = new StringReader(xmlString))
            {
                shellDto = (List<XmlImportShellsDto>)XmlSerialize.Deserialize(reader);
            };

            foreach (var shell in shellDto)
            {
                if (!IsValid(shell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var currShell = new Shell()
                {
                   ShellWeight = shell.ShellWeight,
                   Caliber = shell.Caliber,
                };
                context.Shells.Add(currShell);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportShell,shell.Caliber,shell.ShellWeight));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gunDto = JsonConvert.DeserializeObject<JsonImportGunsDto[]>(jsonString);

            foreach (var gun in gunDto)
            {

                var gunType = Enum.TryParse<GunType>(gun.GunType, out var validGunType);

                if (!IsValid(gun) || !gunType )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currGun = new Gun()
                {
                    ManufacturerId = gun.ManufacturerId,
                    GunWeight = gun.GunWeight,
                    BarrelLength = gun.BarrelLength,
                    NumberBuild = gun.NumberBuild,
                    Range = gun.Range,
                    GunType = validGunType,
                    ShellId = gun.ShellId,
                    CountriesGuns = gun.Countries.Select(x => new CountryGun
                    {
                        CountryId = x.Id
                    }).ToArray()
                };

                context.Guns.Add(currGun);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportGun,gun.GunType,gun.GunWeight,gun.BarrelLength));
            }
            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
