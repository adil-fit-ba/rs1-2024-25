using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "MyAppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "MyAppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "MyAppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "MyAppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MyAuthenticationTokens",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyAppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAuthenticationTokens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MyAuthenticationTokens_MyAppUsers_MyAppUserId",
                        column: x => x.MyAppUserId,
                        principalTable: "MyAppUsers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyAuthenticationTokens_MyAppUserId",
                table: "MyAuthenticationTokens",
                column: "MyAppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyAuthenticationTokens");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "MyAppUsers");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "MyAppUsers");

            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "MyAppUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "MyAppUsers");
        }
    }
}
