## 2024-2025 Güz Yaryılı Veri Tabanı Dersi Projesi Yazılma Aşamaları

1. Proje Visual Studio ortamında ASP.NET Core Web API teknolojisi kullanılarak C# dilinde yazıldı.

2. Proje, boş bir solution oluşturularak başlatıldı ve gerekli katmanlar sırasıyla projeye dahil edilerek çok katmanlı mimari yapısı kullanıldı.

3. İlk olarak Entity katmanı eklendi ve her bir veri tabanı tablosuna karşılık gelen entity sınıfları `Entities` klasöründe oluşturuldu.

4. İkinci olarak, veri tabanı ile doğrudan iletişime geçecek olan Data Access katmanı eklendi.** Bu katmanda, veri tabanı nesnelerini tutacak olan `bysContext` adında bir veri tabanı sınıfı oluşturuldu. Projenin `appsettings.json` dosyasında gerekli veri tabanı bağlantı bilgileri için bağlantı dizesi (“connection string”) tanımlandı.

5. Entity ve Data Access katmanları oluşturulduktan sonra, migration işlemiyle veri tabanı ve veri tabanı nesneleri fiziksel veri tabanına yansıtıldı.

6. Migration işlemlerinin tamamlanmasının ardından, Data Access katmanında gerekli `Interface` ve `Concrete` klasörleri ve sınıfları yazıldı. Her bir entity için CRUD metodları (“Create, Read, Update, Delete”) geliştirildi.

7. Sonrasında İş Katmanı (Business Layer) eklendi. Bu katmanda, entity’ler için gerekli iş kuralları ve doğrulamalar yazıldı. Kullanıcıdan gelen talepler bu katmanda doğrulama işlemlerine tabi tutuldu.

8. İş katmanı ve ilgili sınıfların yazımı tamamlandıktan sonra, API katmanına geçildi. Proje çözümüne bir ASP.NET Core Web Application projesi eklendi.
   - API katmanında her bir entity’ye karşılık gelen `Controller` sınıfları yazıldı.
   - Bu sınıflarda HTTP isteğini karşılayan metotlar (GET, POST, PUT, DELETE) geliştirildi.
   - `Controller` sınıfları, kullanıcıdan gelen istekleri alıp, iş mantığını Business katmanı aracılığıyla yürüterek veri tabanı işlemlerini yönetti.

9. Projenin ilk test aşamasında Postman aracılığıyla şu testler gerçekleştirildi:
   - `Course`, `Student` ve `Instructor` tabloları üzerinde çalışan GET metotları başarıyla test edildi.
   - ID’ye göre çalışan GET metotları da başarıyla çalıştı.

   Not: Postman aracılığıyla diğer HTTP metotları (POST, PUT, DELETE) henüz kontrol edilmedi.





