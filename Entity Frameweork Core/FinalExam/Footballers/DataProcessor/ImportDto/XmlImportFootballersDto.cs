using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class XmlImportFootballersDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        [EnumDataType(typeof(BestSkillType))]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Required]
        [EnumDataType(typeof(PositionType))]
        public int PositionType { get; set; }
    }
}
/*Id – integer, Primary Key 

Name – text with length [2, 40] (required) 

ContractStartDate – date and time (required) 

ContractEndDate – date and time (required) 

PositionType – enumeration of type PositionType, with possible values (Goalkeeper, Defender, Midfielder, Forward) (required)  

BestSkillType – enumeration of type BestSkillType, with possible values (Defence, Dribble, Pass, Shoot, Speed) (required) 

CoachId – integer, foreign key (required) 

Coach – Coach  

TeamsFootballers – collection of type TeamFootballer */
/* <Footballer> 

        <Name>Benjamin Bourigeaud</Name> 

        <ContractStartDate>22/03/2020</ContractStartDate> 

        <ContractEndDate>24/02/2026</ContractEndDate> 

        <BestSkillType>2</BestSkillType> 

        <PositionType>2</PositionType> 

      </Footballer > */