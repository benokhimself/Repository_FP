namespace MyMVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Increment22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Increments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        counter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Increments");
        }
    }
}
