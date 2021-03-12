using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Data.Migrations
{
    public partial class newId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");
        }
    }
}
