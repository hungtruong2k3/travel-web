using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDayHoc.Models;
using Btl.Models;

namespace Btl.Data
{
    public class BtlContext : DbContext
    {
        public BtlContext (DbContextOptions<BtlContext> options)
            : base(options)
        {
        }

        public DbSet<WebDayHoc.Models.User> User { get; set; } = default!;

        public DbSet<Btl.Models.Local>? Local { get; set; }

        public DbSet<Btl.Models.Product>? Product { get; set; }
        public DbSet<Btl.Models.FoodList>? FoodList { get; set; }
        public DbSet<Btl.Models.TravelLocation>? TravelLocation { get; set; }
        public DbSet<Btl.Models.Blog>? Blog { get; set; }
        public DbSet<Btl.Models.Contact>? Contacts { get; set; }
		public DbSet<Btl.Models.Checkout>? Checkouts { get; set; }
	}
}
