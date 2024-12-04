using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechCareer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixCategoryEventNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    About = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationDeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipationText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoEducations",
                columns: table => new
                {
                    VideoEducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TotalHour = table.Column<double>(type: "float", nullable: false),
                    IsCertified = table.Column<bool>(type: "bit", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InstrutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgrammingLanguage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoEducations", x => x.VideoEducationId);
                    table.ForeignKey(
                        name: "FK_VideoEducations_Instructors_InstrutorId",
                        column: x => x.InstrutorId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 104, 39, 1, 103, 108, 134, 144, 105, 184, 131, 92, 159, 75, 102, 83, 4, 61, 200, 142, 45, 164, 161, 112, 87, 115, 246, 211, 100, 134, 233, 147, 247, 69, 125, 144, 28, 73, 152, 62, 8, 179, 255, 180, 50, 110, 167, 187, 141, 18, 15, 211, 245, 249, 163, 200, 114, 152, 79, 131, 172, 193, 59, 41, 226 }, new byte[] { 228, 209, 180, 119, 52, 164, 117, 121, 143, 127, 62, 56, 149, 108, 133, 206, 238, 30, 233, 164, 87, 174, 212, 127, 78, 95, 199, 67, 202, 175, 71, 49, 82, 55, 213, 178, 158, 116, 95, 202, 248, 214, 146, 211, 95, 61, 28, 46, 30, 120, 125, 18, 115, 188, 63, 236, 43, 187, 118, 46, 142, 22, 131, 171, 48, 83, 83, 64, 54, 137, 216, 211, 197, 238, 217, 63, 160, 229, 253, 118, 161, 235, 134, 157, 74, 231, 11, 109, 43, 148, 65, 68, 16, 142, 100, 208, 113, 39, 185, 222, 201, 190, 236, 192, 7, 143, 234, 172, 11, 251, 79, 103, 89, 120, 83, 125, 80, 249, 123, 1, 89, 137, 187, 0, 162, 67, 107, 238 } });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoEducations_InstrutorId",
                table: "VideoEducations",
                column: "InstrutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "VideoEducations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 202, 143, 232, 240, 34, 138, 97, 155, 88, 54, 47, 52, 219, 38, 41, 123, 89, 197, 212, 176, 60, 246, 97, 42, 135, 215, 56, 149, 130, 68, 223, 113, 124, 57, 147, 24, 151, 46, 117, 61, 65, 36, 235, 67, 24, 180, 175, 120, 189, 239, 74, 232, 248, 185, 33, 48, 157, 101, 194, 71, 224, 2, 71, 231 }, new byte[] { 3, 91, 155, 9, 74, 4, 198, 138, 226, 129, 246, 146, 11, 4, 46, 35, 152, 124, 72, 220, 3, 144, 17, 160, 137, 100, 196, 114, 103, 25, 247, 111, 150, 51, 191, 133, 254, 131, 7, 238, 34, 240, 202, 49, 151, 9, 92, 36, 237, 56, 120, 147, 195, 109, 250, 100, 133, 106, 55, 193, 20, 254, 82, 224, 251, 83, 180, 188, 164, 224, 128, 221, 138, 244, 185, 13, 201, 182, 20, 140, 27, 122, 67, 244, 10, 20, 48, 148, 208, 17, 159, 36, 126, 206, 180, 92, 216, 234, 159, 6, 135, 156, 117, 192, 111, 48, 90, 142, 29, 83, 219, 138, 137, 10, 44, 218, 225, 186, 158, 43, 70, 168, 229, 134, 239, 45, 66, 231 } });
        }
    }
}
