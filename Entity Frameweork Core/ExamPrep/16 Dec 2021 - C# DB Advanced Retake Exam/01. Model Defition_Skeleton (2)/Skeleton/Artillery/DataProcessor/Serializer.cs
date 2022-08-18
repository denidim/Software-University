
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shels = context.Shells.ToArray().Where(x => x.ShellWeight > shellWeight)
                .Select(x => new
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns.Where(x => x.GunType == Data.Models.Enums.GunType.AntiAircraftGun).Select(x => new
                    {
                        GunType = x.GunType.ToString(),
                        GunWeight = x.GunWeight,
                        BarrelLength = x.BarrelLength,
                        Range = x.Range > 3000 ? "Long-range" : "Regular range"
                    })
                    .OrderByDescending(x => x.GunWeight)
                    .ToArray()
                })
                .OrderBy(x => x.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shels, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns.ToArray()
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .Select(x => new XmlExportDto
                {
                    Manufacturer = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    BarrelLength = x.BarrelLength,
                    Range = x.Range,
                    Countries = x.CountriesGuns
                    .Where(x=>x.Country.ArmySize > 4500000)
                    .Select(x=>new EportXmlCoutriesDto
                    {
                        Country = x.Country.CountryName,
                        ArmySize = x.Country.ArmySize
                    })
                    .OrderBy(x=>x.ArmySize)
                    .ToArray()
                })
                .OrderBy(x=>x.BarrelLength)
                .ToArray();

            var xmlSer = new XmlSerializer(typeof(XmlExportDto[]), new XmlRootAttribute("Guns"));

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            ns.Add(string.Empty, string.Empty);

            var writer = new StringWriter();

            using (writer)
            {
                xmlSer.Serialize(writer, guns, ns);
            };

            return writer.ToString();
        }
    }
}
