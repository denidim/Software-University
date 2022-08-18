using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportJsonTheatreDto
    {
        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(1,10)]
        [Required]
        public sbyte NumberOfHalls { get; set; }

        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string Director { get; set; }

        public ImportJsonTicketDto[] Tickets { get; set; }
    }
}
/*Id – integer, Primary Key 

Name – text with length [4, 30] (required) 

NumberOfHalls – sbyte between [1…10] (required) 

Director – text with length [4, 30] (required) 

Tickets - a collection of type Ticket */
/*  "Name": "", 

    "NumberOfHalls": 7, 

    "Director": "Ulwin Mabosty", 

    "Tickets": [ */