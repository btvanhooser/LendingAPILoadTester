using LendingAPILoadTester.UnitTests;
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
