using TestApplication.Models;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;

namespace TestApplication.DataAccess
{
    public class TestApplicationDbContext : DbContext
    {
        public TestApplicationDbContext() : base(new SQLiteConnection($"Data Source = {Properties.Settings.Default.DatabaseFilePath};"), false)
        {
        }

        public TestApplicationDbContext(DbConnection connection) : base(connection, true)
        {
        }

        public DbSet<TestItem> TestItems { get; set; }
    }
}