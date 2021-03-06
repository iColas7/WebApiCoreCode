using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApiCoreCode 
{
    public class DBContext: DbContext
    {
        public string provider;
        public string connString;

        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<SerieRecord> Serie { get; set; }

        public DBContext(string provider, string connString) 
        {
            this.provider = provider;
            this.connString = connString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder o)
        {
            switch(this.provider)
            {
                case "System.Data.SQLite":
                    o.UseSqlite(this.connString);
                    break;
                case "System.Data.SqlClient":
                    o.UseSqlServer(this.connString);
                    break;
            }
        }

        public class Cliente
        {
            public int id { get; set; }
            public string nome { get; set; }
        }

        public class Ordine
        {
            public int id { get; set; }
            public int idcliente { get; set; }
            public int codice { get; set; }
            public string descr { get; set; }
        }

        public class SerieRecord
        {
            [Key]
            public int time { get; set; }            
            public int? esempio { get; set; }
            public double? esempio2 { get; set; }
            public int? Passengers { get; set; }
            public int? jewelry { get; set; }
        }
    }
}