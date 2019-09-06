namespace BangBang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Walletrecords", "Timestamp", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Walletrecords", "Timestamp", c => c.Int(nullable: false));
        }
    }
}
