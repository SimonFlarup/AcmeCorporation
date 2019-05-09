using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.Migrations
{
    public partial class Serial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "number",
                table: "Movie",
                newName: "Number");

            migrationBuilder.AlterColumn<string>(
                name: "Serial",
                table: "DrawEntry",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "Serial",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serial", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serial");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Movie",
                newName: "number");

            migrationBuilder.AlterColumn<string>(
                name: "Serial",
                table: "DrawEntry",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }
    }
}
