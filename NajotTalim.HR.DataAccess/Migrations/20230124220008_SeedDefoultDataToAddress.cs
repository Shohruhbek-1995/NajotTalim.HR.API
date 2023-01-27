using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NajotTalim.HR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefoultDataToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "'savobmedia@gmail.com'",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "PostalCode" },
                values: new object[] { 1995, "Imom Buuxriy 11", "To'ytepa 1", "Tshkent", " O'zbekiston", "4700" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1995);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "'savobmedia@gmail.com'");
        }
    }
}
