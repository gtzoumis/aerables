namespace aerables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0009 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Field3", c => c.String());
            AddColumn("dbo.Devices", "Field4", c => c.String());
            AddColumn("dbo.Feeds", "MeasurementField3", c => c.Int(nullable: false));
            AddColumn("dbo.Feeds", "MeasurementField4", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feeds", "MeasurementField4");
            DropColumn("dbo.Feeds", "MeasurementField3");
            DropColumn("dbo.Devices", "Field4");
            DropColumn("dbo.Devices", "Field3");
        }
    }
}
