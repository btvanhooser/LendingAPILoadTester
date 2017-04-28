using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Newtonsoft.Json;
using LendingAPILoadTester.Utilities;
using LendingAPILoadTester.Properties;

namespace LendingAPILoadTester
{
    public enum Commands
    {
        GetLenders = 0,
        GetCurrentLender,
        Authorizing,
        GetApplicationByCode,
        GetApplicationByLastName,
        GetApplicationByFullName,
        SubmitApplication,
        SaveApplication,
        DeleteApplication
    }

    public class SmartClient
    {
        private RestClient client;
        private string uri;
        private Logger logger;
        public Dictionary<string, string> DataContext;

        public SmartClient(Logger log, Dictionary<string,string> iteration)
        {
            //TODO Replace uri's
            //dev
            //uri = "http://small-scale-lending-api-btvanhooser.c9users.io:8080";
            //prod
            uri = "https://simple-lending-api.herokuapp.com";

            DataContext = iteration;
            logger = log;
            client = new RestClient(uri);
        }

        public async Task<Response> Login()
        {
            return await SendAsync(Commands.Authorizing);
        }

        public async Task<Response> SendAsync(Commands command)
        {
            var request = new RestRequest();
            switch (command)
            {
                case Commands.Authorizing:
                    request.Resource = "auth";
                    request.Method = Method.POST;
                    request.AddHeader("content-type", "application/json");
                    request.AddParameter("application/json", 
                        ReplaceVariables(Resources.auth), 
                        ParameterType.RequestBody);
                    break;
                case Commands.DeleteApplication:
                    request.Resource = "application/{id}";
                    request.AddParameter("id", DataContext["id"], ParameterType.UrlSegment);
                    request.Method = Method.DELETE;
                    break;
                case Commands.GetApplicationByCode:
                    request.Resource = "applications/{code}";
                    request.AddParameter("code", DataContext["Lendercode"], ParameterType.UrlSegment);
                    request.Method = Method.GET;
                    break;
                case Commands.GetApplicationByFullName:
                    request.Resource = "applications/{code}/{lastname}/{firstname}";
                    request.AddParameter("code", DataContext["Lendercode"], ParameterType.UrlSegment);
                    request.AddParameter("lastname", DataContext["Lastname"], ParameterType.UrlSegment);
                    request.AddParameter("firstname", DataContext["Firstname"], ParameterType.UrlSegment);
                    request.Method = Method.GET;
                    break;
                case Commands.GetApplicationByLastName:
                    request.Resource = "applications/{code}/{lastname}";
                    request.AddParameter("code", DataContext["Lendercode"], ParameterType.UrlSegment);
                    request.AddParameter("lastname", DataContext["Lastname"], ParameterType.UrlSegment);
                    request.Method = Method.GET;
                    break;
                case Commands.GetCurrentLender:
                    request.Resource = "lender";
                    request.Method = Method.GET;
                    break;
                case Commands.GetLenders:
                    request.Resource = "lenders";
                    request.Method = Method.GET;
                    break;
                case Commands.SaveApplication:
                    request.Resource = "application";
                    request.Method = Method.PUT;
                    request.AddHeader("content-type", "application/json");
                    request.AddParameter("application/json", 
                        ReplaceVariables(Resources.SaveApplication), 
                        ParameterType.RequestBody);
                    break;
                case Commands.SubmitApplication:
                    request.Resource = "application";
                    request.Method = Method.POST;
                    request.AddHeader("content-type", "application/json");
                    request.AddParameter("application/json", 
                        ReplaceVariables(Resources.SubmitApplication), 
                        ParameterType.RequestBody);
                    break;
            }

            Stopwatch time = new Stopwatch();
            time.Start();
            var response = await client.ExecuteTaskAsync(request);
            time.Stop();
            var errorFound = false;
            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Created)
                errorFound = true;

            logger.UpdateStatistics(command.ToString(), time.ElapsedMilliseconds * 1.0 / 1000, errorFound);

            var responseObject = JsonConvert.DeserializeObject<Response>(response.Content);

            if (command == Commands.Authorizing)
            {
                client.AddDefaultHeader("authorization","JWT " + responseObject.access_token);
            }

            return responseObject;
        }

        private string ReplaceVariables(string template)
        {
            foreach(var key in DataContext.Keys)
            {
                template = Regex.Replace(template,"{{" + key + "}}", DataContext[key]);
            }

            return template;
        }
    }
}
