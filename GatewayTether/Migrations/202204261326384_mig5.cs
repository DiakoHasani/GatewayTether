namespace GatewayTether.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblWebhookRequests", "SendCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblWebhookRequests", "SendCount", c => c.Boolean(nullable: false));
        }
    }
}
