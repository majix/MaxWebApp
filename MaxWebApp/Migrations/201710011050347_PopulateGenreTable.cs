namespace MaxWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert INTO Genres (Id,Name) VALUES (1,'Jazz')");
            Sql("insert INTO Genres (Id,Name) VALUES (2,'Blues')");
            Sql("insert INTO Genres (Id,Name) VALUES (3,'Rock')");
            Sql("insert INTO Genres (Id,Name) VALUES (4,'Country')");
        }
        
        public override void Down()
        {
            Sql("Delete From Genres where id IN (1,2,3,4)");
        }
    }
}
