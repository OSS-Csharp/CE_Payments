using Payments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payments.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payments.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=MyDb;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<PayersTable> Payers { get; set; }
        public DbSet<ReceiversTable> Receivers { get; set; }
        public DbSet<FinalBill> FinalBills { get; set; }
        public DbSet<StatusFinalBill> StatusFinalBills { get; set; }
        public DbSet<StatusPaymentSolution> StatusPaymentSolutions { get; set; }
  
        public DbSet<PaymentSolution> PaymentSolutions { get; set; }
        public DbSet<PaymentSchedule> PaymentSchedules { get; set; }
        public DbSet<PaymentInformation> PaymentInformations { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //modelBuilder.Entity<FinalBill>().Property(d => d.IdFinalBill).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            var userPayer1 = new PayersTable { IdPayer = 1, Name = "JhonDee@ce.com" };
            var userPayer3 = new PayersTable { IdPayer = 3, Name = "ErickRosen@ce.com" };
            var userPayer2 = new PayersTable { IdPayer = 2, Name = "ElizabethHarmon@ce.com" };
            modelBuilder.Entity<PayersTable>().HasData(userPayer1, userPayer2, userPayer3);

            var userReceiver1= new ReceiversTable { IdReceiver = 1, Name = "BobbyFischer@ce.com" };
            var userReceiver2 = new ReceiversTable { IdReceiver = 2, Name = "JoseCapablanka@ce.com" };
            var userReceiver3 = new ReceiversTable { IdReceiver = 3, Name = "FrodoBaggins@ce.com" };
            modelBuilder.Entity<ReceiversTable>().HasData(userReceiver1,userReceiver2,userReceiver3);
            

            var s1 = new StatusFinalBill { IdStatus = 1, ShortName = "Active", Description = "This bill is currently active and waiting for completion", Code = "C001" };
            var s2 = new StatusFinalBill { IdStatus = 2, ShortName = "Paid", Description = "This bill ispaid", Code = "C002" };

            modelBuilder.Entity<StatusFinalBill>().HasData(s1);
            var statusPS1 = new StatusPaymentSolution { Id = 1, ShortName = "Active", Description = "Paymet schedule is active and pendint for paymnets", Code = "P001" };
            modelBuilder.Entity<StatusPaymentSolution>().HasData(statusPS1);

            //var paymentInfo1 = new PaymentInformation { IdPaymentInformation = 1, Amount = "1200.00", Description = "One payment for bill" };
            //modelBuilder.Entity<PaymentInformation>().HasData(paymentInfo1);
            //var paymnetSolution = new PaymentSolution { IdPaymentSolution = 1, NumberOfPayments = "1", StatusId = statusPS1.Id, TermsOfPaymnt = "OnePayment" };
            //modelBuilder.Entity<PaymentSolution>().HasData(paymnetSolution);
            //var paymentSch = new PaymentSchedule   {
            //    IdPaymentSchedule = 1, 
            //    FinalAmount = "1200.00",
            //    PaymentSolutionId = paymnetSolution.IdPaymentSolution, 
            //    PaymnetInformationId = paymentInfo1.IdPaymentInformation,
            //    StartOfSchedule= new DateTime(2021, 6, 25),
            //    EntOfSchedule = new DateTime(2021, 6, 30)
            //};
            //modelBuilder.Entity<PaymentSchedule>().HasData(paymentSch);

            var contract1 = new Contract
            {
                IdContract = 5,
                PayersName = "JhonDee@ce.com",
                ReciversName = "BobbyFischer@ce.com",
                TermsOfPayments = "OnePayment",
                NumberOfPayments = 1,
                IntrestPercentage = "5.0",
                PenaltyPErcentage = "7.5",
                StartDate = new DateTime(2021, 6, 25),
                EndDate = new DateTime(2021,6,30),
                IsActivated = false,
                FinalAmount = "1200"

            };
            var contract2 = new Contract
            {
                IdContract = 2,
                PayersName = "JhonDee@ce.com",
                ReciversName = "JoseCapablanka@ce.com",
                TermsOfPayments = "PartialPyments",
                NumberOfPayments = 4,
                IntrestPercentage = "5.0",
                PenaltyPErcentage = "7.5",
                StartDate = new DateTime(2021, 6, 25),
                EndDate = new DateTime(2021, 6, 30),
                IsActivated = false,
                FinalAmount = "12000"

            };
            var contract3 = new Contract
            {
                IdContract = 3,
                PayersName = "JhonDee@ce.com",
                ReciversName = "JoseCapablanka@ce.com",
                TermsOfPayments = "MonthleyPayments",
                NumberOfPayments = 1,
                IntrestPercentage = "5.0",
                PenaltyPErcentage = "7.5",
                StartDate = new DateTime(2021, 6, 25),
                EndDate = new DateTime(2021, 11, 30),
                IsActivated = false,
                FinalAmount = "25000"

            };
            var contract4 = new Contract
            {
                IdContract = 4,
                PayersName = "JhonDee@ce.com",
                ReciversName = "FrodoBaggins@ce.comm",
                TermsOfPayments = "Custom",
                NumberOfPayments = 1,
                IntrestPercentage = "5.0",
                PenaltyPErcentage = "7.5",
                StartDate = new DateTime(2021, 6, 25),
                EndDate = new DateTime(2021, 6, 30),
                IsActivated = false,
                FinalAmount = "19000"

            };
            modelBuilder.Entity<Contract>().HasData(contract1,contract2,contract3,contract4);

            


        }
    }
}
