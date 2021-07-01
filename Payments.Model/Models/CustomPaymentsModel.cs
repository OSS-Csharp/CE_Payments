using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Model.Models
{
    public class CustomPaymentsModel
    {
        public int IdPaymentSchedule { get; set; }

        public int PaymentSolutionId { get; set; }

        //public virtual PaymentSolution PaymentSolution { get; set; }

        public int PaymnetInformationId { get; set; }
       
        //public PaymentInformation PaymentInformation { get; set; }

        public DateTime StartOfSchedule { get; set; }

        public DateTime EntOfSchedule { get; set; }

        public string FinalAmount { get; set; }
    }
}
