namespace CodeFirst
{
    using CodeFirst.DAL;
    using CodeFirst.DTO;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FM : DbContext
    {
        private static FM _Instance;
        public static FM Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new FM();
                return _Instance;
            }
            private set => _Instance = value;
        }
        // Your context has been configured to use a 'FM' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirst.FM' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FM' 
        // connection string in the application configuration file.
        public FM()
            : base("name=FM.cs")
        {
            Database.SetInitializer(new CreateDB());
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}