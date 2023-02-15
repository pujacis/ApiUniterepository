using InterfaceEntity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataContext
{
    public class DataAccessLayerContext:  IdentityDbContext<IdentityUser>
    {
        //https://medium.com/@jaydeepvpatil225/unit-of-work-with-generic-repository-implementation-using-net-core-6-web-api-23d159c63dd4
        public DataAccessLayerContext(DbContextOptions<DataAccessLayerContext> options):base(options)
        {

        }
      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<RepoWithCountry> country { get; set; }
        public DbSet<RepoWithCountry> City { get; set; }
        public DbSet<RepoWithCountry> State { get; set; }
        public DbSet<TaskPerson> TaskPerson { get; set; }
        public DbSet<Address> TaskAddress { get; set; }
    }
}
