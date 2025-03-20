using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class initialapp7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-5e6f-78g9-h0i1-23456789abcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5aac54f1-99e1-4e15-9eaf-2964ca504443", "AQAAAAIAAYagAAAAEGo+0iJUFnzpDaQ7lbS8pjh7EfARnPTeYWy2WVE4gBe/jvbyRYqHevadlaCIvi1tlg==", "e428efb7-2b4f-41c6-bd14-8e2d84d4eec8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-5e6f-78g9-h0i1-23456789abcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2be1c78b-75b6-499c-bfad-bd6986df7855", "AQAAAAIAAYagAAAAEJJFrGWuccU03vHaGQsux/RnAgjQQNdJFVjrMIpg2H/BZ8Va9p+yedLrA3lXN5QgmQ==", "50192ca2-7df9-4aa8-91a9-cf9920c0b2a0" });
        }
    }
}
