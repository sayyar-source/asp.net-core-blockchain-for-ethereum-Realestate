using Microsoft.EntityFrameworkCore;
using RealEstate.DomainClasses.Admin;
using RealEstate.DomainClasses.Estate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.DomainClasses
{
   public class EstateContext:DbContext
    {
        public EstateContext(DbContextOptions<EstateContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Estates> Estates { get; set; }
        public DbSet<EstateImage> EstateImages { get; set; }
        public DbSet<EstateStatus> EstateStatuses { get; set; }
    }
}
