namespace aerables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Device_Id = c.Int(nullable: false),
                        Name = c.String(),
                        Field1 = c.String(),
                        Created_at = c.DateTime(nullable: false),
                        Updated_at = c.DateTime(nullable: false),
                        Last_entry = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Devices", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Devices");
        }
    }
}
