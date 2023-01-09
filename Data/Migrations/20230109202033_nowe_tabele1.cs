using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace info_2022.Data.Migrations
{
    public partial class nowe_tabele1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pytankos",
                columns: table => new
                {
                    IdPytanie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Odpowiedz = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pytankos", x => x.IdPytanie);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pytankos");
        }
    }
}
