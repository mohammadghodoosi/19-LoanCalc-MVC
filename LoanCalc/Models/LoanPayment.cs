using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalc.Models
{
    public class LoanPayment
    {
        //the number of month
        public int Month { get; set; }

        //the payment that was payed
        public decimal Payment { get; set; }


        public decimal MonthlyPrincipal { get; set; }
        public decimal MonthlyInterest { get; set; }
        public decimal TotalIntrest { get; set; }

        //whats left
        public decimal Ballance { get; set; }
    }
}
