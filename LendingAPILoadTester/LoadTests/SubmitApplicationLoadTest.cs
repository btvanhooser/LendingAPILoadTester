using Microsoft.VisualStudio.TestTools.UnitTesting;
using LendingAPILoadTester.Utilities;
using LendingAPILoadTester.Helpers;
using System;

namespace LendingAPILoadTester
{
    [TestClass]
    public class SubmitApplicationLoadTest
    {
        [TestMethod]
        public void SubmitApplication()
        {
            var tc = new TestCaseRunner(1, "SubmitApplication");
            var log = tc.RunTestAsync(SubmitApplicationHelper.SubmitApplicationProcess);
            Console.WriteLine(log.ToString());
        }
    }
}
