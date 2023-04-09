namespace GatewayTether.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblErrors", "Line", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TblErrors", "Line");
        }
    }
}
