namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Walletrecords",
                c => new
                    {
                        WalletrecordID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Int(nullable: false),
                        PreviousAmount = c.Int(nullable: false),
                        LatestAmount = c.Int(nullable: false),
                        Player_PlayerID = c.Int(),
                    })
                .PrimaryKey(t => t.WalletrecordID)
                .ForeignKey("dbo.Players", t => t.Player_PlayerID)
                .Index(t => t.Player_PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Walletrecords", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.Walletrecords", new[] { "Player_PlayerID" });
            DropTable("dbo.Walletrecords");
        }
    }
}
