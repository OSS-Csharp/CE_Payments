using AutoMapper;
using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Model.Models;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.UsersContent
{

    public class CustomContractBase : ComponentBase
    {
        [Inject]
        private IContractService ContractService { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }

        
        [Inject]
        public IPaymentSolutionService PaymentSolutionService { get; set;  }
        [Inject]
        public IPaymentInformationService PaymentInformationService { get; set; }
        [Inject]
        public IPaymentScheduleService PaymentScheduleService { get; set; }
        public CustomPaymentsModel CustomPaymentsModel { get; set; } = new CustomPaymentsModel();

        public double RestAmount { get; set; }
        public PaymentSchedule PaymentSchedule { get; set; }
        private Contract Contract { get; set; }

        public List<PaymentSchedule> CustomPaymentsModelsList { get; set; } 
        protected async override Task OnInitializedAsync()
        {
            CustomPaymentsModelsList = new List<PaymentSchedule>();
            Contract= await ContractService.GetContract(int.Parse(Id));

            PaymentSchedule = new PaymentSchedule { EntOfSchedule = Contract.EndDate, StartOfSchedule = Contract.StartDate };
            CustomPaymentsModel = new CustomPaymentsModel();
            RestAmount = double.Parse(Contract.FinalAmount);
        }
        public  void OnSubmitPayments()
        {
            //Mapper.Map(CustomPaymentsModel, PaymentSchedule);
            var a = new PaymentSchedule();
            a.EntOfSchedule = PaymentSchedule.EntOfSchedule;
            a.StartOfSchedule = PaymentSchedule.StartOfSchedule;
            a.FinalAmount =  this.CustomPaymentsModel.FinalAmount;
            
            this.CustomPaymentsModel = new CustomPaymentsModel();
            RestAmount -= double.Parse(a.FinalAmount);
            if(RestAmount < 0.0)
            {
                a.FinalAmount = (double.Parse(a.FinalAmount) - RestAmount * -1.0).ToString();
                RestAmount = 0.0;
            }
            CustomPaymentsModelsList.Add(a);
        }
        public async void OnClick()
        {
            var solution = await PaymentSolutionService.AddPaymentSolution(new PaymentSolution { NumberOfPayments = Contract.NumberOfPayments.ToString(), TermsOfPaymnt = Contract.TermsOfPayments, StatusId = 1 });

            foreach (var m in CustomPaymentsModelsList)
            {
                var paymentInformation = await PaymentInformationService
                            .AddPaymentInformation(new PaymentInformation
                            {
                                Amount = m.FinalAmount,
                                Description = "Custom Payment"
                            });
                var paymentSchedule = await PaymentScheduleService
                     .AddPaymentSchedule(new PaymentSchedule
                     {
                         PaymentSolutionId = solution.IdPaymentSolution,
                         PaymnetInformationId = paymentInformation.IdPaymentInformation,
                         FinalAmount = m.FinalAmount,
                         StartOfSchedule = Contract.StartDate,
                         EntOfSchedule = Contract.EndDate,

                     });
            }
        }
    }
}
