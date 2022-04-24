# Proje Yapısı
```
PhoneBook.Entity
PhoneBook.DataAccess
PhoneBook.WebApi
```
bu projeler telefon rehberi servisini oluşturuyor.
```
Report.Entity
Report.DataAccess
Report.Webapi
```
 bu projeler de rapor servisini oluşturuyor
 ```
 Report.Worker
 ```
İstenilen raporu işleyen servis
```
Kafka.MessageReceiver
```
Kafka üzerinden gelen mesajları yakalayan ve ve yönlendiren servis
```
ApiGateway
```
Gelen istekleri yöndendiren bir geçit olarak düşünülebilir.
## Projeyi çalıstırabilmek için yapılması gerekenler
Veritabanı için gerekli migrasyonların yapılması gerekmektedir. `postgresql` veritabanının kullanıcı adı ve parolası `DbContext` sınıflarında bulunmaktadır gerekli olduğu takdirde oradan değiştirilebilir. Gerekli Migrasyonları yapmak için istenilirse migrasyonlar silinip 
```
 dotnet ef migrations add Initialize
 dotnet ef database update
```
komutlarıyla yeniden oluşturulabilir.

`docker-compose up -d ` komutu ile kafkayı başlatıyoruz. Ardından 
`Kafka.MessageReceiver` , `PhoneBook.WebApi` , `Report.Webapi` , ` Report.Worker ` ve `ApiGateway ` projeleri çalıştırılır. `/swagger` endpointinden bütün apileri listeleyebilirsiniz.`PhoneBook` servisine gateway üzerinden ulaşabilmek için `http://0.0.0.0:3001/phonebook/` , `Report` servisine bağlanmak içinde `http://0.0.0.0:3001/report/` endpointi kullanılabilir `ocelot.json` içerisindende bakabilirsiniz.
<li> <b>NOT :</b> Geliştirme ortamım  linux olduğu için rapor alıp excel formatında kaydetme kısmını yapamadım. İşe gidiş geliş saatlerimin uygunsuzlugundan dolayı yeteri kadar kendimi veremiyorum bu sebepten hiç göndermemektense yapabildiğim kadarını gönderiyim fırsat bulduğum vakitlerde ekleme yaparım.
<li> <b>NOT :</b> Test kodu için gerekli olan  ufak tefek ayarları kod içerisinde yazdım oradan bakabilirsiniz. Testi  maalesef tamamen bağımsız bir şekilde çalışabilecek hale getiremedim  bu sebepten dolayı testin daha verimli çalışabilmesi için `Report.WebApi` projesinin çalışıyor ve kafkanın `docker-compose up -d ` komutu ile çalıştırılması gerekmektedir.
