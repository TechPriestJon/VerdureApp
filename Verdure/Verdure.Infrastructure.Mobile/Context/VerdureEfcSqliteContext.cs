using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Verdure.Infrastructure.Mobile
{
    public class VerdureEfcSqliteContext : VerdureEfcContext
    {
        private const string databaseName = "database.db";

        public VerdureEfcSqliteContext(DbContextOptions options) : base(options)
        { }

        public VerdureEfcSqliteContext() : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName); ;
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            // Specify that we will use sqlite and the path of the database here
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}
