using RestSharp;
using Newtonsoft.Json;
using RestTesting;
using RestSharp.Authenticators;


namespace Program
{
public class Program
{
    private static void Main()
    {
        var url = "https://www.boredapi.com/api/activity/";
        var client = new RestClient(url);
        var request = new RestRequest();
        var response = client.Execute<Activities>(request);

        if (response.IsSuccessful == true)//attempt connection
            {
            var activity = JsonConvert.DeserializeObject<Activities>(response.Content);//deserialize json into c# object 
            Console.WriteLine($"Activity Recomendation:{activity.Activity}");
            Console.WriteLine($"Requires: {activity.Participants} humans");
            }
        else
        {
            Console.WriteLine($"Connnection to server failed Error Code {response.StatusCode}"); 
        }
    }
}

}