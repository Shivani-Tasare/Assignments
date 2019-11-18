namespace ClientProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        clientId = c.Int(nullable: false),
                        clientAddress = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.clientId, cascadeDelete: true)
                .Index(t => t.clientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        clientId = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        last_name = c.String(),
                        DOB = c.String(),
                    })
                .PrimaryKey(t => t.clientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientDetails", "clientId", "dbo.Clients");
            DropIndex("dbo.ClientDetails", new[] { "clientId" });
            DropTable("dbo.Clients");
            DropTable("dbo.ClientDetails");
        }
    }
}
