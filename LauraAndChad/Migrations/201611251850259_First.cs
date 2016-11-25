namespace LauraAndChad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rsvps",
                c => new
                    {
                        RsvpId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        GuestFirstName = c.String(maxLength: 100),
                        GuestLastName = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 254),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.RsvpId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rsvps");
        }
    }
}
