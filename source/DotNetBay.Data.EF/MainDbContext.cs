using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DotNetBay.Model;
using System.ComponentModel.DataAnnotations;

namespace DotNetBay.Data.EF
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
            : base("DatabaseConnection")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = true; // FIXME
        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Member> Members { get; set; }
        
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasKey(m => m.UniqueId);

            modelBuilder.Entity<Auction>().HasRequired(m => m.Seller).WithMany(m => m.Auctions);
            modelBuilder.Entity<Bid>().HasRequired(a => a.Auction).WithMany(m => m.Bids);


        }

    }
}
