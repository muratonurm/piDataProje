PiData Case Study
- Proje database olarak SQL Server kullanmaktadır. 
- SQL Server'da boş bir database oluşturulduktan sonra appsettings.json içerisindeki connection string düzenlenmelidir.
- Proje başlatılmadan önce `dotnet ef update database` kullanılarak daha önceden kayıt altına alınmış migrasyon boş database üzerine uygulanmalıdır.
- Şehirler, İlçe ve Mahalleler EF Core Seed Data kullanılarak içeriye eklenmedi. Bu nedenle proje dizininde bulunan `script.sql` dosyası oluşturulan database içerisine migrasyon update sonrasında çalıştırılmalıdır.
- Bu adımlar tamamlandıktan sonra proje sorunsuz olarak ayağa kalkacaktır.
