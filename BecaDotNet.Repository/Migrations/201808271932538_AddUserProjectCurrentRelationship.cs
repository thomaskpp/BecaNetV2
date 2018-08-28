namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProjectCurrentRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_USER", "CURRENT_PROJECT_ID", c => c.Int());
            CreateIndex("dbo.TB_USER", "CURRENT_PROJECT_ID");
            AddForeignKey("dbo.TB_USER", "CURRENT_PROJECT_ID", "dbo.TB_PROJECT", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_USER", "CURRENT_PROJECT_ID", "dbo.TB_PROJECT");
            DropIndex("dbo.TB_USER", new[] { "CURRENT_PROJECT_ID" });
            DropColumn("dbo.TB_USER", "CURRENT_PROJECT_ID");
        }
    }
}
