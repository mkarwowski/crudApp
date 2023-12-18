using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FootballApp.Models;

namespace FootballApp.Data
{
    public class FootballAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FootballAppContext() : base("name=FootballAppContext")
        {
        }

        public System.Data.Entity.DbSet<FootballApp.Models.Footballer> Footballers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Footballer>()
                .HasRequired<Team>(f => f._team)
                .WithMany(g => g.Footballers)
                .HasForeignKey<int>(s => s.TeamID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PlayedMatch>()
                .HasRequired<Team>(f => f._team)
                .WithMany(g => g.PlayedMatches)
                .HasForeignKey<int>(s => s.TeamID)
                .WillCascadeOnDelete();
        }

        public System.Data.Entity.DbSet<FootballApp.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<FootballApp.Models.PlayedMatch> PlayedMatches { get; set; }
    }
}
