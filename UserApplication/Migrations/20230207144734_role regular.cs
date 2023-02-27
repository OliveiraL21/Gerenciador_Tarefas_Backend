using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApplication.Migrations
{
    public partial class roleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "254e0cea-e3bf-49ff-ab42-391bac3f3252", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "04fc6dd6-088d-4409-af1b-b9732298315e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5bfa6cb-bd28-4701-b13f-dabcad28959e", "AQAAAAEAACcQAAAAEOuf5lAt6J/CS/6TW+A8eejiYBxNQu1kJd8Wwt6WiDv/2q8N5T9kLE/UZBSGNCfJcQ==", "6fc66866-c3c6-43de-a1ca-c10955c900ef" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "0aec494e-323a-4cca-8b71-1ddf84c1299a", "regular" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "0fcd8107-95ac-4393-8d4e-0d2304faad26");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07bf357e-5b08-48a3-84c9-5c6aff9b34eb", "AQAAAAEAACcQAAAAEGsxyamI0LEFbEHMMOusBCmHrNndJzvfZFAqelmu0rq2UBGIGV4DhRcYitZAiChXrw==", "fa31261a-64f2-4558-8a6f-bf1f47ff1e07" });
        }
    }
}
