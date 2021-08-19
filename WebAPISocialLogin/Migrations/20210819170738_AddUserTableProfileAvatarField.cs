using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPISocialLogin.Migrations
{
    public partial class AddUserTableProfileAvatarField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileAvatarUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileAvatarUrl",
                table: "Users");
        }
    }
}
