namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerExperiences", "Experience", c => c.String(nullable: false));
            DropColumn("dbo.PlayerExperiences", "Experience1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlayerExperiences", "Experience1", c => c.String(nullable: false));
            DropColumn("dbo.PlayerExperiences", "Experience");
        }
    }
}
