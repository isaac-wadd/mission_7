using Microsoft.EntityFrameworkCore.Migrations;

namespace moviesApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    ratingID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    term = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.ratingID);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    movieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryID = table.Column<int>(nullable: false),
                    ratingID = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<string>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lentTo = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.movieID);
                    table.ForeignKey(
                        name: "FK_movies_categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "categories",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movies_ratings_ratingID",
                        column: x => x.ratingID,
                        principalTable: "ratings",
                        principalColumn: "ratingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "name" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "name" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "name" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "name" },
                values: new object[] { 4, "Family" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "name" },
                values: new object[] { 5, "Horror/Suspense" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "name" },
                values: new object[] { 6, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "name" },
                values: new object[] { 7, "Television" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "name" },
                values: new object[] { 8, "VHS" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 8, "TV-PG" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 7, "TV-Y7" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 6, "UR" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 5, "NR" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 1, "G" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 3, "PG-13" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 2, "PG" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 9, "TV-14" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 4, "R" });

            migrationBuilder.InsertData(
                table: "ratings",
                columns: new[] { "ratingID", "term" },
                values: new object[] { 10, "TV-MA" });

            migrationBuilder.CreateIndex(
                name: "IX_movies_categoryID",
                table: "movies",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_movies_ratingID",
                table: "movies",
                column: "ratingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "ratings");
        }
    }
}
