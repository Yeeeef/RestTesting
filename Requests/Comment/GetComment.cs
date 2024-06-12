using Newtonsoft.Json;
using RestSharp;
using RestTesting.Models;

namespace RestTesting.Requests;

public class GetComment
{
    public static void GetAllCommentsRequest(RestClient client)
    {
        Console.WriteLine("Getting All Comments.");
        var request = new RestRequest("comment", Method.Get);
        var response = client.Get(request);
        if (!string.IsNullOrWhiteSpace(response.Content) == true)
        {
            var comments = JsonConvert.DeserializeObject<List<CommentModel>>(response.Content);
            if(comments == null)
            {
                Console.WriteLine("Error While Deserializing");
            }
            foreach(CommentModel comment in comments)
            {
                Console.WriteLine($"Id:{comment.Id}\nSubject:{comment.Subject}\nContent:{comment.Content}\n");
            }
            Console.WriteLine(comments);
        }
        else Console.WriteLine(response.StatusCode);
    }

    public static void GetCommentRequest(RestClient client,int? id)
    {
        Console.WriteLine($"Getting TestComment.");
        var request = new RestRequest($"comment/{id}", Method.Get);
        var response = client.Get(request);
        if(response == null)
        {
            Console.WriteLine(response.StatusCode);
        }
        if (!string.IsNullOrWhiteSpace(response.Content) == true)
        {
            var comment = JsonConvert.DeserializeObject<CommentModel>(response.Content);
            Console.WriteLine($"Id:{comment.Id}\nSubject:{comment.Subject}\nContent:{comment.Content}\n"); 
        }
        Console.WriteLine(response.StatusCode);
    }

}
