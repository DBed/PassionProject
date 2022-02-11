namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chordssongchords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SongChordChords",
                c => new
                    {
                        SongChord_ChordGroupID = c.Int(nullable: false),
                        Chord_ChordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SongChord_ChordGroupID, t.Chord_ChordID })
                .ForeignKey("dbo.SongChords", t => t.SongChord_ChordGroupID, cascadeDelete: true)
                .ForeignKey("dbo.Chords", t => t.Chord_ChordID, cascadeDelete: true)
                .Index(t => t.SongChord_ChordGroupID)
                .Index(t => t.Chord_ChordID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongChordChords", "Chord_ChordID", "dbo.Chords");
            DropForeignKey("dbo.SongChordChords", "SongChord_ChordGroupID", "dbo.SongChords");
            DropIndex("dbo.SongChordChords", new[] { "Chord_ChordID" });
            DropIndex("dbo.SongChordChords", new[] { "SongChord_ChordGroupID" });
            DropTable("dbo.SongChordChords");
        }
    }
}
