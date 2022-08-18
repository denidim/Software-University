using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class XmlImportManufacturerDto
    {
        [XmlElement("ManufacturerName")]
        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string ManufacturerName { get; set; }

        [XmlElement("Founded")]
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Founded { get; set; }
    }
}
/*
 Id – integer, Primary Key 

ManufacturerName – unique text with length [4…40] (required) 

Founded – text with length [10…100] (required) 

Guns – a collection of Gun */
/*<Manufacturer> 

    <ManufacturerName>BAE Systems</ManufacturerName> 

    <Founded>30 November 1999, London, England</Founded> 

  </Manufacturer> 

  <Manufacturer> 

    <ManufacturerName>BAE</ManufacturerName> 

    <Founded>30 November 1999, London, England</Founded> 

  </Manufacturer> 

  <Manufacturer> 

    <ManufacturerName>Aviation Industry Corporation of China</ManufacturerName> 

    <Founded>April 1, 1951, Chaoyang District, Beijing, China</Founded> 

  </Manufacturer> */