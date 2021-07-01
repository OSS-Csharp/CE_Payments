using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class paymentsolutionedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "PaymentSchedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 1,
                column: "FinalAmount",
                value: "1200");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "PaymentSchedules");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 1,
                column: "FinalAmount",
                value: null);
        }
    }
}
