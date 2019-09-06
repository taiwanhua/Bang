namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "PlayerName", c => c.String());
            AddColumn("dbo.Players", "PlayerVipLevel", c => c.Int(nullable: false));
            DropColumn("dbo.Players", "VipLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "VipLevel", c => c.Int(nullable: false));
            DropColumn("dbo.Players", "PlayerVipLevel");
            DropColumn("dbo.Players", "PlayerName");
        }
    }
}
