using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.UsersContent
{
    public class PayersBillPageBase : ComponentBase
    {
        [Inject]
        public IFinalBillService FinalBillService { get; set; }

        [Inject]
        public IPaymentSolutionService PaymentSolutionService { get; set; }

        [Inject]
        public IPaymentScheduleService PaymentScheduleService { get; set; }
        [Inject]
        public IPaymentInformationService PaymentInformationService { get; set; }

        public IEnumerable<PaymentSchedule> PaymentSchedules { get; set; }

        [Parameter]
        public string id { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            
            PaymentSchedules = await PaymentScheduleService.GetPaymentSchedulesBySolutionId(int.Parse(id));
            
        }

        public async void PaySchedule(int idshcedule)
        {
            await PaymentScheduleService.IsPaid(idshcedule);
            var tempbool = true;
            PaymentSchedules = await PaymentScheduleService.GetPaymentSchedulesBySolutionId(int.Parse(id));
            if (PaymentSchedules != null)
            {
                foreach (var a in PaymentSchedules)
                {
                    if (a.IsPaid == false)
                    {
                        tempbool = false;
                    }
                    else
                    {
                        tempbool = true;
                    }
                }
            }
            if (tempbool)
            {
                var tempbill = await FinalBillService.GetFinalBillByPaymentSolution(int.Parse(id));
                tempbill.StatusId = 3;
                await FinalBillService.UpdateFinalBill(tempbill);
            }
            NavigationManager.NavigateTo($"/payersbill/{id}",true);

        }

    }
}
