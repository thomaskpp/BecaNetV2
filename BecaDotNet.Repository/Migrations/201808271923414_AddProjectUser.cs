namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PROJECT_USER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        USER_ID = c.Int(nullable: false),
                        PROJECT_ID = c.Int(nullable: false),
                        START_DATE = c.DateTime(nullable: false),
                        END_DATE = c.DateTime(),
                        IS_ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_PROJECT", t => t.PROJECT_ID, cascadeDelete: false)
                .ForeignKey("dbo.TB_USER", t => t.USER_ID, cascadeDelete: false)
                .Index(t => t.USER_ID)
                .Index(t => t.PROJECT_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PROJECT_USER", "USER_ID", "dbo.TB_USER");
            DropForeignKey("dbo.PROJECT_USER", "PROJECT_ID", "dbo.TB_PROJECT");
            DropIndex("dbo.PROJECT_USER", new[] { "PROJECT_ID" });
            DropIndex("dbo.PROJECT_USER", new[] { "USER_ID" });
            DropTable("dbo.PROJECT_USER");
        }
    }
}
