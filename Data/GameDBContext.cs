using Microsoft.EntityFrameworkCore;
using RPG_Console_App_Game.Data.Entities;
using System.Text.Json;

namespace RPG_Console_App_Game.Data
{
    public class GameDBContext : DbContext
    {
        public DbSet<Warrior> Warriors { get; set; }

        public DbSet<Archer> Archers { get; set; }

        public DbSet<Mage> Mages { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string jsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GitSecrets.json");
            string json = File.ReadAllText(jsonFilePath);
            JsonElement root = JsonDocument.Parse(json).RootElement;

            string? connectionString = root.GetProperty("ConnectionStrings").GetProperty("RPG_ConsoleAppGame").GetString();
            optionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
