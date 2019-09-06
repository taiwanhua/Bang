namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameRecords",
                c => new
                    {
                        GameRecordID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Long(nullable: false),
                        Stake = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameRecordID)
                .ForeignKey("dbo.Players", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameRecords", "PlayerID", "dbo.Players");
            DropIndex("dbo.GameRecords", new[] { "PlayerID" });
            DropTable("dbo.GameRecords");
        }
    }
}
