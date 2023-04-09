namespace GatewayTether.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblWebhookRequests",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        Sended = c.Boolean(nullable: false),
                        SendCount = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        WalletId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TblWallets", t => t.WalletId, cascadeDelete: true)
                .Index(t => t.WalletId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblWebhookRequests", "WalletId", "dbo.TblWallets");
            DropIndex("dbo.TblWebhookRequests", new[] { "WalletId" });
            DropTable("dbo.TblWebhookRequests");
        }
    }
}
