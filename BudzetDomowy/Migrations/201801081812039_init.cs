namespace BudzetDomowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategorie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        DataDodaniaRekordu = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanowanePrzychody",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kwota = c.Single(nullable: false),
                        Data = c.DateTime(nullable: false),
                        DataDodaniaRekordu = c.DateTime(nullable: false),
                        RodzjeTranzakcji_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RodzjeTranzakcii", t => t.RodzjeTranzakcji_Id)
                .Index(t => t.RodzjeTranzakcji_Id);
            
            CreateTable(
                "dbo.RodzjeTranzakcii",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Aktywna = c.Boolean(nullable: false),
                        DataDodaniaRekordu = c.DateTime(nullable: false),
                        Kategorie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategorie", t => t.Kategorie_Id)
                .Index(t => t.Kategorie_Id);
            
            CreateTable(
                "dbo.PlanowaneRozchody",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kwota = c.Single(nullable: false),
                        Data = c.DateTime(nullable: false),
                        DataDodaniaRekordu = c.DateTime(nullable: false),
                        RodzjeTranzakcji_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RodzjeTranzakcii", t => t.RodzjeTranzakcji_Id)
                .Index(t => t.RodzjeTranzakcji_Id);
            
            CreateTable(
                "dbo.Przychody",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kwota = c.Single(nullable: false),
                        Data = c.DateTime(nullable: false),
                        DataDodaniaRekordu = c.DateTime(nullable: false),
                        RodzjeTranzakcji_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RodzjeTranzakcii", t => t.RodzjeTranzakcji_Id)
                .Index(t => t.RodzjeTranzakcji_Id);
            
            CreateTable(
                "dbo.Rozchody",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kwota = c.Single(nullable: false),
                        Data = c.DateTime(nullable: false),
                        DataDodaniaRekordu = c.DateTime(nullable: false),
                        RodzjeTranzakcji_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RodzjeTranzakcii", t => t.RodzjeTranzakcji_Id)
                .Index(t => t.RodzjeTranzakcji_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rozchody", "RodzjeTranzakcji_Id", "dbo.RodzjeTranzakcii");
            DropForeignKey("dbo.Przychody", "RodzjeTranzakcji_Id", "dbo.RodzjeTranzakcii");
            DropForeignKey("dbo.PlanowaneRozchody", "RodzjeTranzakcji_Id", "dbo.RodzjeTranzakcii");
            DropForeignKey("dbo.PlanowanePrzychody", "RodzjeTranzakcji_Id", "dbo.RodzjeTranzakcii");
            DropForeignKey("dbo.RodzjeTranzakcii", "Kategorie_Id", "dbo.Kategorie");
            DropIndex("dbo.Rozchody", new[] { "RodzjeTranzakcji_Id" });
            DropIndex("dbo.Przychody", new[] { "RodzjeTranzakcji_Id" });
            DropIndex("dbo.PlanowaneRozchody", new[] { "RodzjeTranzakcji_Id" });
            DropIndex("dbo.RodzjeTranzakcii", new[] { "Kategorie_Id" });
            DropIndex("dbo.PlanowanePrzychody", new[] { "RodzjeTranzakcji_Id" });
            DropTable("dbo.Rozchody");
            DropTable("dbo.Przychody");
            DropTable("dbo.PlanowaneRozchody");
            DropTable("dbo.RodzjeTranzakcii");
            DropTable("dbo.PlanowanePrzychody");
            DropTable("dbo.Kategorie");
        }
    }
}
