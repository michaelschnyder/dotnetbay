using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.Data.EF
{
    public class EFMainRepository : IMainRepository
    {
        private MainDbContext dbContext;

        public EFMainRepository()
        {
            dbContext = new MainDbContext();
        }

        public Database Database
        {
            get
            {
                return dbContext.Database;    
            }
        }

        public IQueryable<Auction> GetAuctions()
        {
            return this.dbContext.Auctions;
        }

        public IQueryable<Member> GetMembers()
        {
            return this.dbContext.Members;
        }

        public Auction Add(Auction auction)
        {
            return this.dbContext.Auctions.Add(auction);
        }

        public Auction Update(Auction auction)
        {
            this.dbContext.SaveChanges();
            return auction;
        }

        public Bid Add(Bid bid)
        {
            return this.dbContext.Bids.Add(bid);
        }

        public Bid GetBidByTransactionId(Guid transactionId)
        {
            return this.dbContext
                .Bids.Where(b => b.TransactionId == transactionId)
                .FirstOrDefault();
        }

        public Member Add(Member member)
        {
            return this.dbContext.Members.Add(member);
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
