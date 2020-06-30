

# API Test

NUnit ve Resrsharp kullanarak GET, POST isteklerini karşılayan bir API Test projesi uygulaması gerçekleştirdim.  Yazmış olduğum API(API2) da isteklerin doğru cevap verilip verilmediğine bakılan ve daha sonra geliştirilebilir bir test projesidir.
PUT ve DELETE bulunmamaktadır.
# YAPI

 - Client: Bu klasörde Http isteklerinin olduğu klasördür.
 - Helper: Bu klasörümüzde dönüştürme işlemlerini yapıyoruz. Serialize ve Deserialize kullanarak formatlara dönüştürüp daha sonra orjinal haline çeviriyoruz.
 - Models: Bu klasörde book adında bir sınıf yer alıyor. Sınıfımızın içerisinde methodlar bulunuyor.
 - Test: Test klasörümüzün içinde de test caselerimiz yer alıyor. Caseler projelere göre ve kişisel olarak genişletilebilir.
 # Projemizi Nasıl Ayağa Kaldırıyoruz?
 
 - 1- İlk olarak API2 projemizi başlatıp çalıştırıyoruz.  
 - 2- Daha sonra test projemizi açıp Run yapıyoruz ve mesajları sol taraftaki
    pencereden görebiliyoruz.
