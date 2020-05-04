
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Admin;
using RealEstate.Domain.Estate;
using RealEstate.Domain.User;
using System;
using System.Collections.Generic;

using System.Text;

namespace RealEstate.DataLayer.Context
{
   public class RealEstateDbContext: IdentityDbContext<ApplicationUser>
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Estates> Estates { get; set; }
        public DbSet<EstateImage> EstateImages { get; set; }
        public DbSet<EstateStatus> EstateStatuses { get; set; }
        public DbSet<EstateContract> EstateContracts { get; set; }
       public DbSet<RequestEstate> RequestEstates { get; set; }
    }
}
