using System;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.DataAccess;

namespace TaskScheduler.Services
{

    public class CronJobsService : ICronJobsServices
        {
            private readonly IEmployeeData _emp;
            private readonly IEmailSender _sender;
            public CronJobsService(IEmployeeData emp, IEmailSender sender)
            {
                _emp = emp;
                _sender = sender;
            }
            public async Task SendEmails()
            {
                string email = "mcvictory4real@yahoo.co.uk";
                string emailTitle = "Daily Report of Employees.";
            var body = _emp.GetEmployeeList();
            var x = new StringBuilder();
            foreach(var i in body)
            {
                x.Append($"{i.Id}...{i.FirstName}...{i.LastName}....{i.Salary}||");
            }
            //var stringBuilder = new StringBuilder();
            //foreach(var i in x.ToString())
            //{
                //stringBuilder.Append($"...{i}" );
            //}
            //var body = stringBuilder;

                try
                {
                    var em = new Message(new string[] { email }, emailTitle, x.ToString());
                    await _sender.SendEmailAsync(em);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }
    } 


