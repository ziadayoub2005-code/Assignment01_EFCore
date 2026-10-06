# Entity Framework Core — Day 01 Assignment (.NET 5)

[![.NET](https://img.shields.io/badge/.NET-5.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-9.0-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![EF Core](https://img.shields.io/badge/EF%20Core-5.0.17-512BD4?logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019%2F2022-CC292B?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Status](https://img.shields.io/badge/Status-Completed-success)]()

حل شامل ومهني ومفصل بصيغة بشرية نظيفة (Human-Crafted C#) لتكليف **Entity Framework Core (Day 01 / Session 03)**، يطبق استراتيجية **Code First** لبناء نظام إدارة مكتبة (**Bookstore System**) مع تطبيق طرق الربط الثلاث (Conventions, Data Annotations, Fluent API)، مدعوماً بتقرير نظري شامل (PDF) وملفات الترحيل (Migrations).

---

## 📑 محتويات المستودع (Repository Structure)

```text
EF01_Assignment/
├── Demos/                                              # الأكواد التوضيحية والتطبيقات المشروحة في المحاضرة
│   ├── 00.png                                          # توضيح مفاهيم الربط وقواعد البيانات
│   ├── 01.png
│   ├── 03.png
│   └── EFDay01/                                        # مشروع المحاضرة (CompanyDbContext Demo)
│       ├── EFDay01.sln
│       └── EFDay01/
├── Task/                                               # مجلد حل التكليف الرئيسي (Bookstore System)
│   ├── task.pdf                                        # ملف التكليف الأصلي
│   ├── EF01_Task_Answers.pdf                           # تقرير الحل الشامل والأسئلة النظرية والمفاهيمية
│   ├── BookstoreSystem.sln                             # ملف الحل لمشروع التكليف
│   └── BookstoreSystem/                                # مشروع الـ Console App المنفذ بـ .NET 5
│       ├── Configurations/
│       │   └── BookConfigurations.cs                   # Fluent API Configuration Class (Clean Architecture)
│       ├── Contexts/
│       │   └── BookstoreDbContext.cs                   # DbContext & OnConfiguring & OnModelCreating
│       ├── Migrations/                                 # سجل الـ Migrations الثلاث
│       │   ├── ..._InitialCreate.cs                    # 1) الترحيل الأولي (Conventions)
│       │   ├── ..._AnnotateAuthor.cs                   # 2) ترحيل Data Annotations
│       │   └── ..._FluentBook.cs                       # 3) ترحيل Fluent API
│       ├── Models/
│       │   ├── Book.cs                                 # كلاس Book وإجابات أسئلة الـ Conventions
│       │   └── Author.cs                               # كلاس Author مع وسوم Data Annotations
│       ├── Screenshots/
│       │   └── database_tables.png                     # إثبات إنشاء الجداول في SQL Server
│       ├── Program.cs                                  # نقطة انطلاق التطبيق واختبار الـ Context
│       └── BookstoreSystem.csproj                      # إعدادات المشروع وحزم EF Core 5.0.17
├── EF01_Task_Answers.pdf                               # نسخة التقرير النظري في المسار الرئيسي
├── LINQ and EF Preparation Guide - Session03.pdf       # الدليل التحضيري لمحاضرة Session 03
├── .gitignore                                          # استثناء ملفات البناء والملفات المؤقتة
└── README.md                                           # التوثيق العام للمشروع
```

---

## 🛠️ تفاصيل بيئة العمل والحزم (Prerequisites & Tech Stack)

- **Target Framework:** `.NET 5.0` (`net5.0`)
- **Language Version:** `C# 9.0`
- **ORM Engine:** `Microsoft.EntityFrameworkCore.SqlServer (5.0.17)`
- **CLI / Migration Tools:** `Microsoft.EntityFrameworkCore.Tools (5.0.17)`
- **Database Engine:** Microsoft SQL Server (`Server=.;Database=BookstoreDB;Trusted_Connection=True;`)

---

## 🎯 المهام المنفذة واستراتيجيات الربط الثلاث (Mapping Strategies)

### 1. استراتيجية الربط التلقائي (Part A — Mapping by Convention)
- تم بناء كائن `Book` بالخصائص الأساسية:
  - `Id (int)` &larr; تلقائياً مفتاح أساسي وحقل هوية `IDENTITY(1,1)`.
  - `Title (string)` &larr; نوع مرجعي يقبل `null` تلقائياً بـ `nvarchar(max)`.
  - `Price (decimal)` &larr; نوع قيمة `decimal` غير قابل للقيم الفارغة `NOT NULL`.
  - `PublishedDate (DateTime?)` &larr; نوع قيمة اختياري يقبل `null`.

#### أسئلة الـ Convention المضمنة في كود [Book.cs](file:///Task/BookstoreSystem/Models/Book.cs):
> **Q1: Why did the property "Id" become a Primary Key without any explicit configuration?**  
> **الإجابة:** يعتمد EF Core على مبدأ **Convention over Configuration**. تلقائياً أي خاصية تحمل الاسم `Id` أو `<ClassName>Id` (غير حساسة لحالة الأحرف) يتم تعيينها كمفتاح أساسي (Primary Key)، ولأن نوعها عددي صحيح (`int`)، يتم تهيئتها كحقل ترقيم تلقائي `IDENTITY(1,1)`.

> **Q2: Why is "Country" nullable in the database while "Price" is not?**  
> **الإجابة:** وفقاً لنظام الأنواع في C#:
> 1. `Price` نوعه `decimal` وهو **Value Type** غير قابل لـ null افتراضياً، فيترجمه EF Core إلى `decimal(18,2) NOT NULL`.
> 2. `Country` نوعه `string` وهو **Reference Type** يقبل null افتراضياً، فيترجمه EF Core إلى عمود يسمح بالقيم الفارغة `NULL`.

---

### 2. استراتيجية وسوم البيانات (Part B — Data Annotations)
- تم إعداد كائن `Author` باستخدام وسوم الـ Attributes:
  - `[Table("Writers")]` &larr; تغيير اسم الجدول في قاعدة البيانات من `Authors` إلى `Writers`.
  - `[Required]` &larr; فرض عدم السماح بالقيم الفارغة على حقل `Name`.
  - `[MaxLength(100)]` &larr; تحديد الحد الأقصى لطول الاسم بـ 100 حرف (`nvarchar(100)`).
  - حقل `Country` تُرك اختيارياً ليقبل القيم الفارغة.

---

### 3. استراتيجية واجهة البرمجة الانسيابية (Part C — Fluent API)
- تم تطبيق نمط **Clean Architecture** عبر إنشاء كلاس إعداد مستقل لكل كائن:
  - كلاس `BookConfigurations : IEntityTypeConfiguration<Book>`.
  - تطبيق الإعداد داخل `BookstoreDbContext.OnModelCreating` عبر:
    ```csharp
    modelBuilder.ApplyConfiguration(new BookConfigurations());
    ```
- **قواعد الإعداد المطبقة على Book:**
  - `Title`: إجباري مع حد أقصى 150 حرفاً (`IsRequired().HasMaxLength(150)`).
  - `Price`: تحديد نوع وبيانات العمود بدقة `HasColumnType("decimal(8,2)")`.
  - `PublishedDate`: تحديد أنه اختياري صراحةً (`IsRequired(false)`).

---

## 🗄️ سجل الترحيلات (Migrations History)

تم إنشاء الترحيلات الثلاث بالترتيب لتوثيق دورة حياة التطور التراكمي للـ Schema:

| الترحيل (Migration) | الوصف والتأثير على قاعدة البيانات |
|:---|:---|
| **`InitialCreate`** | بناء جدولي `Books` و `Authors` بالاعتماد التام على الـ Conventions الافتراضية. |
| **`AnnotateAuthor`** | إعادة تسمية جدول `Authors` إلى `Writers`، وفرض `NOT NULL` و `MaxLength(100)` على عمود `Name`. |
| **`FluentBook`** | تعديل عمود `Title` ليكون `nvarchar(150) NOT NULL`، وتعديل عمود `Price` إلى `decimal(8,2)`. |

---

## 🧠 ملخص الإجابات النظرية والمفاهيمية (Theoretical Answers Summary)

### س1: لماذا نفضل استخدام Code First على Database First في بيئات العمل الحديثة؟
1. **Single Source of Truth:** كود الـ C# هو المصدر الوحيد والنهائي للحقيقة، ولا حاجة لإجراء تعديلات يدوية على SQL Server.
2. **Version Control & CI/CD Integration:** إمكانية تتبع تغييرات قاعدة البيانات جنباً إلى جنب مع كود المشروع عبر Git والـ CI/CD Pipelines.
3. **True OOP Domain Modeling:** تصميم بيئة العمل والكيانات بالاعتماد على مفاهيم الكائنات (OOP) كالتوارث (Inheritance) والعلاقات دون التقيد بأسلوب الـ Relational الصرف أولاً.
4. **DBMS Agnostic:** إمكانية تغيير محرك قاعدة البيانات (SQL Server &rarr; PostgreSQL / SQLite) بتعديل سطر واحد فقط دون إعادة كتابة جداول البيانات.

### س2: لماذا يُفضل الـ Fluent API على Data Annotations في المشاريع الضخمة؟
1. **Separation of Concerns (Clean POCO):** إبقاء كلاسات الموديل نظيفة وخالية من وسوم قواعد البيانات وتبعيات الـ EF Core.
2. **Advanced Capabilities:** دعم خصائص متقدمة يستحيل عملها بالوسوم (مثل: Composite Keys، Value Converters، تحديد دقة الأرقام العشرية بدقة، و Cascade Delete).
3. **Precedence Hierarchy:** الـ Fluent API يملك الأولوية القصوى ويلغي أي تعارض مع الـ Annotations أو الـ Conventions.
4. **Modularity:** إمكانية تقسيم الإعدادات عبر كلاسات `IEntityTypeConfiguration<T>` بدلاً من ازدحام الكلاسات أو ملف الـ DbContext.

---

## 🖥️ تشغيل المشروع محلياً (How to Run)

```bash
# 1. الدخول إلى مجلد التكليف
cd Task/BookstoreSystem

# 2. استرجاع الحزم وبناء المشروع
dotnet restore
dotnet build

# 3. تحديث قاعدة البيانات وتطبيق المايجريشن
dotnet ef database update

# 4. تشغيل البرنامج
dotnet run
```

---

**إعداد وتنفيذ:** زياد محمد (Zeyad Mohamed)  
**الكورس:** .NET Full Stack Development — DotNetWithElwakeel
