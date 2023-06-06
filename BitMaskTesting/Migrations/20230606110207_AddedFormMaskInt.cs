using Microsoft.EntityFrameworkCore.Migrations;

namespace BitMaskTesting.Migrations
{
    public partial class AddedFormMaskInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormMaskInt",
                table: "DocumentType",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormMaskInt",
                table: "DocumentType");
        }
    }
}
