using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PO_Assignment.Models
{
    public class PodbContext : DbContext
    {
        public PodbContext() : base("PoConnection")
        {

        }

        public DbSet<VendorEntryModel> VentorEntryTable { get; set; }
        public DbSet<MaterialEntryModel> MaterialEntryTable { get; set; }
        public DbSet<PoHeaderModel> PoHeaderTable { get; set; }
        public DbSet<PoDetailsModel> PoDetailsTable { get; set; }
    }
}