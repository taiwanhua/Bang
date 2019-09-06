namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Walletrecords", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.Walletrecords", new[] { "Player_PlayerID" });
            RenameColumn(table: "dbo.Walletrecords", name: "Player_PlayerID", newName: "PlayerID");
            AlterColumn("dbo.Walletrecords", "PlayerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Walletrecords", "PlayerID");
            AddForeignKey("dbo.Walletrecords", "PlayerID", "dbo.Players", "PlayerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Walletrecords", "PlayerID", "dbo.Players");
            DropIndex("dbo.Walletrecords", new[] { "PlayerID" });
            AlterColumn("dbo.Walletrecords", "PlayerID", c => c.Int());
            RenameColumn(table: "dbo.Walletrecords", name: "PlayerID", newName: "Player_PlayerID");
            CreateIndex("dbo.Walletrecords", "Player_PlayerID");
            AddForeignKey("dbo.Walletrecords", "Player_PlayerID", "dbo.Players", "PlayerID");
        }
    }
}
