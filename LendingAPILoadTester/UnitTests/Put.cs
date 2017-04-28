using LendingAPILoadTester.Utilities;
using System.Threading.Tasks;

namespace LendingAPILoadTester.UnitTests
{
    public static class Put
    {
        public static async Task<Response> Application(SmartClient client)
        {
            return await client.SendAsync(Commands.SaveApplication);
        }
    }
}
