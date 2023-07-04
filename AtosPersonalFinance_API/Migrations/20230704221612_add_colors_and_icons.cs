using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtosPersonalFinance_API.Migrations
{
    /// <inheritdoc />
    public partial class add_colors_and_icons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Categories",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "Categories",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "color", "icon" },
                values: new object[] { "4CAF50", "attach_money" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "color", "icon" },
                values: new object[] { "9C27B0", "show_chart" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "color", "icon" },
                values: new object[] { "FF9800", "shopping_cart" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "color", "icon" },
                values: new object[] { "2196F3", "receipt" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "color", "icon" },
                values: new object[] { "009688", "home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "color", "icon" },
                values: new object[] { "607D8B", "category" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "color", "icon" },
                values: new object[] { "F44336", "restaurant" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "color", "icon" },
                values: new object[] { "3F51B5", "home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "color", "icon" },
                values: new object[] { "FFC107", "commute" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "color", "icon" },
                values: new object[] { "2196F3", "school" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "color", "icon" },
                values: new object[] { "E91E63", "local_hospital" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "color", "icon" },
                values: new object[] { "673AB7", "sports_esports" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "color", "icon" },
                values: new object[] { "00BCD5", "shopping_basket" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "color", "icon" },
                values: new object[] { "FF5722", "credit_card" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "color", "icon" },
                values: new object[] { "795548", "trending_up" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "color", "icon" },
                values: new object[] { "8BC34A", "favorite" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "color", "icon" },
                values: new object[] { "607D8B", "category" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "icon",
                table: "Categories");
        }
    }
}
