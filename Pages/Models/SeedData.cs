using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Final_Project.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameDbContext(serviceProvider.GetRequiredService<DbContextOptions<GameDbContext>>()))
            {
               
                if (context.Gaming.Any())
                {
                    return; 
                }
                
                context.Game.AddRange(
                    new Game
                    {
                        Title = "Halo Infinite", ReleaseDate = new DateTime(2021, 09, 15), Genre = "First-person shooter, Free-to-play, Adventure game", Publisher = "Xbox Game Studios", Rating = "16+"
                    },
                     new Game
                    {
                        Title = "Call of Duty: Modern Warefare", ReleaseDate = new DateTime(2019,10, 15), Genre = "First-person shooter", Publisher = "Activision", Rating = "18+"
                    },

                     new Game
                    {
                        Title = "Rocket League", ReleaseDate = new DateTime(2015, 07, 07), Genre = "Sports/Action", Publisher = "Psyonix" , Rating = "E"
                    },

                     new Game
                    {
                        Title = "Grand Theft Auto: V", ReleaseDate = new DateTime(2013,06,17), Genre = "Action-Adventure/Third Person Shooter ", Publisher = "Rockstar Games" , Rating = "18+"
                    }
                    
                );
                
                context.SaveChanges();
            }
        }
    }
}