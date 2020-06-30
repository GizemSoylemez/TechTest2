using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Test.Client
{
    public  class Client
    {

        private static RestClient client;
        private static RestRequest request;

        public static Client Create()
        {
            client = new RestClient();
            request = new RestRequest();
            return new Client();
        }

        public IRestResponse Get<T>(Parameter parameter,string path) where T : new()
        {
            try
            {
                client.BaseUrl = new Uri(URLLists.BaseURL + path);
                request.AddParameter(parameter);
            
                var ResponseMessage = client.Execute<T>(request);

                return ResponseMessage;
               // status kodu
            }
            catch
            {
                return new RestResponse();
            }
        }
        public IRestResponse Get<T>( string path ) where T : new()
        {
            try
            {
                client.BaseUrl = new Uri( URLLists.BaseURL+path);
                

                var ResponseMessage = client.Execute<T>(request);

                return ResponseMessage;
               // status kodu
            }
            catch
            {
                return new RestResponse();
            }
        }

       
        public string Post<T>(string path,RestRequest request) where T : new()
        {
            try
            {
                request.Method = Method.POST;
                client.BaseUrl = new Uri(URLLists.BaseURL + path);
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
                var response = client.Execute<T>(request);
              
                return response.Content;
            }
            catch
            {
                return "errroorr";
            }
        }
    }
}
