using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class testandoseeddestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Ativo" },
                    { 2, "Inatívo" },
                    { 3, "Em pausa" },
                    { 4, "Excluído" },
                    { 5, "Finalizado" },
                    { 6, "Bloqueado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
