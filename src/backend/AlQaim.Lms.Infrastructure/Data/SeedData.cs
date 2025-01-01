using AlQaim.Lms.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlQaim.Lms.Infrastructure.Data
{
    public static class SeedData
    {
        public static readonly Course Course = new Course { 
            Id = 1,
            Title = "Quranic Science",
            Description = "The teaching of Ahlulbait a.s"
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var dbContext = new QaimDbContext(serviceProvider.GetRequiredService<DbContextOptions<QaimDbContext>>(),null))
            {
                if (dbContext.Courses.Any()) return; // db has been seeded
                
            }
        }

        public static void PopulateTestData(QaimDbContext dbContext)
        {
            foreach(var course in dbContext.Courses)
            {
                dbContext.Remove(course);
            }
            dbContext.SaveChanges();
            dbContext.Courses.Add(Course);
            dbContext.SaveChanges();
        }
    }
}
