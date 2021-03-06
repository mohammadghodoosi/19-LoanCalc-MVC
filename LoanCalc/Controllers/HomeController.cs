using LoanCalc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoanCalc.Helper;

namespace LoanCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoanCal()
        {
            Loan loan = new();
            loan.Payment = 0.0m;
            loan.TotalInterst = 0.0m;
            loan.TotalCost = 0.0m;
            loan.Term = 60;
            loan.Rate = 3.5m;
            loan.Amount = 150000m;
            return View(loan);
        }

        public IActionResult LoanCal(Loan loan)
        {
            var loanHelper = new LoanHelper();
            Loan newLoan = loanHelper.GetPayments(loan);
            return View(newLoan);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
