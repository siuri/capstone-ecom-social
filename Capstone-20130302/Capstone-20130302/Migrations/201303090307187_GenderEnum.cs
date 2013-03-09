namespace Capstone_20130302.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "DisplayName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Profiles", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "Gender", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Profiles", "DisplayName", c => c.String());
        }
    }
}
