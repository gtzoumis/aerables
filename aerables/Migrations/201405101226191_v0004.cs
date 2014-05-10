namespace aerables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Entry_Id = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Updated_at = c.DateTime(nullable: false),
                        Measurement = c.Int(nullable: false),
                        Device_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.Device_Id)
                .Index(t => t.Device_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feeds", "Device_Id", "dbo.Devices");
            DropIndex("dbo.Feeds", new[] { "Device_Id" });
            DropTable("dbo.Feeds");
        }
    }
}
