using System;
using System.Collections.Generic;
using System.Text;

namespace FeeCounterForLibrary
{
    public class FeeCounter
    {
        DateTime borrowDate;
        DateTime returnDate;

        public DateTime BorrowDate
        {
            set
            {
                this.borrowDate = value;
            }
        }
        public DateTime ReturnDate
        {
            set
            {
                this.returnDate = value;
            }
        }
        public FeeCounter() { }

        /// <summary>
        /// Counts borrower's penalty
        /// </summary>
        /// <param name="dailyFee">A sum that the borrower needs to pay for each day of being late</param>
        /// <returns></returns>
        public int CountFee(int dailyFee)
        {
            return (((int)(returnDate - borrowDate).TotalDays) - 1) * dailyFee;
        }
    }
}
