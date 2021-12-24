using SimulasiRESTAPI.Models;
using System;
using System.Linq;

namespace SimulasiRESTAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Authors.Any())
            {
                return;
            }

            var authors = new Author[]
            {
                new Author{FirstName = "Erick",LastName = "Kurniawan", DateOfBirth=DateTime.Parse("1998-12-10"), MainCategory="Programmer"},
                new Author{FirstName = "Agus",LastName = "Kurniawan", DateOfBirth=DateTime.Parse("1998-11-10"), MainCategory="Programmer"},
                new Author{FirstName = "Peter",LastName = "Parker", DateOfBirth=DateTime.Parse("1996-05-01"), MainCategory="Actor"},
                new Author{FirstName = "Tony",LastName = "Stark", DateOfBirth=DateTime.Parse("1978-12-10"), MainCategory="Actor"},
                new Author{FirstName = "Bruce",LastName = "Wayne", DateOfBirth=DateTime.Parse("1978-10-15"), MainCategory="Actor"}
            };

            foreach (var a in authors)
            {
                context.Authors.Add(a);
            }

            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{AuthorID=1, Title="Cloud Fundamentals", Description="E-Book Cloud Fundamentals"},
                new Course{AuthorID=1, Title="Microservices Architecture", Description="E-Book Microservices Architecture"},
                new Course{AuthorID=2, Title="Backend RESTful API", Description="E-Book Backend RESTful API"},
                new Course{AuthorID=2, Title="Entity Frmework Core", Description="E-Book Entity Frmework Core"},
                new Course{AuthorID=3, Title="Far From Home", Description="E-Book Far From Home"},
                new Course{AuthorID=3, Title="No Way Home", Description="E-Book No Way Home"},
                new Course{AuthorID=4, Title="Iron Man", Description="E-Book Iron Man"},
                new Course{AuthorID=4, Title="Avengers: Endgame", Description="E-Book Avengers: Endgame"},
                new Course{AuthorID=5, Title="The Incredible Hulk", Description="E-Book The Incredible Hulk"}
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();
        }
    }
}
