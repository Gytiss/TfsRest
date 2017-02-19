using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public static async void GetProjects()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                     .AddJsonFile("project.json");

                var configuration = builder.Build();
                var setting = configuration["userSecretsId"];

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", setting))));

                    using (HttpResponseMessage response = client.GetAsync(
                                "https://autotest1.VisualStudio.com/DefaultCollection/_apis/projects?api-version=2.0").Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                        Console.ReadLine();
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
