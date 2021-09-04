using LoanCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalc.Helper
{
    public class LoanHelper
    {
        public Loan GetPayments(Loan loan)
        {
            //calculate monthly payment
            loan.Payment = CalculatePayment(loan.Amount, loan.Rate, loan.Term);
            //loop through 1 to Term
            var balance = loan.Amount;
            var totalInterest = 0.0m;
            var monthlyInterest = 0.0m;
            var monthlyPrincipal = 0.0m;
            var monthlyRate = CalcMonthly(loan.Rate);
            for (int month = 0; month <= loan.Rate ; month++)
            {
                monthlyInterest = CalcMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                monthlyPrincipal = loan.Payment - monthlyInterest;
                balance -= monthlyPrincipal;

                //calculate a payment schedule
                LoanPayment loanPayment = new();
                loanPayment.Month = month;
                loanPayment.Payment = loan.Payment;
                loanPayment.MonthlyPrincipal = monthlyPrincipal;
                loanPayment.MonthlyInterest = monthlyInterest;
                loanPayment.TotalIntrest = totalInterest;
                loanPayment.Ballance = balance;

                //push the object into the loan model
                loan.Payments.Add(loanPayment);
            }

            //push payments in the loan
            loan.TotalInterst = totalInterest;
            loan.TotalCost = loan.Amount + totalInterest;


            //return the loan to the view
            return loan;
        }
        private decimal CalculatePayment(decimal amount, decimal rate, int term)
        {
            decimal payment = 0.0m;
            rate = CalcMonthly(rate);
            var rateD = Convert.ToDouble(rate);
            var amountD = Convert.ToDouble(amount);
            var paymentD = (amountD * rateD) / (1 - Math.Pow(1 + rateD, -term));
            return payment;
        }

        //rate is yearly and we want it monthly
        private decimal CalcMonthly(decimal rate)
        {
            return rate / 1200;
        }
        private decimal CalcMonthlyInterest(decimal balance, decimal monthlyRate)
        {
            return balance * monthlyRate;
        }
    }
}
