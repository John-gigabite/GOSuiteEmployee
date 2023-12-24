using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GOSuiteEmployee.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "EmployeeId", "EmployeeName", "Salary", "Tenure", "Title" },
                values: new object[,]
                {
                    { 1, 1, "John Gomez", 250000.0, 5, "Chief Executive Officer" },
                    { 2, 2, "Genesis Rea", 250000.0, 5, "Chief Operating Officer" },
                    { 3, 3, "Jane Doe", 150000.0, 3, "Senior Software Engineer" },
                    { 4, 4, "John Doe", 70000.0, 1, "Engineering I" },
                    { 5, 5, "Ash Williams", 85000.0, 3, "Marketing Specialist" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
