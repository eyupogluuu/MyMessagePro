using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMessagePro.Migrations
{
    public partial class mig_edit_usernameedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "senderMail",
                table: "UMessages",
                newName: "senderUsername");

            migrationBuilder.RenameColumn(
                name: "receiverMail",
                table: "UMessages",
                newName: "receiverUsername");

            migrationBuilder.RenameColumn(
                name: "friendSenderMail",
                table: "Friendships",
                newName: "friendSenderUsername");

            migrationBuilder.RenameColumn(
                name: "friendReceiverMail",
                table: "Friendships",
                newName: "friendReceiverUsername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "senderUsername",
                table: "UMessages",
                newName: "senderMail");

            migrationBuilder.RenameColumn(
                name: "receiverUsername",
                table: "UMessages",
                newName: "receiverMail");

            migrationBuilder.RenameColumn(
                name: "friendSenderUsername",
                table: "Friendships",
                newName: "friendSenderMail");

            migrationBuilder.RenameColumn(
                name: "friendReceiverUsername",
                table: "Friendships",
                newName: "friendReceiverMail");
        }
    }
}
