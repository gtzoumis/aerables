namespace aerables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0006 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feeds", "Device_Id", "dbo.Devices");
            DropPrimaryKey("dbo.Devices");
            DropPrimaryKey("dbo.Feeds");
            AlterColumn("dbo.Devices", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Feeds", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Devices", "Id");
            AddPrimaryKey("dbo.Feeds", "Id");
            AddForeignKey("dbo.Feeds", "Device_Id", "dbo.Devices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feeds", "Device_Id", "dbo.Devices");
            DropPrimaryKey("dbo.Feeds");
            DropPrimaryKey("dbo.Devices");
            AlterColumn("dbo.Feeds", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Devices", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Feeds", "Id");
            AddPrimaryKey("dbo.Devices", "Id");
            AddForeignKey("dbo.Feeds", "Device_Id", "dbo.Devices", "Id");
        }
    }
}
