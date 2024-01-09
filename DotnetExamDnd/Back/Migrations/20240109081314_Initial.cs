using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    AttackModifier = table.Column<int>(type: "integer", nullable: false),
                    AttacksPerRound = table.Column<int>(type: "integer", nullable: false),
                    DamageDieMultiplier = table.Column<int>(type: "integer", nullable: false),
                    DamageDieSides = table.Column<int>(type: "integer", nullable: false),
                    DamageModifier = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "ArmorClass", "AttackModifier", "AttacksPerRound", "DamageDieMultiplier", "DamageDieSides", "DamageModifier", "HitPoints", "Name" },
                values: new object[,]
                {
                    { 1, 14, 8, 2, 1, 6, 4, 52, "Bonnie" },
                    { 2, 12, 10, 2, 3, 10, 4, 91, "Ashann" },
                    { 3, 11, 4, 1, 1, 4, 0, 22, "Dryad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
