using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class XmlImportShellsDto
    {
        [Required]
        [XmlElement("ShellWeight")]
        [Range(2,1680)]
        public double ShellWeight { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        [XmlElement("Caliber")]
        public string Caliber { get; set; }
    }
}
/*
 Id – integer, Primary Key 

ShellWeight – double in range  [2…1_680] (required) 

Caliber – text with length [4…30] (required) 

Guns – a collection of Gun */
/*
  <Shell> 

    <ShellWeight>50</ShellWeight> 

    <Caliber>155 mm (6.1 in)</Caliber> 

  </Shell> 

  <Shell> 

    <ShellWeight>100</ShellWeight> 

    <Caliber>103 mm (8 in)</Caliber> 

  </Shell> 

  <Shell> */