using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonManagementApp.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Discriminator", "EmailAddress", "FullName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 3, "Professor", "professor.a@example.com", "Nguyễn Thanh Bình", "0343689648", 50000.0 },
                    { 4, "Professor", "professor.bb@example.com", "Trần Văn Dương", "0969483658", 100000.0 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "AverageMark", "Discriminator", "EmailAddress", "FullName", "PhoneNumber", "StudentNumber" },
                values: new object[,]
                {
                    { 1, 85.5, "Student", "student.a@example.com", "Lê Công Thành", "0834361811", "000001" },
                    { 2, 75.5, "Student", "student.bb@example.com", "Nguyễn Văn A", "0747657485", "000002" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressOfPersonId", "Name", "Number" },
                values: new object[,]
                {
                    { 1, 2, "Hà Nội", 30 },
                    { 2, 1, "Hà Tĩnh", 38 },
                    { 3, 3, "Quảng Bình", 73 },
                    { 4, 4, "Nghệ An", 37 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
