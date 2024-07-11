using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PushingDepartmentToDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                columns: new[] { "DepartmentBlock", "HOD" },
                values: new object[] { "C", "Computers HOD" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                columns: new[] { "DepartmentBlock", "HOD" },
                values: new object[] { "D", "Aeronautical HOD" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5,
                columns: new[] { "DepartmentBlock", "HOD" },
                values: new object[] { "E", "DataScience HOD" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                columns: new[] { "DepartmentBlock", "HOD" },
                values: new object[] { "B", "Science HOD" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                columns: new[] { "DepartmentBlock", "HOD" },
                values: new object[] { "B", "Science HOD" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5,
                columns: new[] { "DepartmentBlock", "HOD" },
                values: new object[] { "B", "Science HOD" });
        }
    }
}
