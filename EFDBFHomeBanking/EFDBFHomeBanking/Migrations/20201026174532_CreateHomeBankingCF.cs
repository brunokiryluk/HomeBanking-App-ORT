using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDBFHomeBanking.Migrations
{
    public partial class CreateHomeBankingCF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    bankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks", x => x.bankId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    clientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    nroDoc = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    bankId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.clientId);
                    table.ForeignKey(
                        name: "FK_users_banks_bankId",
                        column: x => x.bankId,
                        principalTable: "banks",
                        principalColumn: "bankId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    accountId = table.Column<string>(nullable: false),
                    direccion = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    balance = table.Column<float>(nullable: false),
                    clientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.accountId);
                    table.ForeignKey(
                        name: "FK_accounts_users_clientId",
                        column: x => x.clientId,
                        principalTable: "users",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_clientId",
                table: "accounts",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_users_bankId",
                table: "users",
                column: "bankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "banks");
        }
    }
}
