namespace GatewayTether.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblErrors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Source = c.String(),
                        HelpLink = c.String(),
                        StackTrace = c.String(),
                        HResult = c.Int(nullable: false),
                        Message = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TblErrors");
        }
    }
}
