Mzansi Tech Contractors — Payroll Management SystemThe Mzansi Tech Contractors Payroll App is a Windows Forms-based solution designed to automate the calculation of contractor earnings and statutory deductions. This system ensures that payroll processing aligns with South African labor standards and company-specific membership fee structures.

📌 Project OverviewManagement identified a need for improved calculation accuracy and robust input validation. This version of the software addresses those needs by implementing updated financial formulas and comprehensive error-handling guards.

🛠 Business Logic & FormulasThe application utilizes the following constants and logic for all calculations:Hourly Rate: Fixed at R950.00 per hour.
Gross Pay: $Hours \times Hourly Rate$UIF (Unemployment Insurance Fund): 1% of Gross Pay.Membership Fee: 13% of Gross Pay (scaled based on earnings).PAYE (Pay As You Earn): Uses a dependent-reduction formula:$$PAYE = (GP - (GP \times 0.0575 \times Dependents)) \times 25\%$$Net Pay: $Gross - (UIF + PAYE + Membership)$

🧪 Testing Documentation1.
Unit Testing (Core Calculations)Test CaseFormula/InputExpected OutputStatus

Gross Pay40 hrs × R950.00R38,000.00
Pass

UIF (1%)R38,000.00 × 0.01R380.00
Pass

PAYE(R38k - (R38k × 0.0575 × 2)) × 25%R8,407.50
Pass

MembershipR38,000.00 × 13%R4,940.00
Pass

Net PayR38,000 - R13,727.50 (Total Deds)R24,272.50
Pass

2. Integration & System TestingThe system was stress-tested using multiple contractor personas to ensure the logic holds across different income brackets:
Low Earner: John Doe (10 hrs, 0 deps) → Net: R5,795.00
Mid Earner: Jane Smith (30 hrs, 2 deps) → Net: R18,204.38
High Earner: Mike Ndlovu (50 hrs, 3 deps) → Net: R31,023.443. 
Input Validation GuardsTo prevent incorrect data entry, the application includes the following validation popups:Empty Name: "Please enter the contractor's name"
Invalid Hours: "Hours worked must be greater than zero" / "Please enter a valid number"Negative Dependents: "Number of dependents cannot be negative"⚠️ QA Retesting Report (May 14, 2026)
Following the implementation of the new business rules, a retesting cycle was performed.Identified Defects for Future SprintsFinancial Precision (Rounding): The current build uses the double data type. While calculations are correct, floating-point math can lead to R0.01 discrepancies. Fix: Transition to the decimal data type in the next version.
User Experience (Tab Order): The Reset button initially failed to return focus to the first field. 
Fix: Updated btnReset_Click to include txtName.Focus().
Regression AnalysisStatus: STABLEKey Findings: The transition from a flat membership fee (R50) to a percentage-based fee (13%) was successful. The PAYE dependent-reduction logic is functioning as intended.

🚀 How to UseLaunch the application.
Enter the Contractor Name.Enter the Hours Worked and Number of Dependents.Click Calculate Net Pay to view the breakdown.Use the Reset button to clear all fields and start a new entry.
