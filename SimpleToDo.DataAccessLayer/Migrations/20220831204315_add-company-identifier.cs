using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleToDo.DataAccessLayer.Migrations
{
    public partial class addcompanyidentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Companies");
        }
    }
}
