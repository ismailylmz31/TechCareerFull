using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechCareer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class allof : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 11, 10, 23, 618, DateTimeKind.Utc).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 11, 10, 23, 620, DateTimeKind.Utc).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 12, 4, 11, 10, 23, 620, DateTimeKind.Utc).AddTicks(757), new byte[] { 140, 30, 3, 35, 165, 63, 242, 66, 60, 158, 173, 227, 224, 180, 46, 55, 239, 240, 26, 241, 195, 254, 142, 22, 232, 28, 79, 222, 150, 188, 198, 61, 164, 179, 133, 135, 21, 140, 149, 77, 231, 212, 233, 200, 248, 106, 48, 20, 18, 43, 15, 61, 74, 211, 155, 176, 167, 161, 177, 3, 233, 14, 17, 170 }, new byte[] { 146, 255, 15, 226, 72, 33, 67, 18, 203, 58, 127, 227, 104, 127, 55, 58, 246, 253, 44, 213, 128, 87, 98, 195, 64, 56, 50, 215, 176, 245, 84, 46, 89, 234, 251, 179, 113, 208, 40, 132, 4, 129, 205, 188, 92, 136, 251, 94, 174, 251, 71, 96, 68, 50, 240, 224, 92, 237, 185, 211, 250, 119, 205, 77, 181, 108, 55, 54, 12, 211, 145, 189, 4, 152, 82, 181, 115, 138, 164, 145, 98, 148, 165, 221, 124, 103, 7, 155, 150, 98, 152, 20, 238, 120, 177, 121, 33, 101, 28, 232, 32, 146, 212, 91, 56, 193, 100, 195, 91, 74, 57, 89, 144, 129, 195, 210, 33, 82, 249, 244, 236, 198, 164, 107, 207, 155, 188, 194 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
