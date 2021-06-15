using Microsoft.EntityFrameworkCore.Migrations;

namespace bmusicalh.Data.Migrations
{
    public partial class AddBandas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BandasMusics",
                columns: table => new
                {
                    BandaMusicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandaMusicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandaMusicGenero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandaMusicCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandasMusics", x => x.BandaMusicId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandasMusics");
        }
    }
}
