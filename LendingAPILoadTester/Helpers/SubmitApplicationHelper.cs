using LendingAPILoadTester.UnitTests;
using LendingAPILoadTester.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPILoadTester.Helpers
{
    public static class SubmitApplicationHelper
    {
        public static async Task SubmitApplicationProcess(SmartClient client)
        {
            await SmartClientHelper.OpenClient(client);
            await Post.NewApplication(client);
        }
    }
}
