using System;
using Microsoft.EntityFrameworkCore;

namespace C__Lab_6_2nd
{
  public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        public DbSet<Movie> Movies {get; set;}

        public DbSet<Studio> Studios {get; set;}
    }

    public class Movie
    {
         public override string ToString()
        {
            return $"{MovieId} {Title} {Genre} {StudioId}";
        } 
        public int MovieId {get; set;}

        public string Title {get; set;}

        public string Genre {get;set;}

        public int StudioId {get; set;}

        public Studio Studio {get; set;}


    }
    public class Studio
    { public override string ToString()
        {
            return $" {StudioId} {StudioName}";
        } 

        public int StudioId {get; set;}

        public string StudioName {get; set;}
    }
}
