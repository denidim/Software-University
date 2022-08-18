using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBestPractices.Infrastructure.Data.Models
{
    [Keyless]
    public partial class VEmployeeSalary
    {
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "decimal(15, 4)")]
        public decimal Salary { get; set; }
    }
}
