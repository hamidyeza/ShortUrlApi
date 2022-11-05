using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortUrlApi.DataModel.Migrations
{
    public partial class InitializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortUrls",
                columns: table => new
                {
                    ShortUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrginalUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortenerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedUrlCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUrls", x => x.ShortUrlId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUrls");
        }
    }
}
