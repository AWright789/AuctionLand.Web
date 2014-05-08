namespace AuctionLand.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBidFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealEstate", "HasEnded", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RealEstate", "HasEnded");
        }
    }
}
