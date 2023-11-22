using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts {get;set;}
        public DbSet<Recipes> Recipes {get;set;}
        public string DbPath {get;}

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Project1.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source = {DbPath}");
        }
    }
}