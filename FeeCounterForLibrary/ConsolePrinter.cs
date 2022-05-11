using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeeCounterForLibrary
{
    public class ConsolePrinter
    {
        Dictionary<string, int> bookKinds;
        int printHelper = 120;
        public ConsolePrinter(Dictionary<string, int> bookKinds)
        {
            this.bookKinds = bookKinds;
        }
        /// <summary>
        /// Keeps tidiness of the console. Clears the and ptints lines at the beginning.
        /// </summary>
        public void PrintDecorationBegin()
        {
            Console.Clear();
            for (int j = 0; j < printHelper; j++)
                Console.Write("-");
            Console.Write("\n");
        }
        /// <summary>
        /// Prints line at the end of message.
        /// </summary>
        public void PrintDecorationEnd()
        {

            for (int j = 0; j < printHelper; j++)
                Console.Write("-");
            Console.Write("\n");
        }

        /// <summary>
        /// Shows available kinds of books to the user.
        /// </summary>
        public void PrintOptions()
        {
            PrintDecorationBegin();
            Console.Write("Please pick a book category ");
            for (int i = 0; i < bookKinds.Count; i++)
            {
                if (i == bookKinds.Count - 1)
                    Console.Write($"[{i}] {bookKinds.ElementAt(i).Key}.\n");
                else
                    Console.Write($"[{i}] {bookKinds.ElementAt(i).Key}, ");
            }
            PrintDecorationEnd();
        }

        /// <summary>
        /// Prints request of choosing date.
        /// </summary>
        /// <param name="index">Book number chosen by the user.</param>
        /// <param name="dateKind">Specification of date (borrow/return)</param>
        public void PrintDateRequest(int index, string dateKind)
        {
            PrintDecorationBegin();
            Console.WriteLine($"{bookKinds.ElementAt(index).Key} book was borrowed. Daily penalty is: {bookKinds.ElementAt(index).Value}.");
            Console.WriteLine($"Please write the day, month and year of {dateKind}.");
            PrintDecorationEnd();
        }

        /// <summary>
        /// Prints information about borrower's penalty.
        /// </summary>
        /// <param name="penalty">Counted borrower's penalty</param>
        /// <param name="borrowDate">Date of borrow</param>
        /// <param name="returnDate">Date of return</param>
        /// <param name="index">Book number chosen by the user.</param>
        public void PrintPenalty(int penalty, DateTime borrowDate, DateTime returnDate, int index)
        {
            PrintDecorationBegin();
            Console.WriteLine($"{bookKinds.ElementAt(index).Key} book was borrowed. Daily penalty is: {bookKinds.ElementAt(index).Value}.");
            Console.WriteLine($"The book was borrowed {borrowDate.ToShortDateString()} and returned { returnDate.ToShortDateString()}.");
            if (penalty <= 0)
                Console.WriteLine("Borrower has no fee to pay.");
            else
                Console.WriteLine($"Borrower penalty fee is {penalty} PLN.");

            PrintDecorationEnd();
        }
    }
}
