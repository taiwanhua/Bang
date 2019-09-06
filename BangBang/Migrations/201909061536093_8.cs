namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
    "dbo.PlayerExperiences",
    c => new
    {
        PlayerID = c.Int(nullable: false, identity: true),
        Experience = c.String(nullable: false, maxLength: 100)
    })
    .PrimaryKey(t => t.PlayerID);

            DropForeignKey("dbo.PlayerExperiences", "PlayerID", "dbo.Players");
            DropPrimaryKey("dbo.PlayerExperiences");
            AlterColumn("dbo.PlayerExperiences", "Experience", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.PlayerExperiences", "PlayerID");
            AddForeignKey("dbo.PlayerExperiences", "PlayerID", "dbo.Players", "PlayerID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.PlayerExperiences", "PlayerID", "dbo.Players");
            DropPrimaryKey("dbo.PlayerExperiences");
            AlterColumn("dbo.PlayerExperiences", "Experience", c => c.String());
            AddForeignKey("dbo.PlayerExperiences", "PlayerID", "dbo.Players", "PlayerID", cascadeDelete: true);
        }
    }
}
