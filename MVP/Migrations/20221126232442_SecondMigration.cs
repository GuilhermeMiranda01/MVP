using Microsoft.EntityFrameworkCore.Migrations;

namespace MVP.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SituacaoUsuario",
                columns: new[] { "Id", "CPF", "TemProcesso" },
                values: new object[] { 1, "123456", true });

            migrationBuilder.InsertData(
                table: "SituacaoUsuario",
                columns: new[] { "Id", "CPF", "TemProcesso" },
                values: new object[] { 2, "654321", false });

            migrationBuilder.InsertData(
                table: "SituacaoUsuario",
                columns: new[] { "Id", "CPF", "TemProcesso" },
                values: new object[] { 3, "111", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SituacaoUsuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SituacaoUsuario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SituacaoUsuario",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
