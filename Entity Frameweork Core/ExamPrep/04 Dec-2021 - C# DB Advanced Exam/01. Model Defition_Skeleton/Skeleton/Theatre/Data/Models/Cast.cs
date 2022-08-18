using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int PlayId { get; set; }

        public Play Play { get; set; }

    }
}
/*Id – integer, Primary Key 

FullName – text with length [4, 30] (required) 

IsMainCharacter – Boolean represents if the actor plays the main character in a play (required) 

PhoneNumber  - text in the following format: "+44-{2 numbers}-{3 numbers}-{4 numbers}". Valid phone numbers are: +44-53-468-3479, +44-91-842-6054, +44-59-742-3119 (required) 

PlayId - integer, foreign key (required) 
****XML******
* <Play> 

    <Title>The Hsdfoming</Title> 

    <Duration>03:40:00</Duration> 

    <Rating>8.2</Rating> 

    <Genre>Action</Genre> 

    <Description>A guyat Pinter turns into a debatable conundrum as oth ordinary and menacing. Much of this has to do with the fabled "Pinter Pause," which simply mirrors the way we often respond to each other in conversation, tossing in remainders of thoughts on one subject well after having moved on to another.</Description> 

    <Screenwriter>Roger Nciotti</Screenwriter> 

  </Play> 
 */