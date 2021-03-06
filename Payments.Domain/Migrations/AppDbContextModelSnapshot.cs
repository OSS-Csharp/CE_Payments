// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payments.Domain;

namespace Payments.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Payments.Model.Entities.ConformationTable", b =>
                {
                    b.Property<int>("ConformationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobListID")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceCheck")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ConformationID");

                    b.HasIndex("JobListID");

                    b.ToTable("ConformationTable");
                });

            modelBuilder.Entity("Payments.Model.Entities.Contract", b =>
                {
                    b.Property<int>("IdContract")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

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
                            IdContract = 10,
                            EndDate = new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IntrestPercentage = "5.0",
                            IsActivated = false,
                            NumberOfPayments = 1,
                            PayersName = "eaaav@gad",
                            PenaltyPErcentage = "7.5",
                            ReciversName = "asdf@gad",
                            StartDate = new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TermsOfPayments = "One Payment"
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

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IdFinalBill");

                    b.HasIndex("PayerId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("StatusId");

                    b.ToTable("FinalBill");

                    b.HasData(
                        new
                        {
                            IdFinalBill = 1,
                            PayerId = 1,
                            ReceiverId = 1,
                            StatusId = 1
                        },
                        new
                        {
                            IdFinalBill = 2,
                            PayerId = 2,
                            ReceiverId = 2,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.JobsList", b =>
                {
                    b.Property<int>("JobListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobsID")
                        .HasColumnType("int");

                    b.Property<bool>("PayerConformation")
                        .HasColumnType("bit");

                    b.Property<bool>("ReciverConformation")
                        .HasColumnType("bit");

                    b.HasKey("JobListID");

                    b.HasIndex("JobsID");

                    b.ToTable("JobsList");

                    b.HasData(
                        new
                        {
                            JobListID = 1,
                            JobsID = 1,
                            PayerConformation = true,
                            ReciverConformation = true
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.JobsTable", b =>
                {
                    b.Property<int>("JobsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("JobsID");

                    b.ToTable("JobsTable");

                    b.HasData(
                        new
                        {
                            JobsID = 1,
                            Description = "Writes code for apps",
                            Name = "Software Developer",
                            Price = 225m
                        },
                        new
                        {
                            JobsID = 2,
                            Description = "Supervises developers",
                            Name = "IT Manager",
                            Price = 550m
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
                            Name = "eaaav@gad"
                        },
                        new
                        {
                            IdPayer = 2,
                            Name = "htthv@gad"
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
                            Name = "asdf@gad"
                        },
                        new
                        {
                            IdReceiver = 2,
                            Name = "zztzf@gad"
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
                            Code = "1950",
                            Description = "This is some very dangerous string error",
                            ShortName = "Some Status"
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
                });

            modelBuilder.Entity("Payments.Model.Entities.ConformationTable", b =>
                {
                    b.HasOne("Payments.Model.Entities.JobsList", "JobList")
                        .WithMany()
                        .HasForeignKey("JobListID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobList");
                });

            modelBuilder.Entity("Payments.Model.Entities.FinalBill", b =>
                {
                    b.HasOne("Payments.Model.Entities.PayersTable", "Payer")
                        .WithMany("FinalBill")
                        .HasForeignKey("PayerId")
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

                    b.Navigation("Receiver");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Payments.Model.Entities.JobsList", b =>
                {
                    b.HasOne("Payments.Model.Entities.JobsTable", "Job")
                        .WithMany()
                        .HasForeignKey("JobsID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Job");
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
