using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace product_catalog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneralNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Еда" },
                    { 2, "Вкусности" },
                    { 3, "Вода" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { 1, "antonov@gmail.com", "Антон", "Антонов", "$2a$11$2ktFulxSECyPsZBJ7gn0leR6qIvPZh7TtutlA3F.XwBujZZ37bGl6", "Admin", "Active" },
                    { 2, "reznichenko@gmail.com", "Светлана", "Резниченко", "$2a$11$2ktFulxSECyPsZBJ7gn0leR6qIvPZh7TtutlA3F.XwBujZZ37bGl6", "Admin", "Active" },
                    { 3, "ananko@gmail.com", "Егор", "Ананько", "$2a$11$1cZ7hK79PCWtJut6ND/ogutnQZG4XAVerIYiGFqeZdd5vqpZT52B2", "AdvancedUser", "Active" },
                    { 4, "denisova@gmail.com", "Настя", "Денисова", "$2a$11$1cZ7hK79PCWtJut6ND/ogutnQZG4XAVerIYiGFqeZdd5vqpZT52B2", "AdvancedUser", "Active" },
                    { 5, "pakhomova@gmail.com", "Диана", "Пахомова", "$2a$11$4sYu7Z7DlOIFTClmT0pfguwwXeNA49nO/TVXJ7VeeE/EzQYZ0zgbq", "User", "Active" },
                    { 6, "radkevich@gmail.com", "Наташа", "Радкевич", "$2a$11$4sYu7Z7DlOIFTClmT0pfguwwXeNA49nO/TVXJ7VeeE/EzQYZ0zgbq", "User", "Active" },
                    { 7, "ivanov@gmail.com", "Иван", "Иванов", "$2a$11$4sYu7Z7DlOIFTClmT0pfguwwXeNA49nO/TVXJ7VeeE/EzQYZ0zgbq", "User", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "GeneralNote", "Price", "SpecialNote", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Селедка соленая", "Акция", 10m, "Пересоленая", "Селедка" },
                    { 2, 1, "Тушенка говяжья", "Вкусная", 20m, "Жилы", "Тушенка" },
                    { 3, 2, "В банках", "С ключом", 30m, "Вкусная", "Сгущенка " },
                    { 4, 3, "В бутылках", "Вятский", 15m, "Теплый", "Квас" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
