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

        private IRestResponse response;

        [TestCase( "/Book/list")]
        [Order(1)]
        public void GetBooks(string path)
        {
            response = Client.Client.Create().Get<Books>(path);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "OKEY");

            List<Books> booksResponse_Exp =
                JsonConverter.ConvertJson<List<Books>>(response.Content); //deserialize edilir


            Assert.That(booksResponse_Exp, Is.Not.Null);
            Assert.IsInstanceOf<List<Books>>(booksResponse_Exp); 
        }


        [TestCase("Id","2", ParameterType.GetOrPost, "Book/get")]
        [Order(2)]
        public void GetBookWithId(string name,string value,ParameterType type,string path)
        {
            response = Client.Client.Create().Get<Books>(new Parameter( name, value, type), path);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "oldu");


            var booksResponse_Exp =
                JsonConverter.ConvertJson<Books>(response.Content); //deserialize edilir


            Assert.That(booksResponse_Exp, Is.Not.Null);
            Assert.IsInstanceOf<Books>(booksResponse_Exp);
        }

        [TestCase("Id", "3", ParameterType.GetOrPost, "Book/get")]
        [Order(2)]
        // Burda idsi 3 numaralı kitap var mı diye test ediyorum.
        //Ama elimizde sadece 2 tane kitap var bundan dolayı da çalışmadığını gösteriyorum.
        public void GetBookWithInvalidId(string name, string value, ParameterType type, string path)
        {
            response = Client.Client.Create().Get<Books>(new Parameter(name, value, type), path);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "oldu");


            var booksResponse_Exp =
                JsonConverter.ConvertJson<Books>(response.Content); //deserialize edilir


            Assert.That(booksResponse_Exp, Is.Null);
            Assert.IsInstanceOf<Books>(booksResponse_Exp, "Bulunamadı");
        }


        [TestCase("Book/post")]
        [Order(4)]
        public void PostBooks(string path)
        {
            var bookRequest = new Books { Id = 5, Author = "testt", Title = "asdas" };
            //örnek bir veri girerek post edilmesi
            var Request1 = new RestRequest();
            Request1.AddParameter("application/json; charset=utf-8", JsonConverter.ConvertToJson(bookRequest), ParameterType.RequestBody);
         
            var _response = Client.Client.Create().Post<Books>(path, Request1);
            Assert.IsTrue(_response.Contains("Eklendi"));
        }
    }
}