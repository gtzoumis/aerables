namespace aerables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0007 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Created_at = c.DateTime(nullable: false),
                        Message = c.String(),
                        CallStack = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ErrorLogs");
        }
    }
}
