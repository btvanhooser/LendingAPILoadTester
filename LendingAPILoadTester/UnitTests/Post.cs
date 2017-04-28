using LendingAPILoadTester.Utilities;
using System.Threading.Tasks;

namespace LendingAPILoadTester.UnitTests
{
    public static class Post
    {
        public static async Task<Response> NewApplication(SmartClient client)
        {
            return await client.SendAsync(Commands.SubmitApplication);
        }
    }
}
