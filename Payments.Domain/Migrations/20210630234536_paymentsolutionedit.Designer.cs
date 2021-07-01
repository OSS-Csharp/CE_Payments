﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payments.Domain;

namespace Payments.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210630234536_paymentsolutionedit")]
    partial class paymentsolutionedit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Payments.Model.Entities.Contract", b =>
                {
                    b.Property<int>("IdContract")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FinalAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntrestPercentage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfPayments")
                        .HasColumnType("int");

                    b.Property<string>("PayersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PenaltyPErcentage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReciversName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TermsOfPayments")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContract");

                    b.ToTable("Contracts");

                    b.HasData(
                        new
                        {
                            IdContract = 1,
                            EndDate = new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinalAmount = "1200",
                            IntrestPercentage = "5.0",
                            IsActivated = false,
                            NumberOfPayments = 1,
                            PayersName = "JhonDee@ce.com",
                            PenaltyPErcentage = "7.5",
                            ReciversName = "BobbyFischer@ce.com",
                            StartDate = new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TermsOfPayments = "OnePayment"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.FinalBill", b =>
                {
                    b.Property<int>("IdFinalBill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PayerId")
                        .HasColumnType("int");

                    b.Property<int>("PaymnetSolutionId")
                        .HasColumnType("int");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IdFinalBill");

                    b.HasIndex("PayerId");

                    b.HasIndex("PaymnetSolutionId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("StatusId");

                    b.ToTable("FinalBill");

                    b.HasData(
                        new
                        {
                            IdFinalBill = 1,
                            PayerId = 1,
                            PaymnetSolutionId = 1,
                            ReceiverId = 1,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.PayersTable", b =>
                {
                    b.Property<int>("IdPayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPayer");

                    b.ToTable("PayersTable");

                    b.HasData(
                        new
                        {
                            IdPayer = 1,
                            Name = "JhonDee@ce.com"
                        },
                        new
                        {
                            IdPayer = 2,
                            Name = "ElizabethHarmon@ce.com"
                        },
                        new
                        {
                            IdPayer = 3,
                            Name = "ErickRosen@ce.com"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.PaymentInformation", b =>
                {
                    b.Property<int>("IdPaymentInformation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPaymentInformation");

                    b.ToTable("PaymentInformations");

                    b.HasData(
                        new
                        {
                            IdPaymentInformation = 1,
                            Amount = "1200.00",
                            Description = "One payment for bill"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.PaymentSchedule", b =>
                {
                    b.Property<int>("IdPaymentSchedule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EntOfSchedule")
                        .HasColumnType("datetime2");

                    b.Property<string>("FinalAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentSolutionId")
                        .HasColumnType("int");

                    b.Property<int>("PaymnetInformationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartOfSchedule")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPaymentSchedule");

                    b.HasIndex("PaymentSolutionId");

                    b.HasIndex("PaymnetInformationId");

                    b.ToTable("PaymentSchedules");

                    b.HasData(
                        new
                        {
                            IdPaymentSchedule = 1,
                            EntOfSchedule = new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinalAmount = "1200.00",
                            IsPaid = false,
                            PaymentSolutionId = 1,
                            PaymnetInformationId = 1,
                            StartOfSchedule = new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.PaymentSolution", b =>
                {
                    b.Property<int>("IdPaymentSolution")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumberOfPayments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TermsOfPaymnt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPaymentSolution");

                    b.HasIndex("StatusId");

                    b.ToTable("PaymentSolutions");

                    b.HasData(
                        new
                        {
                            IdPaymentSolution = 1,
                            NumberOfPayments = "1",
                            StatusId = 1,
                            TermsOfPaymnt = "OnePayment"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.ReceiversTable", b =>
                {
                    b.Property<int>("IdReceiver")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdReceiver");

                    b.ToTable("ReceiversTable");

                    b.HasData(
                        new
                        {
                            IdReceiver = 1,
                            Name = "BobbyFischer@ce.com"
                        },
                        new
                        {
                            IdReceiver = 2,
                            Name = "JoseCapablanka@ce.com"
                        },
                        new
                        {
                            IdReceiver = 3,
                            Name = "FrodoBaggins@ce.com"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.StatusFinalBill", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStatus");

                    b.ToTable("StatusFinalBill");

                    b.HasData(
                        new
                        {
                            IdStatus = 1,
                            Code = "C001",
                            Description = "This bill is currently active and waiting for completion",
                            ShortName = "Active"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.StatusPaymentSolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusPaymentSolution");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "P001",
                            Description = "Paymet schedule is active and pendint for paymnets",
                            ShortName = "Active"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.FinalBill", b =>
                {
                    b.HasOne("Payments.Model.Entities.PayersTable", "Payer")
                        .WithMany("FinalBill")
                        .HasForeignKey("PayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Payments.Model.Entities.PaymentSolution", "PaymentSolution")
                        .WithMany("FinalBill")
                        .HasForeignKey("PaymnetSolutionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Payments.Model.Entities.ReceiversTable", "Receiver")
                        .WithMany("FinalBill")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Payments.Model.Entities.StatusFinalBill", "Status")
                        .WithMany("FinalBill")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Payer");

                    b.Navigation("PaymentSolution");

                    b.Navigation("Receiver");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Payments.Model.Entities.PaymentSchedule", b =>
                {
                    b.HasOne("Payments.Model.Entities.PaymentSolution", "PaymentSolution")
                        .WithMany("PaymentSchedule")
                        .HasForeignKey("PaymentSolutionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Payments.Model.Entities.PaymentInformation", "PaymentInformation")
                        .WithMany("PaymentSchedule")
                        .HasForeignKey("PaymnetInformationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PaymentInformation");

                    b.Navigation("PaymentSolution");
                });

            modelBuilder.Entity("Payments.Model.Entities.PaymentSolution", b =>
                {
                    b.HasOne("Payments.Model.Entities.StatusPaymentSolution", "Status")
                        .WithMany("PaymentSolutions")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Payments.Model.Entities.PayersTable", b =>
                {
                    b.Navigation("FinalBill");
                });

            modelBuilder.Entity("Payments.Model.Entities.PaymentInformation", b =>
                {
                    b.Navigation("PaymentSchedule");
                });

            modelBuilder.Entity("Payments.Model.Entities.PaymentSolution", b =>
                {
                    b.Navigation("FinalBill");

                    b.Navigation("PaymentSchedule");
                });

            modelBuilder.Entity("Payments.Model.Entities.ReceiversTable", b =>
                {
                    b.Navigation("FinalBill");
                });

            modelBuilder.Entity("Payments.Model.Entities.StatusFinalBill", b =>
                {
                    b.Navigation("FinalBill");
                });

            modelBuilder.Entity("Payments.Model.Entities.StatusPaymentSolution", b =>
                {
                    b.Navigation("PaymentSolutions");
                });
#pragma warning restore 612, 618
        }
    }
}