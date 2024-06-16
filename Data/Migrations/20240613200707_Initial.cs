using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG_Console_App_Game.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Archers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    TimeOfCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Race = table.Column<string>(type: "longtext", nullable: false),
                    Symbol = table.Column<string>(type: "varchar(1)", nullable: false),
                    StrengthPoints = table.Column<int>(type: "int", nullable: false),
                    IntelligencePoints = table.Column<int>(type: "int", nullable: false),
                    AgilityPoints = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Mana = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archers", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mages",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    TimeOfCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Race = table.Column<string>(type: "longtext", nullable: false),
                    Symbol = table.Column<string>(type: "varchar(1)", nullable: false),
                    StrengthPoints = table.Column<int>(type: "int", nullable: false),
                    IntelligencePoints = table.Column<int>(type: "int", nullable: false),
                    AgilityPoints = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Mana = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mages", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Warriors",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    TimeOfCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Race = table.Column<string>(type: "longtext", nullable: false),
                    Symbol = table.Column<string>(type: "varchar(1)", nullable: false),
                    StrengthPoints = table.Column<int>(type: "int", nullable: false),
                    IntelligencePoints = table.Column<int>(type: "int", nullable: false),
                    AgilityPoints = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Mana = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warriors", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archers");

            migrationBuilder.DropTable(
                name: "Mages");

            migrationBuilder.DropTable(
                name: "Warriors");
        }
    }
}
