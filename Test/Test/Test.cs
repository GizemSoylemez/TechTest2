using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Test.Client;
using Test.Helper;
using Test.Models;


namespace Test.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private IRestResponse _searchResponse;

        [TestCase( "/Book/list")]
        [Order(1)]
        public void GetBooks(string path)
        {
            _searchResponse =
                Client.Client.Create()
                    .Get<Books>(path);
            Assert.That(_searchResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "OKEY");
           

            List<Books> booksResponse_Instance =
                JsonConverter.ConvertJson<List<Books>>(_searchResponse
                    .Content); //deserialize edilir


            Assert.That(booksResponse_Instance, Is.Not.Null);
            Assert.IsInstanceOf<List<Books>>(booksResponse_Instance); 
        }

        [TestCase("Id","2", ParameterType.GetOrPost, "Book/get")]
        [Order(2)]
        public void GetBookWithId(string name,string value,ParameterType type,string path)
        {
            _searchResponse =
                Client.Client.Create()
                    .Get<Books>(new Parameter( name, value, type), path);
            Assert.That(_searchResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "oldu");


            var booksResponse_Instance =
                JsonConverter.ConvertJson<Books>(_searchResponse
                    .Content); //deserialize edilir


            Assert.That(booksResponse_Instance, Is.Not.Null);
            Assert.IsInstanceOf<Books>(booksResponse_Instance);
        }

        [TestCase("Id", "3", ParameterType.GetOrPost, "Book/get")]
        [Order(2)]
        // Burda idsi 3 numaralı kitap var mı diye test ediyoruz.
        //Ama elimizde sadece 2 tane kitap var bundan dolayı da çalışmadığını gösteriyoruz.
        public void GetBookWithInvalidId(string name, string value, ParameterType type, string path)
        {
            _searchResponse =
                Client.Client.Create()
                    .Get<Books>(new Parameter(name, value, type), path);
            Assert.That(_searchResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "oldu");


            var booksResponse_Instance =
                JsonConverter.ConvertJson<Books>(_searchResponse
                    .Content); //deserialize edilir


            Assert.That(booksResponse_Instance, Is.Null);
            Assert.IsInstanceOf<Books>(booksResponse_Instance,"Bulunamadı");
        }


        [TestCase("Book/post")]
        [Order(4)]
        public void PostBooks(string path)
        {
            var bookRequest = new Books { Id = 5, Author = "testt", Title = "asdas" };
            //örnek bir veri girerek post edilmesini deniyoruz.
            var Request1 = new RestRequest();
            Request1.AddParameter("application/json; charset=utf-8", JsonConverter.ConvertToJson(bookRequest), ParameterType.RequestBody);
         
            var _searchResponse =
                Client.Client.Create()
                    .Post<Books>(path, Request1);
            Assert.IsTrue(_searchResponse.Contains("Eklendi"));
        }
    }
}