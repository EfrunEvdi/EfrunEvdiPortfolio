using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_contact_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "LinkedIn");

            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Github",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "LinkedIn",
                table: "Contacts",
                newName: "Phone");
        }
    }
}
