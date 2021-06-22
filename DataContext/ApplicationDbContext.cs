using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_OSM.Models;

namespace MVC_OSM.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base(nameOrConnectionString: "Myconnection")
        {

        }
        public virtual DbSet<EmpClass> Empobj { get; set; }

        public System.Data.Entity.DbSet<MVC_OSM.Models.PlaceClass> PlaceClasses { get; set; }
    }
}