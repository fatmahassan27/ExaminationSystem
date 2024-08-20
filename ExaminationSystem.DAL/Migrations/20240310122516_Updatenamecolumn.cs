using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Updatenamecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionTiTle",
                table: "Questions",
                newName: "QuestionTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionTitle",
                table: "Questions",
                newName: "QuestionTiTle");
        }
    }
}
