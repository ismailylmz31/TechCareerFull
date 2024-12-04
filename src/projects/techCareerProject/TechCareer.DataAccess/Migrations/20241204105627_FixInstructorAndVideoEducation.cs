using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechCareer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixInstructorAndVideoEducation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoEducations_Instructors_InstrutorId",
                table: "VideoEducations");

            migrationBuilder.RenameColumn(
                name: "InstrutorId",
                table: "VideoEducations",
                newName: "InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoEducations_InstrutorId",
                table: "VideoEducations",
                newName: "IX_VideoEducations_InstructorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "VideoEducations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 56, 26, 951, DateTimeKind.Utc).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 56, 26, 952, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 12, 4, 10, 56, 26, 952, DateTimeKind.Utc).AddTicks(175), new byte[] { 8, 6, 104, 254, 190, 77, 107, 116, 207, 201, 31, 41, 30, 94, 250, 229, 199, 195, 106, 12, 66, 216, 165, 128, 44, 119, 208, 35, 132, 203, 25, 31, 250, 171, 21, 109, 172, 212, 221, 100, 124, 140, 169, 55, 159, 243, 202, 138, 188, 14, 234, 255, 4, 211, 203, 213, 130, 6, 227, 135, 250, 27, 36, 209 }, new byte[] { 178, 24, 53, 145, 130, 62, 191, 26, 131, 201, 196, 55, 35, 212, 226, 89, 62, 96, 133, 126, 182, 65, 107, 223, 227, 31, 27, 94, 43, 151, 197, 168, 57, 234, 10, 153, 245, 26, 29, 231, 120, 46, 157, 113, 58, 92, 145, 227, 85, 162, 217, 56, 144, 104, 89, 211, 146, 52, 119, 136, 213, 224, 103, 20, 101, 51, 17, 166, 228, 136, 207, 22, 152, 200, 92, 217, 32, 41, 120, 147, 119, 189, 81, 131, 58, 194, 65, 82, 97, 235, 113, 196, 93, 30, 166, 188, 174, 254, 212, 151, 74, 205, 228, 67, 227, 215, 215, 93, 31, 71, 226, 175, 67, 129, 89, 248, 74, 78, 131, 219, 111, 80, 82, 29, 127, 97, 165, 251 } });

            migrationBuilder.AddForeignKey(
                name: "FK_VideoEducations_Instructors_InstructorId",
                table: "VideoEducations",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoEducations_Instructors_InstructorId",
                table: "VideoEducations");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "VideoEducations",
                newName: "InstrutorId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoEducations_InstructorId",
                table: "VideoEducations",
                newName: "IX_VideoEducations_InstrutorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "VideoEducations",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 104, 39, 1, 103, 108, 134, 144, 105, 184, 131, 92, 159, 75, 102, 83, 4, 61, 200, 142, 45, 164, 161, 112, 87, 115, 246, 211, 100, 134, 233, 147, 247, 69, 125, 144, 28, 73, 152, 62, 8, 179, 255, 180, 50, 110, 167, 187, 141, 18, 15, 211, 245, 249, 163, 200, 114, 152, 79, 131, 172, 193, 59, 41, 226 }, new byte[] { 228, 209, 180, 119, 52, 164, 117, 121, 143, 127, 62, 56, 149, 108, 133, 206, 238, 30, 233, 164, 87, 174, 212, 127, 78, 95, 199, 67, 202, 175, 71, 49, 82, 55, 213, 178, 158, 116, 95, 202, 248, 214, 146, 211, 95, 61, 28, 46, 30, 120, 125, 18, 115, 188, 63, 236, 43, 187, 118, 46, 142, 22, 131, 171, 48, 83, 83, 64, 54, 137, 216, 211, 197, 238, 217, 63, 160, 229, 253, 118, 161, 235, 134, 157, 74, 231, 11, 109, 43, 148, 65, 68, 16, 142, 100, 208, 113, 39, 185, 222, 201, 190, 236, 192, 7, 143, 234, 172, 11, 251, 79, 103, 89, 120, 83, 125, 80, 249, 123, 1, 89, 137, 187, 0, 162, 67, 107, 238 } });

            migrationBuilder.AddForeignKey(
                name: "FK_VideoEducations_Instructors_InstrutorId",
                table: "VideoEducations",
                column: "InstrutorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
