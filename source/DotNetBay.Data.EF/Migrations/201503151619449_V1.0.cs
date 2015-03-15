namespace DotNetBay.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartPrice = c.Double(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        CurrentPrice = c.Double(nullable: false),
                        StartDateTimeUtc = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDateTimeUtc = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CloseDateTimeUtc = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsClosed = c.Boolean(nullable: false),
                        IsRunning = c.Boolean(nullable: false),
                        ActiveBid_Id = c.Long(),
                        Seller_UniqueId = c.String(nullable: false, maxLength: 128),
                        Winner_UniqueId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bids", t => t.ActiveBid_Id)
                .ForeignKey("dbo.Members", t => t.Seller_UniqueId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Winner_UniqueId)
                .Index(t => t.ActiveBid_Id)
                .Index(t => t.Seller_UniqueId)
                .Index(t => t.Winner_UniqueId);
            
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReceivedOnUtc = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TransactionId = c.Guid(nullable: false),
                        Amount = c.Double(nullable: false),
                        Accepted = c.Boolean(),
                        Auction_Id = c.Long(nullable: false),
                        Bidder_UniqueId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Bidder_UniqueId)
                .Index(t => t.Auction_Id)
                .Index(t => t.Bidder_UniqueId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        UniqueId = c.String(nullable: false, maxLength: 128),
                        DisplayName = c.String(),
                        EMail = c.String(),
                    })
                .PrimaryKey(t => t.UniqueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "Winner_UniqueId", "dbo.Members");
            DropForeignKey("dbo.Auctions", "Seller_UniqueId", "dbo.Members");
            DropForeignKey("dbo.Auctions", "ActiveBid_Id", "dbo.Bids");
            DropForeignKey("dbo.Bids", "Bidder_UniqueId", "dbo.Members");
            DropForeignKey("dbo.Bids", "Auction_Id", "dbo.Auctions");
            DropIndex("dbo.Bids", new[] { "Bidder_UniqueId" });
            DropIndex("dbo.Bids", new[] { "Auction_Id" });
            DropIndex("dbo.Auctions", new[] { "Winner_UniqueId" });
            DropIndex("dbo.Auctions", new[] { "Seller_UniqueId" });
            DropIndex("dbo.Auctions", new[] { "ActiveBid_Id" });
            DropTable("dbo.Members");
            DropTable("dbo.Bids");
            DropTable("dbo.Auctions");
        }
    }
}
