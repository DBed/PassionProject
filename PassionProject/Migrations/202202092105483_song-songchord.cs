namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class songsongchord : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Songs", "SongChords");
            AddForeignKey("dbo.Songs", "SongChords", "dbo.SongChords", "ChordGroupID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "SongChords", "dbo.SongChords");
            DropIndex("dbo.Songs", new[] { "SongChords" });
        }
    }
}
