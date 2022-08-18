using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportJsonTicketDto
    {
        [Range(1.00 ,100.00)]
        [Required]
        public decimal Price { get; set; }

        [Range(1,10)]
        [Required]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
/*Id – integer, Primary Key 

Price – decimal in the range [1.00….100.00] (required) 

RowNumber – sbyte in range [1….10] (required) 

PlayId – integer, foreign key (required) 

TheatreId – integer, foreign key (required) */
/*"Tickets": [ 

      { 

        "Price": 7.63, 

        "RowNumber": -5, 

        "PlayId": 4 

      }, 

      { 

        "Price": 47.96, 

        "RowNumber": 9, 

        "PlayId": 3 

      }, 

      …. 

    ] */