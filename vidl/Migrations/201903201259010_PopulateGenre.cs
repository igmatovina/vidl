namespace vidl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,GenreName) VALUES(1,'Comedy') ");
            Sql("INSERT INTO Genres(Id,GenreName) VALUES(2,'Action') ");
            Sql("INSERT INTO Genres(Id,GenreName) VALUES(3,'Drama') ");
            Sql("INSERT INTO Genres(Id,GenreName) VALUES(4,'Horor') ");
        }
        
        public override void Down()
        {
        }
    }
}
