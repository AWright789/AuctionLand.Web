namespace AuctionLand.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BidMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bid",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RealEstateId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(nullable: false),
                        IsAutoBid = c.Boolean(nullable: false),
                        OutBidNotificationSent = c.Boolean(nullable: false),
                        IsWinningBid = c.Boolean(nullable: false),
                        PaymentError = c.Boolean(nullable: false),
                        PaymentErrorMessage = c.String(),
                        AllowSelfOutbid = c.Boolean(nullable: false),
                        DeviceType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bid");
        }
    }
}
