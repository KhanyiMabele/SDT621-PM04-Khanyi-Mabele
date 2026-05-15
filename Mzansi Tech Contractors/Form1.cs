using System;
using System.Windows.Forms;

namespace Mzansi_Tech_Contractors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //  Input Validation 
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the contractor's name.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // 2. Hours worked must be a valid positive number
            if (!double.TryParse(txtHours.Text, out double hours))
            {
                MessageBox.Show("Please enter a valid number for hours worked.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHours.Focus();
                return;
            }

            if (hours <= 0)
            {
                MessageBox.Show("Hours worked must be greater than zero.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHours.Focus();
                return;
            }

            // 3. Dependents must be a valid non-negative integer
            if (!int.TryParse(txtDependents.Text, out int dependents))
            {
                MessageBox.Show("Please enter a valid whole number for dependents.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDependents.Focus();
                return;
            }

            if (dependents < 0)
            {
                MessageBox.Show("Number of dependents cannot be negative.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDependents.Focus();
                return;
            }

            //  Calculations 

            const double ratePerHour = 950.00;

            double grossPay = hours * ratePerHour;

            const double uifRate = 0.01;
            double uif = grossPay * uifRate;

            double taxableIncome = grossPay - (grossPay * 0.0575 * dependents);
            double paye = taxableIncome * 0.25;

            const double membershipFeeRate = 0.13;
            double membershipFee = grossPay * membershipFeeRate;

            // Net Pay = Gross Pay − UIF − PAYE − Membership Fee
            double totalDeductions = uif + paye + membershipFee;
            double netPay = grossPay - totalDeductions;


            txtGrossPay.Text = grossPay.ToString("F2");
            txtPAYE.Text = paye.ToString("F2");
            txtUIF.Text = uif.ToString("F2");
            txtMembership.Text = membershipFee.ToString("F2");
            txtTotalDeduction.Text = totalDeductions.ToString("F2");
            txtNetPay.Text = netPay.ToString("F2");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Clear all text boxes
            txtName.Clear();
            txtHours.Clear();
            txtDependents.Clear();
            txtGrossPay.Clear();
            txtPAYE.Clear();
            txtUIF.Clear();
            txtMembership.Clear();
            txtTotalDeduction.Clear();
            txtNetPay.Clear();

            txtName.Focus(); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}