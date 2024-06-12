using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using RestSharp;
using RestTesting.Models;

namespace RestTesting;

public class UpdateComment
{

    public static void UpdateCommentRequest(RestClient client, int? Id)
    {
        Console.WriteLine("Updating Comment.");
        var request = new RestRequest($"comment/{Id}",Method.Put);
        CommentModel testModel = new CommentModel(){Subject = "Updated Subject", Content = "Updated Content"};
        request.AddBody(testModel);
        var response = client.Put(request);
        if (!string.IsNullOrWhiteSpace(response.Content) == true)
        {
            var comment = JsonConvert.DeserializeObject<CommentModel>(response.Content);
            Console.WriteLine($"Id:{comment.Id}\nSubject:{comment.Subject}\nContent:{comment.Content}\n"); 
        }
        Console.WriteLine(response.StatusCode);
    }
}
