namespace BecaDotNet.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_CLIENT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CLIENT_NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                        CNPJ = c.Long(nullable: false),
                        CONTACT_NAME = c.String(nullable: false, maxLength: 400, unicode: false),
                        IS_ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_PROJECT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PROJECT_NAME = c.String(nullable: false, maxLength: 200, unicode: false),
                        START_DATE = c.DateTime(nullable: false),
                        END_DATE = c.DateTime(),
                        CLIENT_ID = c.Int(nullable: false),
                        IS_ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_CLIENT", t => t.CLIENT_ID)
                .Index(t => t.CLIENT_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_PROJECT", "CLIENT_ID", "dbo.TB_CLIENT");
            DropIndex("dbo.TB_PROJECT", new[] { "CLIENT_ID" });
            DropTable("dbo.TB_PROJECT");
            DropTable("dbo.TB_CLIENT");
        }
    }
}
