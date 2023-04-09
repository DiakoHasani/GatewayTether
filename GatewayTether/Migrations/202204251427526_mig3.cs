namespace GatewayTether.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblWallets", "WebhookAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TblWallets", "WebhookAddress");
        }
    }
}
