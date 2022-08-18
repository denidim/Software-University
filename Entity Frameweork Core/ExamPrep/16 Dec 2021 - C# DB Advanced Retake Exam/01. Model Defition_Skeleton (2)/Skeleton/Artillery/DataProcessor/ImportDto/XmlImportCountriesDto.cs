using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class XmlImportCountriesDto
    {
        [XmlElement("CountryName")]
        [Required]
        [MaxLength(68)]
        [MinLength(4)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Required]
        [Range(50000,10000000)]
        public int ArmySize { get; set; }

    }
}
/*Id – integer, Primary Key 

CountryName – text with length [4, 60] (required) 

ArmySize – integer in the range [50_000….10_000_000] (required) 

CountriesGuns – a collection of CountryGun */
/* <Country>
    <CountryName>Afghanistan</CountryName>
    <ArmySize>1697064</ArmySize>
  </Country>
  <Country>
    <CountryName>Afghan</CountryName>
    <ArmySize>16</ArmySize>
  </Country>*/