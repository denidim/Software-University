using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.Data.Models
{
    public class CountryGun
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int GunId { get; set; }
        public virtual Gun Gun{ get; set; }

    }
}
