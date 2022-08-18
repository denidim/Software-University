using Artillery.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.DataProcessor.ImportDto
{
    public class JsonImportGunsDto
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(100,1350000)]
        public int GunWeight { get; set; }

        [Required]
        [Range(2.00, 35.00)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [Range(1,100000)]
        public int Range { get; set; }

        [Required]
        public string GunType { get; set; }

        [Required]
        public int ShellId { get; set; }

        public JsonImportCountriesIdDto[] Countries { get; set; }

    }
}
/*
 Id – integer, Primary Key 

ManufacturerId – integer, foreign key (required) 

GunWeight– integer in range [100…1_350_000] (required) 

BarrelLength – double in range [2.00….35.00] (required) 

NumberBuild – integer 

Range – integer in range [1….100_000] (required) 

GunType – enumeration of GunType, with possible values (Howitzer, Mortar, FieldGun, AntiAircraftGun, MountainGun, AntiTankGun) (required) 

ShellId – integer, foreign key (required) 

CountriesGuns – a collection of CountryGun */
/* { 

    "ManufacturerId": 14, 

    "GunWeight": 531616, 

    "BarrelLength": 6.86, 

    "NumberBuild": 287, 

    "Range": 120000, 

    "GunType": "Howitzer", 

    "ShellId": 41, 

    "Countries": [ 

      { "Id": 86 }, 

      { "Id": 57 }, 

      { "Id": 64 }, 

      { "Id": 74 }, 

      { "Id": 58 } 

    ] 

  }, 

  { 

    "ManufacturerId": 8, 

    "GunWeight": 801684, 

    "BarrelLength": 31.18, 

    "NumberBuild": 620, 

    "Range": 19118, 

    "GunType": "AntiTankGun", 

    "ShellId": 38, 

    "Countries": [ 

      { "Id": 47 }, 

      { "Id": 3 }, 

      { "Id": 85 }, 

      { "Id": 35 }, 

      { "Id": 49 }, 

      { "Id": 53 }, 

      { "Id": 30 }, 

      { "Id": 39 }, 

      { "Id": 62 }, 

      { "Id": 6 }, 

      { "Id": 76 }, 

      { "Id": 78 }, 

      { "Id": 43 }, 

      { "Id": 72 }, 

      { "Id": 23 }, 

      { "Id": 9 }, 

      { "Id": 1 }, 

      { "Id": 21 }, 

      { "Id": 8 }, 

      { "Id": 67 }, 

      { "Id": 2 }, 

      { "Id": 33 }, 

      { "Id": 28 }, */