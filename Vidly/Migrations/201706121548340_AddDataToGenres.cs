namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id, Name) Values (1, 'Action')");
            Sql("Insert into Genres (Id, Name) Values (2, 'Comedy')");
            Sql("Insert into Genres (Id, Name) Values (3, 'Family')");
            Sql("Insert into Genres (Id, Name) Values (4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
