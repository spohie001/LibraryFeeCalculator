
using System.Collections.Generic;

namespace FeeCounterForLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Place to declare all kinds of books in the library.
            //If new type is needed write it here with its daily fee
            Dictionary<string, int> bookKinds = new Dictionary<string, int>()
            {
                { "IT", 5 },
                { "History", 3 },
                { "Classics", 2 },
                { "Law", 2 },
                { "Medical", 2 },
                { "Philosophy", 2 }
            };
            LibraryController controller = new LibraryController(bookKinds);
            controller.HandleInput();
        }
    }
}
