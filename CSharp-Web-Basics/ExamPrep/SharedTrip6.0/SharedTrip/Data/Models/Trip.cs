using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class Trip
    {
        public Trip()
        {
            this.UserTrips = new HashSet<UserTrip>();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string StartPoint { get; set; }

        [Required]
        [StringLength(100)]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [Range(2,6)]
        public int Seats { get; set; }

        [Required]
        [StringLength(80)]
        public string Description { get; set; }

        [StringLength(200)]
        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips{ get; set; }
    }
}
/*
 * Has an Id – a string, Primary Key 

Has a StartPoint – a string (required) 

Has a EndPoint – a string (required) 

Has a DepartureTime – a datetime (required)  

Has a Seats – an integer with min value 2 and max value 6 (required) 

Has a Description – a string with max length 80 (required) 

Has a ImagePath – a string 

Has UserTrips collection – a UserTrip type 
 */