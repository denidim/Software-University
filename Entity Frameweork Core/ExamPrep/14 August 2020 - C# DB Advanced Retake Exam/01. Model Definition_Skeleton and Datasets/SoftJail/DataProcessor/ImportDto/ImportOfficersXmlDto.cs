using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersXmlDto
    {
        [XmlElement("Name")]
        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        [XmlElement("Money")]
        public decimal Salary{ get; set; }

        [Required]
        [EnumDataType(typeof(Position))]
        public string Position{ get; set; }

        [Required]
        [EnumDataType(typeof(Weapon))]
        public string Weapon { get; set; }

        [Required]
        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }


        [XmlArray("Prisoners")]
        public ImportPrisonersXmlDto[] Prisoners { get; set; }
    }
}
