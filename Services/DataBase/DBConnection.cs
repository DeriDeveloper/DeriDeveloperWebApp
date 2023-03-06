using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DeriDeveloperWebApp.Services.DataBase
{
    public class DBConnection: DbContext
    {
        public DbSet<Models.Soft> Softs { get; set; }



        public void RestartDataBase()
        {
            try
            {
                Database.EnsureDeleted(); // удаляет базу данных
                if (!Database.GetService<IRelationalDatabaseCreator>().Exists())
                {
                    Database.EnsureCreated(); // создает базу данных
                }

            }
            catch (Exception error)
            {
                DeriLibrary.Console.Worker.NotifyErrorMessageCall(error);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=93.80.203.19;DataBase=DeriDeveloperWeb;User Id=DeriDeveloper;
                                          Password=Alex1980lolx@;TrustServerCertificate=true;MultipleActiveResultSets=True;"); //Connect Timeout=5;
        }
    }
}
