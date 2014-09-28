namespace aerables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0010 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "APIKey", c => c.String());
            DropColumn("dbo.Devices", "ThingSpeakKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "ThingSpeakKey", c => c.String());
            DropColumn("dbo.Devices", "APIKey");
        }
    }
}
