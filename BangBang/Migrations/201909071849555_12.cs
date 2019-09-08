namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Players", new[] { "PlayerName" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Players", "PlayerName", unique: true);
        }
    }
}
