using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class JsonImportEmployeesDto
    {

        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        [RegularExpression(@"[\w]*[\d]*")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}")]
        public string Phone { get; set; }

        public HashSet<int> Tasks { get; set; }

    }
}
/*Id - integer, Primary Key 

Username - text with length [3, 40]. Should contain only lower or upper case letters and/or digits. (required) 

Email – text (required). Validate it! There is attribute for this job. 

Phone - text. Consists only of three groups (separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required) 

EmployeesTasks - collection of type EmployeeTask */
/*{ 

    "Username": "jstanett0", 

    "Email": "kknapper0@opera.com", 

    "Phone": "819-699-1096", 

    "Tasks": [ 

      34, 

      32, 

      65, 

      30, 

      30, 

      45, 

      36, 

      67 

    ] 

  }, */