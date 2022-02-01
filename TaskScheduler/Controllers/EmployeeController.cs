using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskScheduler.DataAccess;
using TaskScheduler.Model;
using TaskScheduler.Services;

namespace TaskScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeData _data;
        private readonly IEmailSender _sender;

        public EmployeeController(IEmployeeData data, IEmailSender sender)
        {
            _data = data;
            _sender = sender;
        }

        [HttpGet("/employess")]
        public ActionResult<List<EmployeeModel>> GetAllEmployess()
        {
            return Ok(_data.GetEmployeeList());
        }


        [HttpGet("/send-email")]
        public async Task SendEmails()
        {
            string email = "balogunpraise@protonmail.com";
            string emailTitle = "Daily Report of Employees.";
            var body =  _data.GetEmployeeList().ToString();

            try
            {
                var em = new Message(new string[] { email }, emailTitle, body);
                await _sender.SendEmailAsync(em);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
