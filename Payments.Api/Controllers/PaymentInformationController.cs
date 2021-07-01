    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Domain.Repository.Interfaces;
using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentInformationController : Controller
    {

        private readonly IPaymentInformationRepository _PaymentInformationRepository;

        public PaymentInformationController(IPaymentInformationRepository receiverlRepository)
        {
            this._PaymentInformationRepository = receiverlRepository;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentInformation>>> GetPaymentInformations()
        {
            try
            {
                return (await _PaymentInformationRepository.GetPaymentInformations()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<PaymentInformation>> GetPaymentInformation(int id)
        {
            try
            {
                return (await _PaymentInformationRepository.GetPaymentInformation(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        [Route("{info}")]
        public async Task<ActionResult<PaymentInformation>> UpdatePaymentInformation( PaymentInformation info)
        {
            try
            {
                if (info == null)
                    return BadRequest();

                var userToUpdate = await _PaymentInformationRepository.GetPaymentInformation(info.IdPaymentInformation);
                if (userToUpdate == null)
                    return NotFound($"No user with Id= {info.IdPaymentInformation}");
               
                return await _PaymentInformationRepository.UpdatePaymentInformation(info);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating infrotab");
            }
        }
        [HttpPost]
        [Route("{info}")]
        public async Task<ActionResult<PaymentInformation>> AddPaymentInformation(PaymentInformation info)
        {
            try
            {
                if (info == null)
                    return BadRequest();

                var createinfo = await _PaymentInformationRepository.AddPaymentInformation(info);
                return CreatedAtAction(nameof(GetPaymentInformation), new { id = createinfo.IdPaymentInformation }, createinfo);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new info record");
            }

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<PaymentInformation>> DeletePaymentInformation(int id)
        {
            try
            {
                var userToDelete = await _PaymentInformationRepository.GetPaymentInformation(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await _PaymentInformationRepository.DeletePaymentInformation(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error deleteing info record");
            }
        }
    }
}