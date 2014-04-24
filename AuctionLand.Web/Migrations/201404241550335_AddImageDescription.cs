namespace AuctionLand.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealEstateImage", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RealEstateImage", "Description");
        }
    }
}
