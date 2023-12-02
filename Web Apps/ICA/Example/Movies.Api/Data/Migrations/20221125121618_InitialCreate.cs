using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Api.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NationalityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DirectorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_People_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.PersonId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "Title" },
                values: new object[] { 1, "British" });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "Title" },
                values: new object[] { 2, "French" });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "Title" },
                values: new object[] { 3, "American" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Birthday", "FirstName", "LastName", "NationalityId" },
                values: new object[] { 1, new DateTime(2022, 11, 25, 12, 16, 18, 248, DateTimeKind.Local).AddTicks(203), "Larry", "Losser", 1 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Birthday", "FirstName", "LastName", "NationalityId" },
                values: new object[] { 2, new DateTime(1970, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simon", "Pegg", 1 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Birthday", "FirstName", "LastName", "NationalityId" },
                values: new object[] { 3, new DateTime(1976, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benedict", "Cumberbatch", 1 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Birthday", "FirstName", "LastName", "NationalityId" },
                values: new object[] { 4, new DateTime(1948, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jean", "Reno", 2 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Birthday", "FirstName", "LastName", "NationalityId" },
                values: new object[] { 5, new DateTime(1980, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "Pine", 3 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Birthday", "FirstName", "LastName", "NationalityId" },
                values: new object[] { 6, new DateTime(1966, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "JJ", "Abrams", 3 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Birthday", "FirstName", "LastName", "NationalityId" },
                values: new object[] { 7, new DateTime(1971, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Justin", "Lin", 3 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 1, 6, new DateTime(2015, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: The Force Awakens" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 2, 6, new DateTime(2009, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Trek" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 3, 7, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Trek Beyond" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 4, 7, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fast & Furious" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 5, 7, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fast Five" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 6, 7, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fast & Furious 6" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 7, 7, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hollywood Adventures" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 8, 6, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Trek Into Darkness" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 9, 6, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mission: Impossible III" });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieId", "PersonId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieId", "PersonId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieId", "PersonId" },
                values: new object[] { 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_MovieId",
                table: "MovieActors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_People_NationalityId",
                table: "People",
                column: "NationalityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Nationalities");
        }
    }
}
