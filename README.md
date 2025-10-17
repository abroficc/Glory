# Glory77 - ASP.NET Core Application

## نظرة عامة
Glory77 هو تطبيق ويب متطور مبني باستخدام ASP.NET Core، يوفر نظام إدارة شامل مع واجهة مستخدم حديثة.

## المميزات الرئيسية
- نظام إدارة المستخدمين والموظفين
- إدارة العملاء والأجهزة
- نظام المحاسبة والقسائم
- إدارة الفروع والمدن
- نظام التقارير والإحصائيات
- واجهة مستخدم تفاعلية باستخدام SignalR
- دعم متعدد اللغات

## التقنيات المستخدمة
- **Backend**: ASP.NET Core
- **Frontend**: HTML, CSS, JavaScript, jQuery
- **Database**: SQL Server
- **Real-time Communication**: SignalR
- **UI Framework**: Bootstrap, Inspinia Theme
- **Build Tools**: Gulp, Node.js

## متطلبات التشغيل
- .NET Core SDK
- SQL Server
- Node.js (للأدوات الأمامية)
- Visual Studio أو VS Code

## التثبيت والتشغيل

### 1. استنساخ المشروع
```bash
git clone https://github.com/abroficc/Glory.git
cd Glory
```

### 2. تثبيت التبعيات
```bash
# تثبيت حزم Node.js
npm install

# استعادة حزم NuGet
dotnet restore
```

### 3. إعداد قاعدة البيانات
- قم بتحديث connection string في `appsettings.json`
- تشغيل migrations:
```bash
dotnet ef database update
```

### 4. تشغيل التطبيق
```bash
dotnet run
```

## هيكل المشروع
```
Glory77/
├── Controllers/          # وحدات التحكم
├── Models/              # نماذج البيانات
├── Views/               # واجهات المستخدم
├── Data/                # سياق قاعدة البيانات
├── Hubs/                # SignalR Hubs
├── wwwroot/             # الملفات الثابتة
├── Migrations/          # ملفات الهجرة
└── Helpers/             # الوظائف المساعدة
```

## المساهمة
نرحب بالمساهمات! يرجى:
1. عمل Fork للمشروع
2. إنشاء branch جديد للميزة
3. تنفيذ التغييرات
4. إرسال Pull Request

## الترخيص
هذا المشروع محمي بحقوق الطبع والنشر.

## الدعم
للحصول على الدعم، يرجى التواصل معنا عبر GitHub Issues.
