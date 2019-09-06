namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlayerExperiences", "Experience", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlayerExperiences", "Experience", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
