using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeeCounterForLibrary
{
    public class LibraryController
    {
        FeeCounter feeCounter = new FeeCounter();
        Dictionary<string, int> bookKinds;
        ConsolePrinter consolePrint;
        public LibraryController(Dictionary<string, int> bookKinds)
        {
            this.bookKinds = bookKinds;
            this.consolePrint = new ConsolePrinter(bookKinds);
        }
        /// <summary>
        /// The main logic of the whole program. Interacts with the user asking for data and processes it.
        /// </summary>
        public void HandleInput()
        {
            int index = -1;
            bool isParsable = false;
            DateTime borrowDate = new DateTime();
            DateTime returnDate = new DateTime();

            while (!(0 <= index && index < bookKinds.Count && isParsable))
            {
                consolePrint.PrintOptions();
                isParsable = Int32.TryParse((string)Console.ReadLine(), out index);
            }

            isParsable = false;
            while (!isParsable)
            {
                consolePrint.PrintDateRequest(index, "borrow");
                isParsable = DateTime.TryParse((string)Console.ReadLine(), out borrowDate);
            }

            isParsable = false;
            while (!(isParsable && returnDate >= borrowDate))
            {
                consolePrint.PrintDateRequest(index, "return");
                isParsable = DateTime.TryParse((string)Console.ReadLine(), out returnDate);
            }

            feeCounter.BorrowDate = borrowDate;
            feeCounter.ReturnDate = returnDate;
            consolePrint.PrintPenalty(feeCounter.CountFee(bookKinds.ElementAt(index).Value), borrowDate, returnDate, index);

        }
    }
}
