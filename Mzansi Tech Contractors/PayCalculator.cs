using System;

namespace Mzansi_Tech_Contractors
{
    public class PayResult
    {
        public double GrossPay { get; set; }
        public double UIF { get; set; }
        public double PAYE { get; set; }
        public double MembershipFee { get; set; }
        public double TotalDeductions { get; set; }
        public double NetPay { get; set; }
    }

    public static class PayCalculator
    {
        private const double HourlyRate = 950.00; // R950 per hour
        private const double UIFRate = 0.01;   // 1% of gross pay
        private const double PAYERate = 0.25;   // 25%
        private const double PAYEDependentRate = 0.0575; // 5.75% per dependent rebate
        private const double MembershipRate = 0.13;   // 13% of gross pay

        public static PayResult Calculate(double hours, int dependents)
        {
            // Gross Pay
            double grossPay = hours * HourlyRate;

            // UIF — 1% of gross
            double uif = grossPay * UIFRate;

            // PAYE = (Gross Pay - (Gross Pay × 0.0575 × Dependents)) × 25%
            double taxableIncome = grossPay - (grossPay * PAYEDependentRate * dependents);
            double paye = taxableIncome * PAYERate;

            // Membership Fee — 13% of gross
            double membershipFee = grossPay * MembershipRate;

            // Totals
            double totalDeductions = uif + paye + membershipFee;
            double netPay = grossPay - totalDeductions;

            return new PayResult
            {
                GrossPay = grossPay,
                UIF = uif,
                PAYE = paye,
                MembershipFee = membershipFee,
                TotalDeductions = totalDeductions,
                NetPay = netPay
            };
        }
    }
}