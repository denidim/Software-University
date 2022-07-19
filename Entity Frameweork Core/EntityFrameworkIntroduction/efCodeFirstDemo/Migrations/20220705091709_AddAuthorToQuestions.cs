using Microsoft.EntityFrameworkCore.Migrations;

namespace efCodeFirstDemo.Migrations
{
    public partial class AddAuthorToQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Questions");
        }
    }
}
