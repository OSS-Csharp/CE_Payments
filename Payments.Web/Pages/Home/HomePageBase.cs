using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Payments.Model.Entities;
using Payments.Web.Services.Interfaces;
using Stripe.Issuing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.Home
{
    public class HomePageBase : ComponentBase
    {

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }
        [Inject]
        private IContractService ContractService { get; set; }
        [Inject]
        private IPayersTableService PayersTableService { get; set; }
        [Inject]
        private IReceiversTableService ReceiversTableService { get; set; }
        [Inject]
        private IPaymentInformationService PaymentInformationService { get; set; }
        [Inject]
        private IPaymentSolutionService PaymentSolutionService { get; set; }
        [Inject]
        private IPaymentScheduleService PaymentScheduleService { get; set; }
        [Inject]
        private IFinalBillService FinalBillService { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }

        public IEnumerable<FinalBill> FinalBills { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        private IAuthorizationService AuthorizationService { get; set; }
        public int idHolderContract { get; set; }

        protected override async Task OnInitializedAsync()
        {


            var authstat = (await AuthenticationStateTask);

            if (authstat.User.Identity.IsAuthenticated)
            {
                if (authstat.User.IsInRole("admin"))
                {
                    //somemessagefor admin
                }
                else
                {
                    try
                    {
                        var checkpayers = (await PayersTableService.GetPayerByName(authstat.User.Identity.Name));
                        Contracts = (await ContractService.GetContractsByPayer(authstat.User.Identity.Name)).ToList();
                         FinalBills = (await FinalBillService.GetAllByPayer(checkpayers.IdPayer)).ToList();
                        if (checkpayers != null)
                        {
                            Contracts = (await ContractService.GetContractsByPayer(authstat.User.Identity.Name)).ToList();
                        }
                    }
                    catch { }
                    
                }
            }
        }
        public async void ActivateContract(int id)
        {
            var cntr = (await ContractService.GetContract(id));
            if (cntr != null)
            {
                if (cntr.TermsOfPayments == "Custom")
                {
                    NavigationManager.NavigateTo("activirajpoID/}");
                }
                FinalBill finalBill = new FinalBill();
                StatusFinalBill a = new StatusFinalBill();
                var paymentSolution = new PaymentSolution();
                PaymentInformation paymentInformation = new PaymentInformation();

                var payer = await PayersTableService.GetPayerByName(cntr.PayersName);
                var reciver = await ReceiversTableService.GetReceiverByName(cntr.ReciversName);

                finalBill.PayerId = payer.IdPayer;
                finalBill.ReceiverId = reciver.IdReceiver;
                finalBill.StatusId = 2;
                paymentSolution = await PaymentSolutionService.AddPaymentSolution(new PaymentSolution { NumberOfPayments = cntr.NumberOfPayments.ToString(), TermsOfPaymnt = cntr.TermsOfPayments, StatusId = 1 });
                finalBill.PaymnetSolutionId = paymentSolution.IdPaymentSolution;

                await FinalBillService.AddFinalBill(finalBill);


                PaymentSchedule paymentSchedule = new PaymentSchedule();
                if (cntr.TermsOfPayments == "Custom")
                {
                    NavigationManager.NavigateTo($"/custompayments/{cntr.IdContract}");
                }
                if (cntr.TermsOfPayments == "OnePayment")
                {
                    paymentInformation = await PaymentInformationService
                        .AddPaymentInformation(new PaymentInformation { Amount = cntr.FinalAmount, Description = "Onepayment" });
                    paymentSchedule = await PaymentScheduleService
                         .AddPaymentSchedule(new PaymentSchedule
                         {
                             PaymentSolutionId = paymentSolution.IdPaymentSolution,
                             PaymnetInformationId = paymentInformation.IdPaymentInformation,
                             FinalAmount = cntr.FinalAmount,
                             StartOfSchedule = cntr.StartDate,
                             EntOfSchedule = cntr.EndDate,
                             IsPaid = false

                         });
                }
                if (cntr.TermsOfPayments == "PartialPyments")
                {
                    int amt = int.Parse(cntr.FinalAmount);
                    for (int i = 0; i < cntr.NumberOfPayments; i++)
                    {
                        paymentInformation = await PaymentInformationService
                            .AddPaymentInformation(new PaymentInformation
                            {
                                Amount = Math.Round((Double)(amt / cntr.NumberOfPayments), 2).ToString(),
                                Description = "Partial Payment"
                            });
                        paymentSchedule = await PaymentScheduleService
                             .AddPaymentSchedule(new PaymentSchedule
                             {
                                 PaymentSolutionId = paymentSolution.IdPaymentSolution,
                                 PaymnetInformationId = paymentInformation.IdPaymentInformation,
                                 FinalAmount = Math.Round((Double)(amt / cntr.NumberOfPayments), 2).ToString(),
                                 StartOfSchedule = cntr.StartDate,
                                 EntOfSchedule = cntr.EndDate,

                             });
                    }
                }
                if (cntr.TermsOfPayments == "MonthleyPayments")
                {
                    var cnt = cntr.EndDate.Month - cntr.StartDate.Month;
                    var temdate = cntr.StartDate;

                    for (int i = 0; i < cnt; i++)
                    {

                        paymentInformation = await PaymentInformationService
                            .AddPaymentInformation(new PaymentInformation
                            {
                                Amount = Math.Round((Double)(int.Parse(cntr.FinalAmount) / cnt), 2).ToString(),
                                Description = "Monthly Payment"
                            });
                        paymentSchedule = await PaymentScheduleService
                             .AddPaymentSchedule(new PaymentSchedule
                             {
                                 PaymentSolutionId = paymentSolution.IdPaymentSolution,
                                 PaymnetInformationId = paymentInformation.IdPaymentInformation,
                                 FinalAmount = Math.Round((Double)(int.Parse(cntr.FinalAmount) / cntr.NumberOfPayments), 2).ToString(),
                                 StartOfSchedule = temdate,
                                 EntOfSchedule = temdate.AddMonths(1)

                             });
                        temdate = temdate.AddMonths(1);
                    }

                }
                cntr.IsActivated = true;
                var abc = await ContractService.UpdateContractActivation(cntr);
                NavigationManager.NavigateTo("/homepage", true);
            }
        }
    }

}
