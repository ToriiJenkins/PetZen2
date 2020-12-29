namespace PetZen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsertoTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pet", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pet", "OwnerId");
        }
    }
}
