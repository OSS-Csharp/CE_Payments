using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class finalbill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    IdContract = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReciversName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsOfPayments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPayments = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntrestPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PenaltyPErcentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    FinalAmount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.IdContract);
                });

            migrationBuilder.CreateTable(
                name: "PayersTable",
                columns: table => new
                {
                    IdPayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayersTable", x => x.IdPayer);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInformations",
                columns: table => new
                {
                    IdPaymentInformation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInformations", x => x.IdPaymentInformation);
                });

            migrationBuilder.CreateTable(
                name: "ReceiversTable",
                columns: table => new
                {
                    IdReceiver = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiversTable", x => x.IdReceiver);
                });

            migrationBuilder.CreateTable(
                name: "StatusFinalBill",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusFinalBill", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "StatusPaymentSolution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPaymentSolution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSolutions",
                columns: table => new
                {
                    IdPaymentSolution = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermsOfPaymnt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    NumberOfPayments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSolutions", x => x.IdPaymentSolution);
                    table.ForeignKey(
                        name: "FK_PaymentSolutions_StatusPaymentSolution_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusPaymentSolution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinalBill",
                columns: table => new
                {
                    IdFinalBill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayerId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PaymnetSolutionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalBill", x => x.IdFinalBill);
                    table.ForeignKey(
                        name: "FK_FinalBill_PayersTable_PayerId",
                        column: x => x.PayerId,
                        principalTable: "PayersTable",
                        principalColumn: "IdPayer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalBill_PaymentSolutions_PaymnetSolutionId",
                        column: x => x.PaymnetSolutionId,
                        principalTable: "PaymentSolutions",
                        principalColumn: "IdPaymentSolution",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalBill_ReceiversTable_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "ReceiversTable",
                        principalColumn: "IdReceiver",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalBill_StatusFinalBill_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusFinalBill",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSchedules",
                columns: table => new
                {
                    IdPaymentSchedule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentSolutionId = table.Column<int>(type: "int", nullable: false),
                    PaymnetInformationId = table.Column<int>(type: "int", nullable: false),
                    StartOfSchedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntOfSchedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalAmount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSchedules", x => x.IdPaymentSchedule);
                    table.ForeignKey(
                        name: "FK_PaymentSchedules_PaymentInformations_PaymnetInformationId",
                        column: x => x.PaymnetInformationId,
                        principalTable: "PaymentInformations",
                        principalColumn: "IdPaymentInformation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentSchedules_PaymentSolutions_PaymentSolutionId",
                        column: x => x.PaymentSolutionId,
                        principalTable: "PaymentSolutions",
                        principalColumn: "IdPaymentSolution",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "IdContract", "EndDate", "FinalAmount", "IntrestPercentage", "IsActivated", "NumberOfPayments", "PayersName", "PenaltyPErcentage", "ReciversName", "StartDate", "TermsOfPayments" },
                values: new object[] { 1, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "5.0", false, 1, "JhonDee@ce.com", "7.5", "BobbyFischer@ce.com", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "OnePayment" });

            migrationBuilder.InsertData(
                table: "PayersTable",
                columns: new[] { "IdPayer", "Name" },
                values: new object[,]
                {
                    { 1, "JhonDee@ce.com" },
                    { 2, "ElizabethHarmon@ce.com" },
                    { 3, "ErickRosen@ce.com" }
                });

            migrationBuilder.InsertData(
                table: "PaymentInformations",
                columns: new[] { "IdPaymentInformation", "Amount", "Description" },
                values: new object[] { 1, "1200.00", "One payment for bill" });

            migrationBuilder.InsertData(
                table: "ReceiversTable",
                columns: new[] { "IdReceiver", "Name" },
                values: new object[,]
                {
                    { 1, "BobbyFischer@ce.com" },
                    { 2, "JoseCapablanka@ce.com" },
                    { 3, "FrodoBaggins@ce.com" }
                });

            migrationBuilder.InsertData(
                table: "StatusFinalBill",
                columns: new[] { "IdStatus", "Code", "Description", "ShortName" },
                values: new object[] { 1, "C001", "This bill is currently active and waiting for completion", "Active" });

            migrationBuilder.InsertData(
                table: "StatusPaymentSolution",
                columns: new[] { "Id", "Code", "Description", "ShortName" },
                values: new object[] { 1, "P001", "Paymet schedule is active and pendint for paymnets", "Active" });

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
                columns: new[] { "IdPaymentSchedule", "EntOfSchedule", "FinalAmount", "PaymentSolutionId", "PaymnetInformationId", "StartOfSchedule" },
                values: new object[] { 1, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1200.00", 1, 1, new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_PayerId",
                table: "FinalBill",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_PaymnetSolutionId",
                table: "FinalBill",
                column: "PaymnetSolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_ReceiverId",
                table: "FinalBill",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_StatusId",
                table: "FinalBill",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSchedules_PaymentSolutionId",
                table: "PaymentSchedules",
                column: "PaymentSolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSchedules_PaymnetInformationId",
                table: "PaymentSchedules",
                column: "PaymnetInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSolutions_StatusId",
                table: "PaymentSolutions",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "FinalBill");

            migrationBuilder.DropTable(
                name: "PaymentSchedules");

            migrationBuilder.DropTable(
                name: "PayersTable");

            migrationBuilder.DropTable(
                name: "ReceiversTable");

            migrationBuilder.DropTable(
                name: "StatusFinalBill");

            migrationBuilder.DropTable(
                name: "PaymentInformations");

            migrationBuilder.DropTable(
                name: "PaymentSolutions");

            migrationBuilder.DropTable(
                name: "StatusPaymentSolution");
        }
    }
}
