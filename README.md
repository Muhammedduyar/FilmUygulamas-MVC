# 🎬 Film İzleme Uygulaması (ASP.NET Core MVC)

## 📌 Proje Hakkında  
Bu proje, kullanıcıların film listesine göz atabileceği, film arayabileceği ve izlemek istedikleri filmleri kaydedebileceği bir **film izleme web uygulamasıdır**.  
**ASP.NET Core MVC** mimarisi ile geliştirilmiş olup tarayıcı üzerinden kullanıcı dostu bir arayüz sunar.  

---

## 🛠 Kullanılan Teknolojiler  
- **C# (.NET Core)**  
- **ASP.NET Core MVC**  
- **Veritabanı:** SQL Server / MySQL / SQLite (tercihe bağlı)  
- **ORM:** Entity Framework veya Dapper  
- **Razor View Engine** (UI geliştirme için)  

---

## 🏗 Mimarî Yapı  
Proje **katmanlı mimari** ile birlikte **MVC (Model-View-Controller)** yapısını kullanır:  

- **Model Katmanı** → Film ve kullanıcı nesneleri  
- **Controller Katmanı** → Kullanıcı isteklerini işler ve uygun View’i döner  
- **View Katmanı** → Razor tabanlı web arayüzü  

Ek olarak:  
- **Veri Erişim Katmanı (DAL)** → CRUD işlemleri  
- **İş Mantığı Katmanı (BLL)** → Film arama, ekleme, izlenenleri kaydetme vb.  

---

## ✨ Temel Özellikler  
- Film listesi görüntüleme  
- Film arama  
- Film ekleme (yönetici)  
- İzleme listesi / geçmişi yönetimi  
- Kullanıcı kayıt, giriş ve profil yönetimi  

---

## 🚀 Kurulum ve Çalıştırma  

1. **Projeyi klonlayın**  
   ```bash
   git clone https://github.com/kullaniciadi/film-izleme-mvc.git
   cd film-izleme-mvc
