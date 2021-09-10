PiData Case Study
- Proje database olarak SQL Server kullanmaktadır. 
- SQL Server'da boş bir database oluşturulduktan sonra appsettings.json içerisindeki connection string düzenlenmelidir.
- Proje başlatılmadan önce `dotnet ef update dabase` kullanılarak daha önceden kayıt altına alınmış migrasyon boş database üzerine uygulanmalıdır.
