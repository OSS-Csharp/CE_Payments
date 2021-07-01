using AutoMapper;
using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Model.Models;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.Administration
{
    public class EditStatusPaymentSolutionBase : ComponentBase
    {
        [Inject]
        public IStatusPaymentSolutionService StatusPaymentSolutionService { get; set; }

        public StatusesModel EditStatusModel { get; set; } = new StatusesModel();

        private StatusPaymentSolution StatusPaymentSolution { get; set;  }


        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public bool warning { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {

            int.TryParse(Id, out int idint);
            if(idint !=  0)
            {
                StatusPaymentSolution = await StatusPaymentSolutionService.GetStatus(int.Parse(Id));
            }
            
                Mapper.Map(StatusPaymentSolution, EditStatusModel);
        }
        protected async Task OnSubmit()
        {
            if (StatusPaymentSolution == null)
                StatusPaymentSolution = new StatusPaymentSolution();

            var result = new StatusPaymentSolution();
            Mapper.Map(EditStatusModel, StatusPaymentSolution);
            
            if (StatusPaymentSolution.Id != 0)
            {
                 result = await StatusPaymentSolutionService.UpdateStatus(StatusPaymentSolution);
            }
            else
            {
                result = await StatusPaymentSolutionService.AddStatus(StatusPaymentSolution);
            }
                NavigationManager.NavigateTo("/statuseslist");

        }
        protected async Task Delete_Click()
        {
            await StatusPaymentSolutionService.DeleteStatus(EditStatusModel.IdStatus);
            var a = await StatusPaymentSolutionService.GetStatus(EditStatusModel.IdStatus);
            if(a!=null)
            {
                StatusPaymentSolution = a; 
                warning = true;
                Mapper.Map(EditStatusModel, StatusPaymentSolution);
            }
            else
            {
                NavigationManager.NavigateTo("/statuseslist");
            }

        }
    }
}
