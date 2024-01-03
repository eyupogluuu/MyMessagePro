using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMessagePro.Migrations
{
    public partial class mig_add_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    friendshipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    friendSenderMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    friendReceiverMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    friendDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.friendshipID);
                });

            migrationBuilder.CreateTable(
                name: "UMessages",
                columns: table => new
                {
                    messageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    content = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    senderMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    draft = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UMessages", x => x.messageID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "UMessages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
