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

## حل المشاكل الشائعة

### خطأ CS8103: Combined length of user strings used by the program exceeds allowed limit

إذا واجهت هذا الخطأ، فهذا يعني أن النصوص المستخدمة في البرنامج تتجاوز الحد المسموح به. إليك الحلول:

#### 1. تقسيم النصوص الكبيرة
```csharp
// بدلاً من:
string bigString = "نص ضخم جداً يحتوي على مئات أو آلاف الأحرف...";

// استخدم:
string part1 = "الجزء الأول من النص...";
string part2 = "الجزء الثاني من النص...";
string part3 = "الجزء الثالث من النص...";
string bigString = part1 + part2 + part3;
```

#### 2. استخدام StringBuilder للنصوص الطويلة
```csharp
var sb = new StringBuilder();
sb.Append("الجزء الأول...");
sb.Append("الجزء الثاني...");
sb.Append("الجزء الثالث...");
string result = sb.ToString();
```

#### 3. نقل النصوص إلى ملفات منفصلة
```csharp
// نقل النصوص الكبيرة إلى ملفات .txt أو .json
string content = File.ReadAllText("path/to/large-text.txt");
```

#### 4. استخدام Resources
```csharp
// إضافة النصوص كـ Resources في المشروع
string content = Properties.Resources.LargeTextResource;
```

## الدعم
للحصول على الدعم، يرجى التواصل معنا عبر GitHub Issues.
