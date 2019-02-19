using System;
using System.Collections.Generic;
using System.Linq;

namespace C__Lab_6_2nd
{
    class Program
    {
        static void Main(string[] args)
        {
              List<Movie> Movies = new List<Movie> {
                  new Movie {Title = "Avatar", Genre = "Action", StudioId =1 },
                  new Movie {Title = "Deadpool", Genre = "Action", StudioId=1},
                  new Movie {Title = "Apollo 13", Genre = "Drama", StudioId=1},
                  new Movie {Title = "The Martian", Genre = "Sci-Fi", StudioId=1},
                  
                  
              };
               using (var db = new AppDbContext())//creat new database
                {
                    if (db.Database.EnsureCreated())
                    {
                        db.AddRange(Movies);
                        db.SaveChanges();
                    }
                }

            List<Studio> studios = new List<Studio>{
                new Studio {StudioId=1,StudioName= "20th Centery Fox"}
                
            };
             using (var db = new AppDbContext())//creat new database
                {
                    if (db.Database.EnsureCreated())
                    {
                        db.AddRange(studios);
                        db.SaveChanges();
                    }
                }
            new Studio {StudioId=2,StudioName= "Universal Pictures"};
            using (var db = new AppDbContext())
            {
                if (db.Database.EnsureCreated())
                {
                    db.Add(studios);
                    db.SaveChanges();
                }
            }

            new Movie {Title = "Jurassic Park", Genre = "Action", StudioId=2};
            using (var db = new AppDbContext())
            {
                if (db.Database.EnsureCreated())
                {
                    db.Add(Movies);
                    db.SaveChanges();
                }
            }
            using (var db = new AppDbContext())
            {
                Movie movies =db.Movies.Where(p => p.Title == "Apollo 13").First();
                movies.Studio = db.Studios.Where(m =>m.StudioName == "Universal Studios").First();

            }

            using (var db = new AppDbContext())
            {
                //deadpool
                Movie movies =db.Movies.Find("Deadpool");
                db.Remove(movies);
                db.SaveChanges();
            }

            var query1 = Movies.GroupBy(m => m.Studio);
            Console.WriteLine("Movies by studio");
            foreach (var studio in query1)
            {
                Console.WriteLine($"Studio {studio} ");
                Console.WriteLine(query1);
                foreach (var movies in studio)
                {
                    Console.WriteLine(movies);
                }
                Console.WriteLine();
            }



            
        }
    }
}
