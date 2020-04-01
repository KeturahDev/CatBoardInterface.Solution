using System.Threading.Tasks;
using System;
using RestSharp;


namespace CatBoardInterface.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll(string controller)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"{controller}", Method.GET);
      var response = await client.ExecuteTaskAsync(request); //calls the api, gets a response with everything
      return response.Content; //gets the json body of the response
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"boards/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newBoard)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"boards", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newBoard);
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}