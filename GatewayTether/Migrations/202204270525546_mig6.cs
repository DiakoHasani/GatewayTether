namespace GatewayTether.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblWebhookRequests", "TransferId", c => c.Long(nullable: false));
            CreateIndex("dbo.TblWebhookRequests", "TransferId");
            AddForeignKey("dbo.TblWebhookRequests", "TransferId", "dbo.TblTransfers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblWebhookRequests", "TransferId", "dbo.TblTransfers");
            DropIndex("dbo.TblWebhookRequests", new[] { "TransferId" });
            DropColumn("dbo.TblWebhookRequests", "TransferId");
        }
    }
}
