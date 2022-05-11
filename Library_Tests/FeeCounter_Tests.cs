using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FeeCounterForLibrary;
namespace Library_Tests
{
    [TestClass]
    public class FeeCounterTests
    {
        /// <summary>
        /// Tests if method correctly counts penalty when borrower 
        /// is not late with returning borrowed book
        /// </summary>
        [TestMethod]
        public void CountFee_WhenReturnedTheNextDay_FeeEqualsZero()
        {
            int dailyFee = 1;
            FeeCounter feeCounter = new FeeCounter();
            feeCounter.BorrowDate = DateTime.Today;
            feeCounter.ReturnDate = DateTime.Today.AddDays(1);

            int fee = feeCounter.CountFee(dailyFee);

            Assert.AreEqual(0, fee);
        }

        /// <summary>
        /// Tests if method correctly counts penalty when borrower 
        /// is late with returning borrowed book
        /// </summary>
        [TestMethod]
        public void CountFee_WhenReturnedAfterTwoDays_CountedFee()
        {
            int dailyFee = 1;
            FeeCounter feeCounter = new FeeCounter();
            feeCounter.BorrowDate = DateTime.Today;
            feeCounter.ReturnDate = DateTime.Today.AddDays(2);

            int fee = feeCounter.CountFee(dailyFee);

            Assert.AreEqual(dailyFee, fee);
        }
    }
}
