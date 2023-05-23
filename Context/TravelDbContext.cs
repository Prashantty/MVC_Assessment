using Microsoft.EntityFrameworkCore;
using MVC_Assessment.Models;

namespace MVC_Assessment.Context
{
    public class TravelDbContext :DbContext
    {

        public TravelDbContext() { }


        public TravelDbContext(DbContextOptions<TravelDbContext> options ):base(options)
        {
            
        }

        public DbSet<User> users { get; set; }  

        public DbSet<Course> courses { get; set; }

        public DbSet<Batch> batches { get; set; }

        public DbSet<Request> requests { get; set; }    

        public DbSet<MVC_Assessment.Models.RequestViewModel>? RequestViewModel { get; set; }

    }
}
