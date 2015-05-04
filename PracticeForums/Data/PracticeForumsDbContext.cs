namespace PracticeForums.Data
{
    using PracticeForums.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PracticeForumsDbContext : DbContext
    {
        // Your context has been configured to use a 'PracticeForumsDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PracticeForums.Data.PracticeForumsDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PracticeForumsDbContext' 
        // connection string in the application configuration file.
        public PracticeForumsDbContext()
            : base("name=PracticeForumsDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Thread>()
                            .HasMany(x => x.Comments)
                            .WithRequired(c => c.Thread);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}