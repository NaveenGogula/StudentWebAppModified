using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PushingDepartmentToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentBlock = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentBlock", "DepartmentName", "Description", "HOD" },
                values: new object[,]
                {
                    { 1, "A", "Arts", "Arts department Students", "Arts HOD" },
                    { 2, "B", "Science", "Science department Students", "Science HOD" },
                    { 3, "B", "Computers", "Computers Science department Students", "Science HOD" },
                    { 4, "B", "Aeronautical", "Aeronautical department Students", "Science HOD" },
                    { 5, "B", "DataScience", "DataScience department Students", "Science HOD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
