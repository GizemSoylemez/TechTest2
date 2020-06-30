using Newtonsoft.Json;

namespace Test.Helper
{
    public static class JsonConverter
    {
        //Burada 
        public static T ConvertJson<T>(string contents)
        {
            return JsonConvert.DeserializeObject<T>(contents);
            //Serialize ettiğimiz nesneyi orjinal haline geitrmemizi sağlıyoruz.
        }

        public static string ConvertToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
            //Nesnenin bir kopyasını kullanarak ve bunu kolayca bir forma çevirebilir.
        }
        
    }
}
