using System;
using System.Collections.Generic;
using System.Text;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int FootballerId { get; set; }

        public Footballer Footballer { get; set; }
    }
}
/*
 TeamId – integer, Primary Key, foreign key (required) 

Team – Team 

FootballerId – integer, Primary Key, foreign key (required) 

Footballer – Footballer */