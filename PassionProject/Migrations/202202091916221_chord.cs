namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chords",
                c => new
                    {
                        ChordID = c.Int(nullable: false, identity: true),
                        ChordName = c.String(),
                        StringOne = c.String(),
                        StringTwo = c.String(),
                        StringThree = c.String(),
                        StringFour = c.String(),
                        StringFive = c.String(),
                        StringSix = c.String(),
                    })
                .PrimaryKey(t => t.ChordID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chords");
        }
    }
}
