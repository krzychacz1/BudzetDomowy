namespace BudzetDomowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_column_Rodzaj_to_table_RodzajeTranzakcii : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RodzjeTranzakcii", "Rodzaj", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RodzjeTranzakcii", "Rodzaj");
        }
    }
}
