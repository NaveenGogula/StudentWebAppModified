using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifingStudentIDDatatype1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");
        }
    }
}
