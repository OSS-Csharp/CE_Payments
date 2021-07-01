using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "IdContract", "EndDate", "FinalAmount", "IntrestPercentage", "IsActivated", "NumberOfPayments", "PayersName", "PenaltyPErcentage", "ReciversName", "StartDate", "TermsOfPayments" },
                values: new object[] { 5, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1200", "5.0", false, 1, "JhonDee@ce.com", "7.5", "BobbyFischer@ce.com", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "OnePayment" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "IdContract", "EndDate", "FinalAmount", "IntrestPercentage", "IsActivated", "NumberOfPayments", "PayersName", "PenaltyPErcentage", "ReciversName", "StartDate", "TermsOfPayments" },
                values: new object[] { 1, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1200", "5.0", false, 1, "JhonDee@ce.com", "7.5", "BobbyFischer@ce.com", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "OnePayment" });
        }
    }
}
