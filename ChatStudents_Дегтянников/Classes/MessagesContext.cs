using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatStudents_Дегтянников.Classes
{
    public class MessagesContext:DbContext
    {
        public DbSet<Models.Messages> Messages { get; set; }
        public MessagesContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Common.Config.ConnectionConfig, Common.Config.Version);
        }
    }
}
