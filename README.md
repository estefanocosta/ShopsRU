  # ShopsRU

### Onion Archecture


### Application 

* Bootstrapper   
* DiscountStrategies
  
 Interfaces
*	Repositories
*	Services
*	UnitOfWork
* Contract
* Validators
* Wrappers

### Domain
 * Entities 
 * Enums

### Infrastructure
* Resources

### Persistence

Context
   * DbContext
   *	EntityConfigurations
   *	Migrations
   *	MigrationUsage

Implementations

*	Repositories
*	Services
*	UnitOfWork
* Bootstrapper

### Host
* Attributes
* Middlewares
* Extensions



### Genel Bakış
Uygulama temel seviyede Customer, Product, Invoice, Sales, Discount, Category oluşturma ve görüntüleme uçlarını sunmaktadır. Exception yönetimi 
(Middlewares/ErrorHandlerMiddleware) merkezi bir noktada handle edilmiştir. Oluşan exceptionlar Logs tablosuna loglanmıştır. 

Requst sınıflarının doğrulanması Fluent Validation ile gerçekleştirilip, belirnen kuralların dışında gelen istekler (Attributes/ValidationFilter) ile merkezi bir noktada ele almıştır.



Veritabanı operasyonlarında generate edilen sorguların execute edilirken ortaya çıkaracağı maliyeti minimize etmek için her operasyon için db gidilmesi yerine Unit Of Work 
design pattern uygulanıp, veri tutarlığının sağlanması için Commit/Rollback mekanizması işletilmiştir.

Oluşturulacak her response için mesajlar kod içerisinde tutulmak yerine messages_en.json içerisinden okunup, ileride oluşabilecek bir değişiklikte kullanılan tüm yerlerde 
düzenlemeye gitmeye gerek kalmaması hedeflenmiştir. Kodun kirlenmesinin önüne amaçlanmıştır.


Sürdürülebilirlik, belirli kod standartları,algoritmik değişikliklerde uygulamanın kırılması gibi başlıklar göz önünde bulunduruluarak UnitTest projeye dahil edilmiştir.




### İndirim Yönetimi 
İndirimler Mağaza Çalışan için %20, Mağaza Üyesi için %10 İki yılı aşkındır müşteri ise %5 şeklinde uygulanacaktır.
Seçilen kategoride olan ürünler için indirim uygulanmayacak.
Yüzde indirimlerinden bir faturada bir kez faydalanılabilir.
Toplam Fatura tutarında her 100$ için 5$ indirim uygulanacak.
 


İndirimler uygulanırken küçük bir kırılım bulunmaktadır. Müşteri tipi "Mağaza Üyesi" olup ve 2  yılı aşkındır müşteri ise burada 
%10 ve %5 lik bir indirim hakkı olacaktır. Yüzde indirimlerinden bir kez faydalanılabilir kuralını sağlamak için "" üzerinden uygulanacak indirim türü 
önceliklendirilmiştir. "True" ise önce müşteri 2 yılı aşkındır müşteri mi ? durumuna bakılır ve kişi %5 indirimden faydalanır. "False" ise 
kişi 2 yılı aşkındır müşteride olsa uygulanacak indirim önceliği %10 luk indirimdir.


Uygulanabilecek indirim türleri Discount tablosunda yer almaktadır. Discount tablosu CustomerDiscount tablosu ile ilişkilendirilmiştir ve  müşteri tipine 
göre indirimler belirlenmiştir. Burada bulunan RuleJson sınıfı veritbanında json olarak tutulup ileride gelecek kırılımlar için bir rule set görevi görmektedir.

 

ExcludeCategories : İndirimden muaf olacak kategoriler
CustomerAgeYear : Müşteri yaşı 2 yıl bilgisi
FixedAmount : Her 100$
FixedDiscountAmount: 5$
LoyalCustomerPriority: İndirim önceliği müşteri "Mağaza üyesi" tipinde ise bu alanın True gönderildiği durumda öncelik %5 lik indirim False ise 
öncelik %10 indirimdir.

LoyalCustomerDiscountRate: Müşteri yaşı için uygulanacak indirim oranı.  Müşteri yaşına göre uygulanacak indirim oranı değişebilir bu yüzden 
parametrik olarak tasarlanmıştır.

### Dil ve Teknolojiler
* .Net 7
* SQL
* EF CORE
* Code First
* Fluent Validation
* C#

### Başlarken

1. Clone the repo
   ```sh
   git clone https://github.com/eaktassssss/ShopsRU.git
   ```
2. Manage Nuget Packages
   ```sh
    Install-Package Microsoft.EntityFrameworkCore -Version 7.0.9
    Install-Package Microsoft.EntityFrameworkCore.SqlServer 7.0.9
    Install-Package Microsoft.EntityFrameworkCore.Tools -Version 7.0.9
   ```

3. Database Migration
   ```sh
   Add-Migration initial -OutputDir  E:\ShopsRU\ShopsRU.Persistence\Context\Migrations\SQL
   update-database
   ```


### Blog
Web Site:https://evrenaktas.com


