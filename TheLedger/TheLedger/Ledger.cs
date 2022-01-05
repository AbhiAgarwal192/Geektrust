using System.Collections.Generic;
using TheLedger.Entities;

namespace TheLedger
{
    public class Ledger
    {
        private List<Bank> _banks;
        public Ledger()
        {
            _banks = new List<Bank>();
        }

        public void Process(string[] input)
        {
            if (input[0].Equals(Commands.LOAN))
            {
                string bank_name = input[1];
                string borrower_name = input[2];
                int principal_amount = int.Parse(input[3]);
                int loan_period_in_years = int.Parse(input[4]);
                int interest_rate = int.Parse(input[5]);

                var borrower = new Borrower
                {
                    Name = borrower_name,
                    LoanAmount = principal_amount,
                    LoanPeriod = loan_period_in_years,
                    Interest = interest_rate
                };

                var bank = FindBank(bank_name);

                bank.ProcessLoan();
            }
            else if (input[0].Equals(Commands.PAYMENT))
            {

            }
            else //Balance
            {

            }
        }

        private Bank FindBank(string bank_name)
        {
            Bank bank = new Bank(bank_name);
            if (this._banks.Count == 0)
            {
                this._banks.Add(bank);
            }
            else
            {
                foreach (var bk in this._banks)
                {
                    if (bk.Name.Equals(bank_name))
                    {
                        bank = bk;
                        break;
                    }
                }
            }
            return bank;
        }

    }
}
