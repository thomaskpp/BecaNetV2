namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustUserTypeRelation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TB_USER_TYPE_USER", "USER_ID");
            CreateIndex("dbo.TB_USER_TYPE_USER", "USER_TYPE_ID");
            AddForeignKey("dbo.TB_USER_TYPE_USER", "USER_ID", "dbo.TB_USER", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TB_USER_TYPE_USER", "USER_TYPE_ID", "dbo.TB_USER_TYPE", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_USER_TYPE_USER", "USER_TYPE_ID", "dbo.TB_USER_TYPE");
            DropForeignKey("dbo.TB_USER_TYPE_USER", "USER_ID", "dbo.TB_USER");
            DropIndex("dbo.TB_USER_TYPE_USER", new[] { "USER_TYPE_ID" });
            DropIndex("dbo.TB_USER_TYPE_USER", new[] { "USER_ID" });
        }
    }
}
