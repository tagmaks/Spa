namespace Spa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 100),
                        Picture = c.String(maxLength: 100),
                        MiniPicture = c.String(maxLength: 100),
                        Enabled = c.Boolean(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Price = c.Int(nullable: false),
                        Ratio = c.Int(),
                        Discount = c.Int(),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        Size = c.Decimal(precision: 18, scale: 2),
                        IsFreeShipping = c.Boolean(),
                        ItemSold = c.Boolean(),
                        Enabled = c.Boolean(),
                        ShortDescription = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DateAdded = c.DateTime(storeType: "smalldatetime"),
                        DateModified = c.DateTime(storeType: "smalldatetime"),
                        Recomended = c.Boolean(),
                        New = c.Boolean(),
                        OnSale = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        ShipPrice = c.Int(nullable: false),
                        OfferListId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.OfferLists", t => t.OfferListId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OfferListId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.OfferLists",
                c => new
                    {
                        OfferListId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        EndDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OfferListId);
            
            CreateTable(
                "dbo.CustomerGroups",
                c => new
                    {
                        CustomerGroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 30),
                        Discount = c.Int(),
                        OfferListId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerGroupId)
                .ForeignKey("dbo.OfferLists", t => t.OfferListId)
                .Index(t => t.OfferListId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        Gender = c.Int(),
                        RegistrationDate = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        DateOfBirth = c.DateTime(),
                        SubscribedNews = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        CustomerGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerGroups", t => t.CustomerGroupId, cascadeDelete: true)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.CustomerGroupId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDiscount = c.Int(),
                        OrderDate = c.DateTime(storeType: "smalldatetime"),
                        PaymentDate = c.DateTime(storeType: "smalldatetime"),
                        CustomerComment = c.String(maxLength: 255),
                        AdminOrderComment = c.String(maxLength: 255),
                        ShippingCost = c.Int(nullable: false),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Ratios",
                c => new
                    {
                        RatioId = c.Int(nullable: false, identity: true),
                        ProductRatio = c.Int(nullable: false),
                        AddDate = c.DateTime(storeType: "smalldatetime"),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatioId)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ProductPhotos",
                c => new
                    {
                        ProductPhotoId = c.Int(nullable: false, identity: true),
                        PhotoName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 50),
                        Main = c.Boolean(),
                        OriginName = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(storeType: "smalldatetime"),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPhotoId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductVideo",
                c => new
                    {
                        ProductVideoId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 50),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductVideoId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CategoryId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductVideo", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPhotos", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Offers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Offers", "OfferListId", "dbo.OfferLists");
            DropForeignKey("dbo.CustomerGroups", "OfferListId", "dbo.OfferLists");
            DropForeignKey("dbo.Ratios", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Ratios", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CustomerGroupId", "dbo.CustomerGroups");
            DropForeignKey("dbo.ProductCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "CategoryId" });
            DropIndex("dbo.ProductCategories", new[] { "ProductId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductVideo", new[] { "ProductId" });
            DropIndex("dbo.ProductPhotos", new[] { "ProductId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Ratios", new[] { "ProductId" });
            DropIndex("dbo.Ratios", new[] { "CustomerId" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "CustomerGroupId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CustomerGroups", new[] { "OfferListId" });
            DropIndex("dbo.Offers", new[] { "ProductId" });
            DropIndex("dbo.Offers", new[] { "OfferListId" });
            DropTable("dbo.ProductCategories");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductVideo");
            DropTable("dbo.ProductPhotos");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Ratios");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CustomerGroups");
            DropTable("dbo.OfferLists");
            DropTable("dbo.Offers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
