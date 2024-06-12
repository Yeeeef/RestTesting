using System.Security.Cryptography.X509Certificates;
using RestSharp;
using RestTesting.Models;

namespace RestTesting;

public class UpdateComment
{

    public static void UpdateCommentRequest(RestClient client, string Id)
    {
        Console.WriteLine("Updating Comment");
        var request = new RestRequest($"comment/{Id}",Method.Put);
        CommentModel testModel = new CommentModel(){Subject = "Updated Subject", Content = "Updated Content"};
        request.AddBody(testModel);
        var response = client.Put(request);
        Console.WriteLine(response.StatusCode);
    }
}
