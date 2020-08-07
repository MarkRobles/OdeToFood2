using Microsoft.EntityFrameworkCore;
using OdeToFood2.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood2.Data
{
    public class OdeToFoodDbContext:DbContext
    {

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
           : base(options)//DbContext (Father class) constructor
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
