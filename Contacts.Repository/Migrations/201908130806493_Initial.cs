namespace Contacts.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Email = c.String(),
                    PhoneNumber = c.String(),
                    Status = c.Boolean(),
                })
                .PrimaryKey(t => t.Id);            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}