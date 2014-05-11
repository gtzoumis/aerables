namespace aerables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Devices", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Devices", "Field2", c => c.String());
            AddColumn("dbo.Feeds", "MeasurementField1", c => c.Int(nullable: false));
            AddColumn("dbo.Feeds", "MeasurementField2", c => c.Int(nullable: false));
            DropColumn("dbo.Feeds", "Updated_at");
            DropColumn("dbo.Feeds", "Measurement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feeds", "Measurement", c => c.Int(nullable: false));
            AddColumn("dbo.Feeds", "Updated_at", c => c.DateTime(nullable: false));
            DropColumn("dbo.Feeds", "MeasurementField2");
            DropColumn("dbo.Feeds", "MeasurementField1");
            DropColumn("dbo.Devices", "Field2");
            DropColumn("dbo.Devices", "Longitude");
            DropColumn("dbo.Devices", "Latitude");
        }
    }
}
