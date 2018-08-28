namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProjectUserRelationship : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PROJECT_USER", newName: "TB_PROJECT_USER");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TB_PROJECT_USER", newName: "PROJECT_USER");
        }
    }
}
