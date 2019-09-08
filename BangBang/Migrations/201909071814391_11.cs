namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Players", "PlayerName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Players", new[] { "PlayerName" });
        }
    }
}
