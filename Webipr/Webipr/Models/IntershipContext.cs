using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Webipr.Models
{
    public class IntershipContext : DbContext
    {
        public DbSet<Checks> Checks { get; set; }
        public DbSet<Words> Words { get; set; }
    }
}