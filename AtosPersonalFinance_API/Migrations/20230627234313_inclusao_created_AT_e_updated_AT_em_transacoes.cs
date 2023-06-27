using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtosPersonalFinance_API.Migrations
{
    /// <inheritdoc />
    public partial class inclusao_created_AT_e_updated_AT_em_transacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    type = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    last_name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    user_name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_type = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    value = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    date = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    created_AT = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    updated_AT = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_transaction_category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_transaction_user",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "name", "type" },
                values: new object[,]
                {
                    { 1, "Salário", "revenue" },
                    { 2, "Rendimento de Investimentos", "revenue" },
                    { 3, "Venda de Produtos", "revenue" },
                    { 4, "Reembolsos", "revenue" },
                    { 5, "Aluguéis Recebidos", "revenue" },
                    { 6, "Outros", "revenue" },
                    { 7, "Alimentação", "Expense" },
                    { 8, "Moradia (Aluguel/Financiamento)", "Expense" },
                    { 9, "Transporte", "Expense" },
                    { 10, "Educação", "Expense" },
                    { 11, "Saúde", "Expense" },
                    { 12, "Lazer e Entretenimento", "Expense" },
                    { 13, "Compras", "Expense" },
                    { 14, "Dívidas e Empréstimos", "Expense" },
                    { 15, "Investimentos", "Expense" },
                    { 16, "Doações e Caridade", "Expense" },
                    { 17, "Outros", "Expense" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_name",
                table: "Users",
                column: "user_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
