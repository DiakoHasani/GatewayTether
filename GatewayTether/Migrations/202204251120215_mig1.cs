namespace GatewayTether.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblTransfers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        TransactionId = c.String(),
                        TimeStamp = c.Long(nullable: false),
                        FromAddress = c.String(),
                        ToAddress = c.String(),
                        ContractAddress = c.String(),
                        Quant = c.String(),
                        Confirmed = c.Boolean(nullable: false),
                        ContractRet = c.String(),
                        FinalResult = c.String(),
                        TokenId = c.String(),
                        TokenAbbr = c.String(),
                        TokenName = c.String(),
                        FromAddressIsContract = c.Boolean(nullable: false),
                        ToAddressIsContract = c.Boolean(nullable: false),
                        Revert = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TblWallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 300),
                        CoinType = c.Int(nullable: false),
                        TokenType = c.Int(),
                        Last_Txid = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TblWallets");
            DropTable("dbo.TblTransfers");
        }
    }
}
