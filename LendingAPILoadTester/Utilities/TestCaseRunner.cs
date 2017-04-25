using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace LendingAPILoadTester.Utilities
{
    public class TestCaseRunner
    {
        private int Rounds;
        private List<Dictionary<string, string>> TestCaseData { get; set; }
        
        public TestCaseRunner(int rounds, string testname)
        {
            Rounds = rounds;
            getExcelFile(testname);
        }

        public Logger RunTestAsync(Func<SmartClient, Task> function)
        {
            Logger log = new Logger();
            for(int round = 0; round < Rounds; round++)
            {
                var taskList = new List<Task>();
                for(int iterationNumber = 0; iterationNumber < TestCaseData.Count; iterationNumber++)
                {
                    var iterationData = getIterationData(iterationNumber);
                    var client = new SmartClient(log, iterationData);
                    taskList.Add(function(client));
                }
                Task.WaitAll(taskList.ToArray());
            }
            return log;
        }

        private Dictionary<string,string> getIterationData(int i)
        {
            return TestCaseData[i % TestCaseData.Count];
        }

        private void getExcelFile(string testname)
        {
            TestCaseData = new List<Dictionary<string, string>>();

            Application xlApp = new Application();
            //TODO research generalized option correctly
            Workbook xlWorkbook = xlApp.Workbooks.Open(@"c:\users\brian\documents\visual studio 2015\Projects\LendingAPILoadTester\LendingAPILoadTester\Excel\TestData.xlsx");
            _Worksheet xlWorksheet = xlWorkbook.Sheets[testname];
            Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            
            for (int i = 2; i <= rowCount; i++)
            {
                var dict = new Dictionary<string, string>();

                for (int j = 1; j <= colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        dict.Add(xlRange.Cells[1, j].Value2.ToString(), xlRange.Cells[i, j].Value2.ToString());
                }

                TestCaseData.Add(dict);
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
