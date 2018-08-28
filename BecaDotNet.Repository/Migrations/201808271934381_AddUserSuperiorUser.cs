namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSuperiorUser : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TB_USER", "SUPERIOR_ID");
            AddForeignKey("dbo.TB_USER", "SUPERIOR_ID", "dbo.TB_USER", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_USER", "SUPERIOR_ID", "dbo.TB_USER");
            DropIndex("dbo.TB_USER", new[] { "SUPERIOR_ID" });
        }
    }
}
