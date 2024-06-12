using System.Runtime.CompilerServices;
using RestSharp;

namespace RestTesting;

public class DeleteComment
{

    public static void DeleteCommentRequest(RestClient client, int? CommentId)
    {
        Console.WriteLine($"Deleting TestComment.");
        var request = new RestRequest($"comment/{CommentId}", Method.Delete);
        var response = client.Delete(request);
        if (response.IsSuccessful == true)
        {
            Console.WriteLine($"Response: {response.Content}\n");
        }
    }
}
