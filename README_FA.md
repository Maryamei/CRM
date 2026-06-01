# 🚀 Customer Management System (Clean Architecture & CQRS)

یک سیستم مدیریت مشتریان ساده و در عین حال قدرتمند که با استفاده از **.NET 8** توسعه داده شده است. هدف اصلی این پروژه، نمایش پیاده‌سازی صحیح **Clean Architecture** و الگوی **CQRS** در یک برنامه واقعی است.

## 🛠 تکنولوژی‌ها و الگوهای استفاده شده

در این پروژه از مدرن‌ترین الگوها و ابزارهای اکوسیستم دات‌نت استفاده شده است:

*   **Framework:** .NET 8 / ASP.NET Core Web API
*   **Architecture:** Clean Architecture (Domain, Application, Infrastructure, Presentation)
*   **Design Patterns:** CQRS, Repository Pattern, Mediator Pattern
*   **Libraries:** 
    *   `MediatR` (Implementing CQRS)
    *   `FluentValidation` (Validation Data in Application Layer)
    *   `Entity Framework Core` (ORM)
*   **Testing:** xUnit, Moq, FluentAssertions
*   **Database:** SQL Server

## ✨ ویژگی‌های کلیدی

*  **CRUD**:

برای عملیات ایجاد، ویرایش، حذف و مشاهده مشتری.
*   **Rich Domain Model:**  

جلوگیری از Anemic Model با کپسوله‌سازی منطق در لایه Domain.
*   **Global Exception Handling:** 

مدیریت متمرکز خطاها و بازگرداندن پاسخ‌های استاندارد RESTFULL API.

*   **Validation Pipeline:**

 استفاده از MediatR Pipeline Behaviors برای اعتبارسنجی خودکار Command ها قبل از رسیدن به Handler.
*   **Pagination:**

 پیاده‌سازی صفحه‌بندی برای دریافت لیست مشتریان جهت بهبود کارایی.
*   **Unit Testing:**

 دارای تست‌های واحد برای تضمین صحت عملکرد هسته نرم‌افزار.

## 🚀 راهنمای اجرا (Getting Started)

### پیش‌نیازها
*   [.NET 8 SDK](https://dotnet.microsoft.com/download)
*   SQL Server
*   An IDE like Visual Studio or Rider

### نصب و اجرا

1. **کلون کردن پروژه:**

```
git clone https://github.com/Maryamei/CRM.git
```

2. **تنظیم Connection String:**

 فایل appsettings.Development.json در لایه Presentation (API) را باز کرده و Connection String دیتابیس خود را تنظیم کنید.

3. **اعمال Migration ها (ساخت دیتابیس):**

با استفاده از Package Manager Console (PMC) در ویژوال استودیو:
```
   Update-Database
```
 یا با استفاده از .NET CLI در مسیر روت پروژه:
```
    dotnet ef database update --project CRM.Infrastructure --startup-project CRM
```

 📂 **ساختار پروژه (Folder Structure)**

پروژه بر اساس مفاهیم Clean Architecture به لایه‌های زیر تقسیم شده است:

- Domain:

 قلب سیستم شامل Entities ، Value Objects و Domain Exceptions هیچ وابستگی به لایه‌های دیگر ندارد.
- Application: 

شامل Use Case ها (Commands & Queries)، Interfaces و Validation. تنها به لایه Domain وابسته است.
- Infrastructure: 

پیاده‌سازی وابستگی‌های خارجی مانند دسترسی به دیتابیس (EF Core)، فایل سیستم و سرویس‌های ایمیل.
- Presentation (API): 

نقطه ورود برنامه (Controllers) وظیفه دریافت درخواست‌ها و ارسال آن‌ها به لایه Application را دارد.


---
**توسعه داده شده توسط مریم افتخاری** 

 https://www.linkedin.com/in/maryam-eftekhari-0145121b3/ 


