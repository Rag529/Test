namespace TestApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateTestItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        State = c.Int(nullable: false),
                        Action = c.String(nullable: false, maxLength: 2147483647),
                        Name = c.String(nullable: false, maxLength: 2147483647),
                        Code = c.Int(nullable: false),
                        Retry = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestSubItem",
                c => new
                    {
                        TestItemId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Code = c.Int(nullable: false),
                        SubName = c.String(nullable: false, maxLength: 2147483647),
                    })
                .PrimaryKey(t => new { t.TestItemId, t.Name, t.Code })
                .ForeignKey("dbo.TestItem", t => t.TestItemId, cascadeDelete: true)
                .Index(t => t.TestItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestSubItem", "TestItemId", "dbo.TestItem");
            DropIndex("dbo.TestSubItem", new[] { "TestItemId" });
            DropTable("dbo.TestSubItem");
            DropTable("dbo.TestItem");
        }
    }
}
