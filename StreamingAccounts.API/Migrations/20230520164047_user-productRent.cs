using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingAccounts.API.Migrations
{
    /// <inheritdoc />
    public partial class userproductRent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductRents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ProductRents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRents_UserId1",
                table: "ProductRents",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRents_AspNetUsers_UserId1",
                table: "ProductRents",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRents_AspNetUsers_UserId1",
                table: "ProductRents");

            migrationBuilder.DropIndex(
                name: "IX_ProductRents_UserId1",
                table: "ProductRents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductRents");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ProductRents");
        }
    }
}
