using LendingAPILoadTester.UnitTests;
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
