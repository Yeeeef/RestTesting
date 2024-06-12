using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestTesting.Models;

namespace RestTesting.Requests;

public class CreateComment
{
    public static int? CreateCommentRequest(RestClient client, int StockId)
    {
        Console.WriteLine("Creating TestComment.");
        var request = new RestRequest($"comment/{StockId}",Method.Post);
        CommentModel testmodel = new CommentModel() {Subject= "Test",Content="Test Comment"};
        request.AddBody(testmodel);
        var response = client.Post(request);
        if (response == null)
        {
            Console.WriteLine($"CreateComment Failed Because: {response.Content}");
            return null;
        }
        if (!string.IsNullOrWhiteSpace(response.Content) == true)
        {
            var comment = JsonConvert.DeserializeObject<CommentModel>(response.Content);
            Console.WriteLine($"Id:{comment.Id}\nSubject:{comment.Subject}\nContent:{comment.Content}\n");
            return comment.Id;
        }
        return null;
    }
}
