namespace Mzansi_Tech_Contractors
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            btnCalculate = new Button();
            btnReset = new Button();
            btnExit = new Button();
            txtName = new TextBox();
            txtHours = new TextBox();
            txtDependents = new TextBox();
            txtGrossPay = new TextBox();
            txtPAYE = new TextBox();
            txtUIF = new TextBox();
            txtMembership = new TextBox();
            txtTotalDeduction = new TextBox();
            txtNetPay = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(91, 25);
            label1.Name = "label1";
            label1.Size = new Size(446, 50);
            label1.TabIndex = 0;
            label1.Text = "Mzansi Tech Contractors";
            // 
            // label2
            // 
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 159);
            label2.Name = "label2";
            label2.Size = new Size(146, 23);
            label2.TabIndex = 21;
            label2.Text = "Contractor's Name";
            // 
            // label3
            // 
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 205);
            label3.Name = "label3";
            label3.Size = new Size(162, 23);
            label3.TabIndex = 20;
            label3.Text = "Hours worked";
            // 
            // label4
            // 
            label4.ForeColor = Color.White;
            label4.Location = new Point(22, 249);
            label4.Name = "label4";
            label4.Size = new Size(172, 23);
            label4.TabIndex = 19;
            label4.Text = "Number of Dependents";
            // 
            // label5
            // 
            label5.ForeColor = Color.White;
            label5.Location = new Point(438, 163);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 18;
            label5.Text = "Gross Pay";
            // 
            // label6
            // 
            label6.ForeColor = Color.White;
            label6.Location = new Point(438, 202);
            label6.Name = "label6";
            label6.Size = new Size(166, 23);
            label6.TabIndex = 17;
            label6.Text = "PAYE Deduction";
            // 
            // label7
            // 
            label7.ForeColor = Color.White;
            label7.Location = new Point(438, 245);
            label7.Name = "label7";
            label7.Size = new Size(166, 23);
            label7.TabIndex = 16;
            label7.Text = "UIF Deduction";
            // 
            // label8
            // 
            label8.ForeColor = Color.White;
            label8.Location = new Point(438, 287);
            label8.Name = "label8";
            label8.Size = new Size(150, 23);
            label8.TabIndex = 15;
            label8.Text = "Membership Fee";
            // 
            // label9
            // 
            label9.ForeColor = Color.White;
            label9.Location = new Point(438, 325);
            label9.Name = "label9";
            label9.Size = new Size(150, 23);
            label9.TabIndex = 14;
            label9.Text = "Total Deductions";
            // 
            // label10
            // 
            label10.ForeColor = Color.White;
            label10.Location = new Point(438, 371);
            label10.Name = "label10";
            label10.Size = new Size(73, 23);
            label10.TabIndex = 13;
            label10.Text = "Net Pay";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(38, 318);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(160, 29);
            btnCalculate.TabIndex = 10;
            btnCalculate.Text = "Calculate Net Pay";
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(204, 318);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 11;
            btnReset.Text = "Reset";
            btnReset.Click += btnReset_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(304, 318);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 12;
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(190, 159);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 27);
            txtName.TabIndex = 8;
            // 
            // txtHours
            // 
            txtHours.Location = new Point(190, 202);
            txtHours.Name = "txtHours";
            txtHours.Size = new Size(100, 27);
            txtHours.TabIndex = 7;
            // 
            // txtDependents
            // 
            txtDependents.Location = new Point(190, 242);
            txtDependents.Name = "txtDependents";
            txtDependents.Size = new Size(100, 27);
            txtDependents.TabIndex = 6;
            // 
            // txtGrossPay
            // 
            txtGrossPay.Location = new Point(570, 163);
            txtGrossPay.Name = "txtGrossPay";
            txtGrossPay.ReadOnly = true;
            txtGrossPay.Size = new Size(100, 27);
            txtGrossPay.TabIndex = 5;
            // 
            // txtPAYE
            // 
            txtPAYE.Location = new Point(570, 199);
            txtPAYE.Name = "txtPAYE";
            txtPAYE.ReadOnly = true;
            txtPAYE.Size = new Size(100, 27);
            txtPAYE.TabIndex = 4;
            // 
            // txtUIF
            // 
            txtUIF.Location = new Point(570, 241);
            txtUIF.Name = "txtUIF";
            txtUIF.ReadOnly = true;
            txtUIF.Size = new Size(100, 27);
            txtUIF.TabIndex = 3;
            // 
            // txtMembership
            // 
            txtMembership.Location = new Point(570, 283);
            txtMembership.Name = "txtMembership";
            txtMembership.ReadOnly = true;
            txtMembership.Size = new Size(100, 27);
            txtMembership.TabIndex = 2;
            // 
            // txtTotalDeduction
            // 
            txtTotalDeduction.Location = new Point(570, 325);
            txtTotalDeduction.Name = "txtTotalDeduction";
            txtTotalDeduction.ReadOnly = true;
            txtTotalDeduction.Size = new Size(100, 27);
            txtTotalDeduction.TabIndex = 1;
            // 
            // txtNetPay
            // 
            txtNetPay.Location = new Point(570, 367);
            txtNetPay.Name = "txtNetPay";
            txtNetPay.ReadOnly = true;
            txtNetPay.Size = new Size(100, 27);
            txtNetPay.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(txtNetPay);
            Controls.Add(txtTotalDeduction);
            Controls.Add(txtMembership);
            Controls.Add(txtUIF);
            Controls.Add(txtPAYE);
            Controls.Add(txtGrossPay);
            Controls.Add(txtDependents);
            Controls.Add(txtHours);
            Controls.Add(txtName);
            Controls.Add(btnExit);
            Controls.Add(btnReset);
            Controls.Add(btnCalculate);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Mzansi Tech Pay System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnCalculate;
        private Button btnReset;
        private Button btnExit;
        private TextBox txtName;
        private TextBox txtHours;
        private TextBox txtDependents;
        private TextBox txtGrossPay;
        private TextBox txtPAYE;
        private TextBox txtUIF;
        private TextBox txtMembership;
        private TextBox txtTotalDeduction;
        private TextBox txtNetPay;
    }
}