using LendingAPILoadTester.UnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPILoadTester.Helpers
{
    public static class SmartClientHelper
    {
        public static async Task OpenClient(SmartClient client)
        {
            await client.Login();
            await Get.CurrentLender(client);
            await Get.ApplicationByLendercode(client);
        }
    }
}
