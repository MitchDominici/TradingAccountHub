using Microsoft.EntityFrameworkCore.Migrations;

namespace AlpacaAccountHub.Data.Migrations
{
    public partial class AccountApiKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiKey",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    API_KEY = table.Column<string>(nullable: true),
                    API_SECRET = table.Column<string>(nullable: true),
                    paper_API_KEY = table.Column<string>(nullable: true),
                    paper_API_SECRET = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKey", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKey");
        }
    }
}
