using Mzansi_Tech_Contractors;

[TestFixture]
public class PayCalculatorTests
{
  
    // 1. GROSS PAY
    

    [Test]
    [Description("WB-GP-01: Standard 40-hour week → gross = 40 × 950 = 38 000")]
    public void GrossPay_StandardWeek_IsCorrect()
    {
        var result = PayCalculator.Calculate(40, 0);
        TestContext.Out.WriteLine("Testing Gross Pay for standard 40-hour week.");
        TestContext.Out.WriteLine($"Hours: 40 | Rate: R950.00");
        TestContext.Out.WriteLine($"Calculated Gross Pay: R{result.GrossPay:F2}");
        Assert.That(result.GrossPay, Is.EqualTo(38_000.00).Within(0.001));
    }

    [Test]
    [Description("WB-GP-02: Single hour → gross = 950")]
    public void GrossPay_SingleHour_IsCorrect()
    {
        var result = PayCalculator.Calculate(1, 0);
        TestContext.Out.WriteLine("Testing Gross Pay for a single hour.");
        TestContext.Out.WriteLine($"Hours: 1 | Rate: R950.00");
        TestContext.Out.WriteLine($"Calculated Gross Pay: R{result.GrossPay:F2}");
        Assert.That(result.GrossPay, Is.EqualTo(950.00).Within(0.001));
    }

    [Test]
    [Description("WB-GP-03: Fractional hours (7.5 h) → gross = 7125")]
    public void GrossPay_FractionalHours_IsCorrect()
    {
        var result = PayCalculator.Calculate(7.5, 0);
        TestContext.Out.WriteLine("Testing Gross Pay for fractional hours (7.5 h).");
        TestContext.Out.WriteLine($"Hours: 7.5 | Rate: R950.00");
        TestContext.Out.WriteLine($"Calculated Gross Pay: R{result.GrossPay:F2}");
        Assert.That(result.GrossPay, Is.EqualTo(7_125.00).Within(0.001));
    }

    // 2. UIF
   

    [Test]
    [Description("WB-UIF-01: UIF = 1% of gross pay")]
    public void UIF_Is1PercentOfGross()
    {
        var result = PayCalculator.Calculate(40, 0);
        TestContext.Out.WriteLine("Testing UIF deduction (1% of Gross Pay).");
        TestContext.Out.WriteLine($"Gross Pay: R{result.GrossPay:F2}");
        TestContext.Out.WriteLine($"Calculated UIF: R{result.UIF:F2}");
        Assert.That(result.UIF, Is.EqualTo(result.GrossPay * 0.01).Within(0.001));
    }

    [Test]
    [Description("WB-UIF-02: UIF is independent of dependents count")]
    public void UIF_IsUnaffectedByDependents()
    {
        var r0 = PayCalculator.Calculate(40, 0);
        var r3 = PayCalculator.Calculate(40, 3);
        TestContext.Out.WriteLine("Testing UIF is not affected by number of dependents.");
        TestContext.Out.WriteLine($"UIF (0 dependents): R{r0.UIF:F2}");
        TestContext.Out.WriteLine($"UIF (3 dependents): R{r3.UIF:F2}");
        Assert.That(r0.UIF, Is.EqualTo(r3.UIF).Within(0.001));
    }

    // 3. PAYE
    

    [Test]
    [Description("WB-PAYE-01: Zero dependents → taxable income equals gross pay")]
    public void PAYE_ZeroDependents_TaxableIncomeEqualsGross()
    {
        var result = PayCalculator.Calculate(40, 0);
        TestContext.Out.WriteLine("Testing PAYE with zero dependents.");
        TestContext.Out.WriteLine($"Gross Pay: R{result.GrossPay:F2}");
        TestContext.Out.WriteLine($"Calculated PAYE: R{result.PAYE:F2}");
        Assert.That(result.PAYE, Is.EqualTo(result.GrossPay * 0.25).Within(0.001));
    }

    [Test]
    [Description("WB-PAYE-02: One dependent reduces taxable income by 5.75%")]
    public void PAYE_OneDependent_ReducesTaxCorrectly()
    {
        var result = PayCalculator.Calculate(40, 1);
        double gross = 40 * 950;
        double taxable = gross - (gross * 0.0575 * 1);
        double expected = taxable * 0.25;
        TestContext.Out.WriteLine("Testing PAYE reduction with 1 dependent.");
        TestContext.Out.WriteLine($"Gross Pay: R{gross:F2}");
        TestContext.Out.WriteLine($"Taxable Income after dependent relief: R{taxable:F2}");
        TestContext.Out.WriteLine($"Calculated PAYE: R{result.PAYE:F2}");
        Assert.That(result.PAYE, Is.EqualTo(expected).Within(0.001));
    }

    [Test]
    [Description("WB-PAYE-03: Three dependents → larger tax reduction")]
    public void PAYE_ThreeDependents_ReducesTaxCorrectly()
    {
        var result = PayCalculator.Calculate(40, 3);
        double gross = 40 * 950;
        double taxable = gross - (gross * 0.0575 * 3);
        double expected = taxable * 0.25;
        TestContext.Out.WriteLine("Testing PAYE reduction with 3 dependents.");
        TestContext.Out.WriteLine($"Gross Pay: R{gross:F2}");
        TestContext.Out.WriteLine($"Taxable Income after dependent relief: R{taxable:F2}");
        TestContext.Out.WriteLine($"Calculated PAYE: R{result.PAYE:F2}");
        Assert.That(result.PAYE, Is.EqualTo(expected).Within(0.001));
    }

    [Test]
    [Description("WB-PAYE-04: More dependents always lowers PAYE")]
    public void PAYE_MoreDependents_LowersTax()
    {
        var r0 = PayCalculator.Calculate(40, 0);
        var r2 = PayCalculator.Calculate(40, 2);
        TestContext.Out.WriteLine("Testing that more dependents lowers PAYE.");
        TestContext.Out.WriteLine($"PAYE (0 dependents): R{r0.PAYE:F2}");
        TestContext.Out.WriteLine($"PAYE (2 dependents): R{r2.PAYE:F2}");
        Assert.That(r2.PAYE, Is.LessThan(r0.PAYE));
    }

    // 4. MEMBERSHIP FEE

    [Test]
    [Description("WB-MEM-01: Membership fee = 13% of gross pay")]
    public void MembershipFee_Is13PercentOfGross()
    {
        var result = PayCalculator.Calculate(40, 0);
        TestContext.Out.WriteLine("Testing Membership Fee (13% of Gross Pay).");
        TestContext.Out.WriteLine($"Gross Pay: R{result.GrossPay:F2}");
        TestContext.Out.WriteLine($"Calculated Membership Fee: R{result.MembershipFee:F2}");
        Assert.That(result.MembershipFee, Is.EqualTo(result.GrossPay * 0.13).Within(0.001));
    }

    [Test]
    [Description("WB-MEM-02: Membership fee is independent of dependents")]
    public void MembershipFee_IsUnaffectedByDependents()
    {
        var r0 = PayCalculator.Calculate(40, 0);
        var r5 = PayCalculator.Calculate(40, 5);
        TestContext.Out.WriteLine("Testing Membership Fee is not affected by dependents.");
        TestContext.Out.WriteLine($"Membership Fee (0 dependents): R{r0.MembershipFee:F2}");
        TestContext.Out.WriteLine($"Membership Fee (5 dependents): R{r5.MembershipFee:F2}");
        Assert.That(r0.MembershipFee, Is.EqualTo(r5.MembershipFee).Within(0.001));
    }

    // 5. TOTAL DEDUCTIONS
    

    [Test]
    [Description("WB-TD-01: Total deductions = UIF + PAYE + Membership Fee")]
    public void TotalDeductions_EqualsSumOfComponents()
    {
        var r = PayCalculator.Calculate(40, 2);
        TestContext.Out.WriteLine("Testing Total Deductions = UIF + PAYE + Membership Fee.");
        TestContext.Out.WriteLine($"UIF: R{r.UIF:F2}");
        TestContext.Out.WriteLine($"PAYE: R{r.PAYE:F2}");
        TestContext.Out.WriteLine($"Membership Fee: R{r.MembershipFee:F2}");
        TestContext.Out.WriteLine($"Total Deductions: R{r.TotalDeductions:F2}");
        Assert.That(r.TotalDeductions, Is.EqualTo(r.UIF + r.PAYE + r.MembershipFee).Within(0.001));
    }

    // 6. NET PAY

    [Test]
    [Description("WB-NP-01: Net pay = gross pay − total deductions")]
    public void NetPay_IsGrossMinusTotalDeductions()
    {
        var r = PayCalculator.Calculate(40, 0);
        TestContext.Out.WriteLine("Testing Net Pay = Gross Pay - Total Deductions.");
        TestContext.Out.WriteLine($"Gross Pay: R{r.GrossPay:F2}");
        TestContext.Out.WriteLine($"Total Deductions: R{r.TotalDeductions:F2}");
        TestContext.Out.WriteLine($"Calculated Net Pay: R{r.NetPay:F2}");
        Assert.That(r.NetPay, Is.EqualTo(r.GrossPay - r.TotalDeductions).Within(0.001));
    }

    [Test]
    [Description("WB-NP-02: Net pay is positive for typical input")]
    public void NetPay_IsPositive_ForTypicalInput()
    {
        var r = PayCalculator.Calculate(40, 0);
        TestContext.Out.WriteLine("Testing Net Pay is a positive value.");
        TestContext.Out.WriteLine($"Calculated Net Pay: R{r.NetPay:F2}");
        Assert.That(r.NetPay, Is.GreaterThan(0));
    }

    [Test]
    [Description("WB-NP-03: More dependents → higher net pay")]
    public void NetPay_IncreasesWithMoreDependents()
    {
        var r0 = PayCalculator.Calculate(40, 0);
        var r3 = PayCalculator.Calculate(40, 3);
        TestContext.Out.WriteLine("Testing Net Pay increases with more dependents.");
        TestContext.Out.WriteLine($"Net Pay (0 dependents): R{r0.NetPay:F2}");
        TestContext.Out.WriteLine($"Net Pay (3 dependents): R{r3.NetPay:F2}");
        Assert.That(r3.NetPay, Is.GreaterThan(r0.NetPay));
    }

    // 7. BOUNDARY / EDGE CASES

    [Test]
    [Description("WB-BC-01: Minimum valid hours produces near-zero pay")]
    public void Calculate_MinimumHours_ProducesVerySmallPay()
    {
        var r = PayCalculator.Calculate(0.01, 0);
        TestContext.Out.WriteLine("Testing boundary: minimum valid hours (0.01 h).");
        TestContext.Out.WriteLine($"Calculated Gross Pay: R{r.GrossPay:F2}");
        Assert.That(r.GrossPay, Is.EqualTo(0.01 * 950).Within(0.001));
    }

    [Test]
    [Description("WB-BC-02: Large hours (200 h) scale linearly")]
    public void Calculate_LargeHours_ScalesLinearly()
    {
        var r40 = PayCalculator.Calculate(40, 0);
        var r200 = PayCalculator.Calculate(200, 0);
        TestContext.Out.WriteLine("Testing boundary: large hours scale linearly.");
        TestContext.Out.WriteLine($"Gross Pay (40 h):  R{r40.GrossPay:F2}");
        TestContext.Out.WriteLine($"Gross Pay (200 h): R{r200.GrossPay:F2}");
        Assert.That(r200.GrossPay, Is.EqualTo(r40.GrossPay * 5).Within(0.001));
    }

    [Test]
    [Description("WB-BC-03: Zero dependents is a valid boundary value")]
    public void Calculate_ZeroDependents_IsValid()
    {
        TestContext.Out.WriteLine("Testing boundary: zero dependents does not throw.");
        Assert.That(() => PayCalculator.Calculate(40, 0), Throws.Nothing);
        TestContext.Out.WriteLine("Passed — no exception thrown.");
    }

    [Test]
    [Description("WB-BC-04: Large dependent count (10) does not throw")]
    public void Calculate_LargeDependents_DoesNotThrow()
    {
        TestContext.Out.WriteLine("Testing boundary: 10 dependents does not throw.");
        Assert.That(() => PayCalculator.Calculate(40, 10), Throws.Nothing);
        TestContext.Out.WriteLine("Passed — no exception thrown.");
    }

    // 8. END-TO-END KNOWN-VALUE TEST

    [Test]
    [Description("WB-E2E-01: Full calculation with 40 h and 2 dependents")]
    public void Calculate_40Hours_2Dependents_AllValuesCorrect()
    {
        double hours = 40;
        int dependents = 2;
        double gross = 40 * 950;
        double uif = gross * 0.01;
        double taxable = gross - (gross * 0.0575 * dependents);
        double paye = taxable * 0.25;
        double membership = gross * 0.13;
        double total = uif + paye + membership;
        double net = gross - total;

        var r = PayCalculator.Calculate(hours, dependents);

        TestContext.Out.WriteLine("Testing full end-to-end calculation with all deductions.");
        TestContext.Out.WriteLine($"Gross Pay: R{r.GrossPay:F2}");
        TestContext.Out.WriteLine($"UIF: R{r.UIF:F2}");
        TestContext.Out.WriteLine($"PAYE: R{r.PAYE:F2}");
        TestContext.Out.WriteLine($"Membership Fee: R{r.MembershipFee:F2}");
        TestContext.Out.WriteLine($"Total Deductions: R{r.TotalDeductions:F2}");
        TestContext.Out.WriteLine($"Calculated Net Pay: R{r.NetPay:F2}");

        Assert.Multiple(() =>
        {
            Assert.That(r.GrossPay, Is.EqualTo(gross).Within(0.001), "GrossPay");
            Assert.That(r.UIF, Is.EqualTo(uif).Within(0.001), "UIF");
            Assert.That(r.PAYE, Is.EqualTo(paye).Within(0.001), "PAYE");
            Assert.That(r.MembershipFee, Is.EqualTo(membership).Within(0.001), "MembershipFee");
            Assert.That(r.TotalDeductions, Is.EqualTo(total).Within(0.001), "TotalDeductions");
            Assert.That(r.NetPay, Is.EqualTo(net).Within(0.001), "NetPay");
        });
    }
}