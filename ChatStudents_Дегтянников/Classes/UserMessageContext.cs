using ChatStudents_Дегтянников.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatStudents_Дегтянников.Classes
{
    public class UserMessageContext: DbContext
    {
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Users> Users { get; set; } 
        public UserMessageContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Config.config);
            optionsBuilder.UseMySql(Common.Config.ConnectionConfig, Common.Config.Version);
        }
    }
}
