namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class songchords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SongChords",
                c => new
                    {
                        ChordGroupID = c.Int(nullable: false, identity: true),
                        ChordOne = c.Int(nullable: false),
                        ChordTwo = c.Int(nullable: false),
                        ChordThree = c.Int(nullable: false),
                        ChordFour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChordGroupID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SongChords");
        }
    }
}
