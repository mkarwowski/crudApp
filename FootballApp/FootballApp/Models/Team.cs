using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FootballApp.Models
{
    public class Team
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9'\s]*$")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Team name")]
        public string Name { get; set; }
        public ICollection<Footballer> Footballers { get; set; }
        public ICollection<PlayedMatch> PlayedMatches { get; set; }
        public class TeamDBContext : DbContext
        {
            public DbSet<Team> Teams { get; set; }
        }
    }
}