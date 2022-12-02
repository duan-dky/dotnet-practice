#define Rating
#if Rating
#region snippet_1 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                #region snippet1
                context.Movie.AddRange(
                    new Movie
                    {
                        Id = "20220004",
                        Name = "金沫姣",
                        Sex = "女",
                        Birth = "2022/9/13",
                        Phone = "13443267055",
                        School = "石家庄铁道大学",
                        Grade = 582
                    },
                #endregion

                    new Movie
                    {
                        Id = "20220001",
                        Name = "符轶依",
                        Sex="男",
                        Birth="2022/9/13",
                        Phone= "15294848079",
                        School="石家庄铁道大学",
                        Grade=573
                    },

                    new Movie
                    {
                        Id = "20220002",
                        Name = "沈彤鹭",
                        Sex = "男",
                        Birth = "2022/9/13",
                        Phone = "13588369941",
                        School = "石家庄铁道大学",
                        Grade = 576
                    },

                    new Movie
                    {
                        Id = "20220003",
                        Name = "松舜",
                        Sex = "女",
                        Birth = "2022/9/13",
                        Phone = "13297647692",
                        School = "石家庄铁道大学",
                        Grade = 580
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
#endregion
#endif
