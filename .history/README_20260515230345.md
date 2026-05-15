# 🥗 Diyetisyen Asistanı

Diyetisyen Asistanı, diyetisyenlerin hesaplamalarını kolaylaştırmak ve diyet yazımını desteklemek amacıyla geliştirilmiş ASP.NET Core MVC tabanlı bir web uygulamasıdır. Kullanıcılar uygulama üzerinden çeşitli sağlık hesaplamaları yapabilir, günlük kalori ihtiyaçlarını analiz edebilir ve sağlıklı yaşam konusunda bilgilendirici içeriklere erişebilir.

## 🚀 Canlı Ulaşımı

https://diyetisyenasistani.onrender.com

---

# ✨ Özellikler

- BMI (Vücut Kitle İndeksi) hesaplama
- BMR (Bazal Metabolizma Hızı) hesaplama
- Günlük kalori ihtiyacı analizi
- Responsive ve modern kullanıcı arayüzü
- Mobil uyumlu tasarım
- ASP.NET Core MVC mimarisi
- Docker ile containerized deployment
- Render üzerinde canlı yayın

---

# 🛠 Kullanılan Teknolojiler

## Backend
- ASP.NET Core MVC (.NET 8)

## Frontend
- HTML5
- CSS3
- Bootstrap
- JavaScript

## Deployment & DevOps
- Docker
- Render
- Git
- GitHub

---

# 📷 Uygulama Görselleri


---

# ⚙️ Projeyi Lokal Ortamda Çalıştırma

## 1. Repoyu klonlayın

```bash
git clone https://github.com/GozdeAybey/diyetisyenasistani.git
```

## 2. Proje klasörüne girin

```bash
cd diyetisyenasistani
```

## 3. Paketleri yükleyin

```bash
dotnet restore
```

## 4. Projeyi çalıştırın

```bash
dotnet run
```

---

# 🐳 Docker ile Çalıştırma

## Docker image oluşturma

```bash
docker build -t diyetisyenasistani .
```

## Container çalıştırma

```bash
docker run -p 8080:80 diyetisyenasistani
```

---

# 📁 Proje Yapısı

```text
DiyetisyenApp/
│
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── ViewModels/
├── Services/
├── Dockerfile
└── Program.cs
```

---

# 🌐 Deployment

Uygulama Docker kullanılarak container ortamında çalıştırılmış ve Render platformu üzerinden yayınlanmıştır.

---

# 👩‍💻 Geliştirici

## Gözde Aybey

---

# ⭐ Katkı ve Destek

Projeyi beğendiyseniz repo’ya yıldız vermeyi unutmayın ⭐