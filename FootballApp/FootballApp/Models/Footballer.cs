using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using FootballApp.Validatiors;

namespace FootballApp.Models
{
    public class Footballer
    {
        public enum RoleOnPitch
        {
            Goalkeeper,
            Defender,
            Midfielder,
            Attacker
        }

        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Display(Name = "First name")]
        [Required]
        [StringLength(45, MinimumLength = 1)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(78, MinimumLength = 1)]
        public string Surname { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateCompareAttribute]
        public DateTime DateOfBirth { get; set; }

        public RoleOnPitch Role { get; set; }

        public Team _team { get; set; }
        public int TeamID { get; set; }

        public class FootballerDBContext : DbContext
        {
            public DbSet<Footballer> Footballers { get; set; }
        }
    }

}