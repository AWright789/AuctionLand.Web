namespace AuctionLand.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RealEstateImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        RealEstate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RealEstate", t => t.RealEstate_Id, cascadeDelete: true)
                .Index(t => t.RealEstate_Id);
            
            CreateTable(
                "dbo.RealEstate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearBuilt = c.Int(nullable: false),
                        Summary = c.String(),
                        EstateSize = c.Double(nullable: false),
                        LotSize = c.Double(nullable: false),
                        Bedrooms = c.Int(nullable: false),
                        Bathrooms = c.Double(nullable: false),
                        ListingStatusId = c.Int(nullable: false),
                        Featured = c.Boolean(nullable: false),
                        ListingTypeId = c.Int(nullable: false),
                        OccupancyStatusId = c.Int(nullable: false),
                        RealEstateTypeId = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Location = c.Geography(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SaleDate = c.DateTime(),
                        StartingBid = c.Double(nullable: false),
                        EndingBid = c.Double(nullable: false),
                        BidIncrement = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RealEstateImage", "RealEstate_Id", "dbo.RealEstate");
            DropIndex("dbo.RealEstateImage", new[] { "RealEstate_Id" });
            DropTable("dbo.RealEstate");
            DropTable("dbo.RealEstateImage");
        }
    }
}
