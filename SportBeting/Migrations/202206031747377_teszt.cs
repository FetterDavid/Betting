namespace SportBeting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teszt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teszts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teszts");
        }
    }
}
