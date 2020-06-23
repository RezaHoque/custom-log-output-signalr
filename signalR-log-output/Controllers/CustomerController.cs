using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using signalR_log_output.CustomLogger;
using signalR_log_output.Models;

namespace signalR_log_output.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var cust = new Customer();

            try
            {
                var address = cust.Address.Length;
            }catch(Exception ex)
            {
               // 
              // _logger.Log(LogLevel.Error,ex,ex.Message,"Error in the customer page");

                _logger.LogError(ex,"This is my custom error message",null);

            }

          
            return View();
        }
    }
}
