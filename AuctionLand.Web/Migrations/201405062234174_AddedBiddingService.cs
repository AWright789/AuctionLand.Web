namespace AuctionLand.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBiddingService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bid", "IsWinner", c => c.Boolean(nullable: false));
            AlterColumn("dbo.RealEstate", "StartingBid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RealEstate", "EndingBid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RealEstate", "BidIncrement", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RealEstate", "BidIncrement", c => c.Double(nullable: false));
            AlterColumn("dbo.RealEstate", "EndingBid", c => c.Double(nullable: false));
            AlterColumn("dbo.RealEstate", "StartingBid", c => c.Double(nullable: false));
            DropColumn("dbo.Bid", "IsWinner");
        }
    }
}
