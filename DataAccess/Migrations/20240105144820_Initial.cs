using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryBorrowerId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ReturnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Borrowers_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Borrowers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("503939b1-a170-4474-aa31-f89f5c878bbb"), "Author 3" },
                    { new Guid("a8305503-a8da-4830-bcec-fa985e594a90"), "Author 2" },
                    { new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"), "Author 1" }
                });

            migrationBuilder.InsertData(
                table: "Borrowers",
                columns: new[] { "Id", "LibraryBorrowerId", "Name" },
                values: new object[,]
                {
                    { new Guid("4ecc1064-a880-4822-87cc-9c39a224eeaf"), "4ecc1064", "Jane Doe" },
                    { new Guid("a373da2e-3e3f-4b54-b42e-f088123fa2f0"), "a373da2e", "John Doe" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BorrowerId", "ISBN", "ImageUrl", "IsAvailable", "Name", "ReturnDate" },
                values: new object[,]
                {
                    { new Guid("094ada91-108c-42d2-876b-a982db803495"), new Guid("503939b1-a170-4474-aa31-f89f5c878bbb"), null, "557aa7f8", "images\\book\\default.jpg", true, "Book 9", null },
                    { new Guid("3c042ca7-6ebc-4e8c-80c0-cd65f7ebc021"), new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"), null, "af28af8b", "images\\book\\default.jpg", true, "Book 12", null },
                    { new Guid("442daaec-0a77-48b2-b236-140fd3636cdb"), new Guid("a8305503-a8da-4830-bcec-fa985e594a90"), null, "2de3c3f6", "images\\book\\default.jpg", true, "Book 8", null },
                    { new Guid("444e0e9b-51ce-4776-ab84-0031ae083cc4"), new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"), null, "deea87ff", "images\\book\\default.jpg", true, "Book 10", null },
                    { new Guid("517c37bb-720c-48d5-8e26-8d2ed1e3933a"), new Guid("a8305503-a8da-4830-bcec-fa985e594a90"), new Guid("4ecc1064-a880-4822-87cc-9c39a224eeaf"), "89154c1a", "images\\book\\default.jpg", false, "Book 11", new DateTimeOffset(new DateTime(2024, 1, 28, 17, 48, 20, 464, DateTimeKind.Unspecified).AddTicks(9641), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("5c3a0e12-2bc9-45e1-abb3-c3201c94295e"), new Guid("503939b1-a170-4474-aa31-f89f5c878bbb"), new Guid("a373da2e-3e3f-4b54-b42e-f088123fa2f0"), "577e91b9", "images\\book\\default.jpg", false, "Book 3", new DateTimeOffset(new DateTime(2023, 12, 29, 17, 48, 20, 464, DateTimeKind.Unspecified).AddTicks(9596), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("765d0dac-fe8c-447d-a238-f2d941a919aa"), new Guid("a8305503-a8da-4830-bcec-fa985e594a90"), null, "b40e31a9", "images\\book\\default.jpg", true, "Book 5", null },
                    { new Guid("7f039958-66fc-4b1a-9234-a3775c00cbe6"), new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"), new Guid("4ecc1064-a880-4822-87cc-9c39a224eeaf"), "123c832b", "images\\book\\default.jpg", false, "Book 6", new DateTimeOffset(new DateTime(2024, 1, 4, 17, 48, 20, 464, DateTimeKind.Unspecified).AddTicks(9617), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("84c52f0a-401d-40d2-80a1-281e48d5c17e"), new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"), new Guid("4ecc1064-a880-4822-87cc-9c39a224eeaf"), "a4378485", "images\\book\\default.jpg", false, "Book 1", new DateTimeOffset(new DateTime(2024, 2, 1, 17, 48, 20, 464, DateTimeKind.Unspecified).AddTicks(9523), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("b64f2fee-3829-4b9b-af12-bfee40fde344"), new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"), new Guid("a373da2e-3e3f-4b54-b42e-f088123fa2f0"), "646436b2", "images\\book\\default.jpg", false, "Book 4", new DateTimeOffset(new DateTime(2024, 1, 30, 17, 48, 20, 464, DateTimeKind.Unspecified).AddTicks(9603), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("db63310e-3ddc-4715-a9cd-1f0cf4b14a59"), new Guid("a8305503-a8da-4830-bcec-fa985e594a90"), null, "2c47ef87", "images\\book\\default.jpg", true, "Book 2", null },
                    { new Guid("f95b5bbe-daa9-4b45-9db7-dfff0126d384"), new Guid("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"), null, "ac0d6041", "images\\book\\default.jpg", true, "Book 7", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BorrowerId",
                table: "Books",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_LibraryBorrowerId",
                table: "Borrowers",
                column: "LibraryBorrowerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Borrowers");
        }
    }
}
