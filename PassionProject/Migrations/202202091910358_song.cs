namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class song : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        SongName = c.String(),
                        SongArtist = c.String(),
                        SongDifficulty = c.String(),
                        SongChords = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SongID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Songs");
        }
    }
}
