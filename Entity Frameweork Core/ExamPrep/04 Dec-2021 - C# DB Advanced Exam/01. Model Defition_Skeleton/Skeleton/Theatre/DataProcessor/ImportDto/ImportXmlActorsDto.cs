using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportXmlActorsDto
    {
        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        [XmlElement("FullName")]
        public string FullName { get; set; }

        [Required]
        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }

        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(@"[+]44-\d{2}-\d{3}-\d{4}")]
        public string PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        [Required]
        public int PlayId { get; set; }
    }
}
/*Id – integer, Primary Key 

FullName – text with length [4, 30] (required)

IsMainCharacter – Boolean represents if the actor plays the main character in a play (required) 

PhoneNumber - text in the following format: "+44-{2 numbers}-{3 numbers}-{4 numbers}".Valid phone numbers are: +44 - 53 - 468 - 3479, +44 - 91 - 842 - 6054, +44 - 59 - 742 - 3119(required)

PlayId - integer, foreign key(required) 

***********JSON********
<Cast> 

    <FullName>Van Tyson</FullName> 

    <IsMainCharacter>false</IsMainCharacter> 

    <PhoneNumber>+44-35-745-2774</PhoneNumber> 

    <PlayId>26</PlayId> 

  </Cast> 
 */