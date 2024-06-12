using RestSharp;
using Newtonsoft.Json;
using RestTesting.Models;
using RestTesting.Requests;
using RestSharp.Authenticators;
using RestTesting;



namespace Program
{
public class Program
{
    private static void Main()
    {
        string url = "http://172.24.141.209:5265/api/";
        var client = new RestClient(url);

       try //CreateTestComment, GetTestComment and DeleteTestComment
        {
            int? _testComment = CreateComment.CreateCommentRequest(client, 1);
            if (_testComment != null)
            {
                GetComment.GetCommentRequest(client, _testComment);
                DeleteComment.DeleteCommentRequest(client, _testComment);
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine($"GetComment Failed Because: {ex.Message}");
        }



        try //GetAllComments
        {
            GetComment.GetAllCommentsRequest(client);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetAllComments Failed Because: {ex.Message}");
        }


    }


}

}
