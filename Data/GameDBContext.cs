using Microsoft.EntityFrameworkCore;
using RPG_Console_App_Game.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Data
{
    public class GameDBContext : DbContext
    {
        public DbSet<Warrior> Warriors { get; set; }

        public DbSet<Archer> Archers { get; set; }

        public DbSet<Mage> Mages { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=mysql-210770ab-techstore.b.aivencloud.com;Database=RPGConsoleAppGame;Uid=avnadmin;Pwd=AVNS_ECNjUML_9rCSuGwr_PA;Port=15039");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
