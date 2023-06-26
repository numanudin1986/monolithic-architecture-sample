using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentApp.DataAccess.Entity
{
    public class AgentAppContext : DbContext
    {
        
      
        public AgentAppContext(DbContextOptions<AgentAppContext> options)
              : base(options)
        {
            
        }

        public virtual DbSet<AgentRecord> AgentRecords { get; set; }
        public virtual DbSet<TblLogging> TblLoggings { get; set; }
        public virtual DbSet<TblRawDatum> TblRawData { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<AgentPolicy> AgentPolicy { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["AgentAppDatabase"].ConnectionString;
            // optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AgentAppDatabase"].ConnectionString);
            //optionsBuilder.UseSqlServer(_connectionString);
            //var connection = @"Server=localhost;Database=AgentDb;Trusted_Connection=True;";
            //optionsBuilder.UseSqlServer(connection);
        }
    }
}
