using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FinalBill",
                keyColumn: "IdFinalBill",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentSchedules",
                keyColumn: "IdPaymentSchedule",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentInformations",
                keyColumn: "IdPaymentInformation",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentSolutions",
                keyColumn: "IdPaymentSolution",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "IdContract", "EndDate", "FinalAmount", "IntrestPercentage", "IsActivated", "NumberOfPayments", "PayersName", "PenaltyPErcentage", "ReciversName", "StartDate", "TermsOfPayments" },
                values: new object[] { 2, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "12000", "5.0", false, 4, "JhonDee@ce.com", "7.5", "JoseCapablanka@ce.com", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "PartialPyments" });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "IdContract", "EndDate", "FinalAmount", "IntrestPercentage", "IsActivated", "NumberOfPayments", "PayersName", "PenaltyPErcentage", "ReciversName", "StartDate", "TermsOfPayments" },
                values: new object[] { 3, new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "25000", "5.0", false, 1, "JhonDee@ce.com", "7.5", "JoseCapablanka@ce.com", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "MonthleyPayments" });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "IdContract", "EndDate", "FinalAmount", "IntrestPercentage", "IsActivated", "NumberOfPayments", "PayersName", "PenaltyPErcentage", "ReciversName", "StartDate", "TermsOfPayments" },
                values: new object[] { 4, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "19000", "5.0", false, 1, "JhonDee@ce.com", "7.5", "FrodoBaggins@ce.comm", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Custom" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "PaymentInformations",
                columns: new[] { "IdPaymentInformation", "Amount", "Description" },
                values: new object[] { 1, "1200.00", "One payment for bill" });

            migrationBuilder.InsertData(
                table: "PaymentSolutions",
                columns: new[] { "IdPaymentSolution", "NumberOfPayments", "StatusId", "TermsOfPaymnt" },
                values: new object[] { 1, "1", 1, "OnePayment" });

            migrationBuilder.InsertData(
                table: "FinalBill",
                columns: new[] { "IdFinalBill", "PayerId", "PaymnetSolutionId", "ReceiverId", "StatusId" },
                values: new object[] { 1, 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "PaymentSchedules",
                columns: new[] { "IdPaymentSchedule", "EntOfSchedule", "FinalAmount", "IsPaid", "PaymentSolutionId", "PaymnetInformationId", "StartOfSchedule" },
                values: new object[] { 1, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1200.00", false, 1, 1, new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
