namespace Capstone_20130302.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteGender : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "ContactNumber", c => c.String(maxLength: 15));
            DropColumn("dbo.Profiles", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "ContactNumber", c => c.String());
        }
    }
}
