namespace aerables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0008 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ErrorLogs");
            AlterColumn("dbo.ErrorLogs", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.ErrorLogs", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ErrorLogs");
            AlterColumn("dbo.ErrorLogs", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.ErrorLogs", "Id");
        }
    }
}
