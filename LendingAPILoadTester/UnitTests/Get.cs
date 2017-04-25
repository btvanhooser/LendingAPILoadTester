using LendingAPILoadTester.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPILoadTester.UnitTests
{
    public static class Get
    {
        public static async Task<Response> ApplicationByLendercode(SmartClient client)
        {
            return await client.SendAsync(Commands.GetApplicationByCode);
        }

        public static async Task<Response> ApplicationByFullName(SmartClient client)
        {
            return await client.SendAsync(Commands.GetApplicationByFullName);
        }

        public static async Task<Response> ApplicationByLastName(SmartClient client)
        {
            return await client.SendAsync(Commands.GetApplicationByLastName);
        }

        public static async Task<Response> AllLenders(SmartClient client)
        {
            return await client.SendAsync(Commands.GetLenders);
        }

        public static async Task<Response> CurrentLender(SmartClient client)
        {
            return await client.SendAsync(Commands.GetCurrentLender);
        }
    }
}
