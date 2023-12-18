using FootballApp.Validatiors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FootballApp.Models
{
    public class PlayedMatch
    {
        public enum Result { 
            win,
            lose,
            draw
        }

        public int ID { get; set; }
        public int TeamID { get; set; }
        public Team _team { get; set; }
        [ResultValidator("GoalsScored", "GoalsConceded")]
        [Display(Name = "Result")]
        public Result _result { get; set; }
        [Display(Name = "Goals scored")]
        public int GoalsScored { get; set; }
        [Display(Name = "Goals conceded")]
        public int GoalsConceded { get; set; }
    }

    public class PlayedMatchDBContext : DbContext
    {
        public DbSet<PlayedMatch> PlayedMatches { get; set; }
    }
}