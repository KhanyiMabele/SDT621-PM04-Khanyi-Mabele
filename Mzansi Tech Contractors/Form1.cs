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
            // Input Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the contractor's name.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

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

            //  all calculations handled by PayCalculator
            PayResult result = PayCalculator.Calculate(hours, dependents);

            // Display results
            txtGrossPay.Text = result.GrossPay.ToString("F2");
            txtUIF.Text = result.UIF.ToString("F2");
            txtPAYE.Text = result.PAYE.ToString("F2");
            txtMembership.Text = result.MembershipFee.ToString("F2");
            txtTotalDeduction.Text = result.TotalDeductions.ToString("F2");
            txtNetPay.Text = result.NetPay.ToString("F2");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
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