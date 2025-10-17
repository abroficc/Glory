# دليل نشر مشروع Glory77 - نسخة الإنتاج

## 🚀 المشروع جاهز للنشر!

تم تنظيف المشروع وإزالة جميع الملفات غير الضرورية. المشروع الآن يحتوي فقط على الملفات المطلوبة للنشر على خادم حقيقي.

## 📁 هيكل المشروع النهائي

```
Glory77/
├── Controllers/          # وحدات التحكم (100+ controller)
├── Views/               # واجهات المستخدم
├── Models/              # نماذج البيانات
├── Data/                # سياق قاعدة البيانات + PermissionsData.json
├── Services/            # خدمات التطبيق (PermissionsService)
├── Helpers/             # الوظائف المساعدة (StringHelper)
├── Hubs/                # SignalR Hubs
├── Migrations/          # ملفات الهجرة لقاعدة البيانات
├── Properties/          # إعدادات المشروع
├── wwwroot/             # الملفات الثابتة (CSS, JS, Images)
├── Program.cs           # نقطة دخول التطبيق
├── Inspinia.csproj      # ملف المشروع
├── appsettings.json     # إعدادات عامة
├── appsettings.Production.json  # إعدادات الإنتاج
├── README.md            # دليل المشروع
├── CHANGELOG.md         # سجل التغييرات
├── PROJECT_INFO.md      # معلومات المشروع
└── .gitignore           # ملفات Git المتجاهلة
```

## 🗑️ الملفات المحذوفة

تم حذف الملفات والمجلدات التالية لتنظيف المشروع:

### مجلدات البناء والتطوير:
- `bin/` - ملفات البناء
- `obj/` - ملفات الكائنات المؤقتة
- `node_modules/` - حزم Node.js

### أدوات التطوير:
- `Examples/` - أمثلة الكود
- `Tools/` - أدوات التطوير
- `Documentation/` - وثائق إضافية
- `CreateTableProgram/` - برنامج إنشاء الجداول
- `InsertSampleDataProgram/` - برنامج إدخال البيانات التجريبية
- `VerifyTablesProgram/` - برنامج التحقق من الجداول

### ملفات التطوير:
- `package.json` - إعدادات Node.js
- `yarn.lock` - قفل حزم Yarn
- `gulpfile.js` - إعدادات Gulp
- `bundle-files.js` - ملف تجميع الملفات
- `plugins.config.js` - إعدادات الإضافات
- `Inspinia.sln` - ملف الحل
- `*.user` - ملفات المستخدم
- `*.ps1` - ملفات PowerShell
- `*.sql` - ملفات SQL التطويرية
- `*.log` - ملفات السجلات
- `*.zip` - الملفات المضغوطة

### مجلدات CSS/JS التطويرية:
- `/css/` - ملفات CSS خارج wwwroot
- `/js/` - ملفات JavaScript خارج wwwroot

## 🔧 خطوات النشر

### 1. تحضير السيرفر
```bash
# تثبيت .NET 9.0 Runtime
sudo apt-get update
sudo apt-get install -y dotnet-runtime-9.0

# تثبيت MySQL
sudo apt-get install -y mysql-server
```

### 2. إعداد قاعدة البيانات
```sql
CREATE DATABASE glory77_production CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
CREATE USER 'glory77_user'@'localhost' IDENTIFIED BY 'STRONG_PASSWORD_HERE';
GRANT ALL PRIVILEGES ON glory77_production.* TO 'glory77_user'@'localhost';
FLUSH PRIVILEGES;
```

### 3. تحديث إعدادات الإنتاج
قم بتحديث `appsettings.Production.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=glory77_production;User=glory77_user;Password=YOUR_ACTUAL_PASSWORD;CharSet=utf8mb4;"
  }
}
```

### 4. رفع الملفات
```bash
# نسخ المشروع إلى السيرفر
scp -r Glory77/ user@server:/var/www/glory77/

# أو استخدام Git
git clone https://github.com/abroficc/Glory.git /var/www/glory77/
```

### 5. بناء المشروع
```bash
cd /var/www/glory77/
dotnet restore
dotnet build --configuration Release
```

### 6. تشغيل Migrations
```bash
dotnet ef database update --environment Production
```

### 7. تشغيل التطبيق
```bash
# للتشغيل المباشر
dotnet run --environment Production

# أو إنشاء خدمة systemd
sudo nano /etc/systemd/system/glory77.service
```

### ملف الخدمة (glory77.service):
```ini
[Unit]
Description=Glory77 ASP.NET Core App
After=network.target

[Service]
Type=notify
ExecStart=/usr/bin/dotnet /var/www/glory77/bin/Release/net9.0/Inspinia.dll
Restart=always
RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=glory77
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target
```

### 8. تفعيل الخدمة
```bash
sudo systemctl enable glory77.service
sudo systemctl start glory77.service
sudo systemctl status glory77.service
```

## 🔒 إعدادات الأمان

### 1. إعداد Nginx (Reverse Proxy)
```nginx
server {
    listen 80;
    server_name your-domain.com;
    return 301 https://$server_name$request_uri;
}

server {
    listen 443 ssl;
    server_name your-domain.com;
    
    ssl_certificate /path/to/certificate.crt;
    ssl_certificate_key /path/to/private.key;
    
    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }
}
```

### 2. إعداد Firewall
```bash
sudo ufw allow 22/tcp
sudo ufw allow 80/tcp
sudo ufw allow 443/tcp
sudo ufw enable
```

## 📊 المراقبة والصيانة

### 1. مراقبة السجلات
```bash
# مراقبة سجلات التطبيق
sudo journalctl -u glory77.service -f

# مراقبة سجلات Nginx
sudo tail -f /var/log/nginx/access.log
sudo tail -f /var/log/nginx/error.log
```

### 2. النسخ الاحتياطية
```bash
# نسخة احتياطية لقاعدة البيانات
mysqldump -u glory77_user -p glory77_production > backup_$(date +%Y%m%d).sql

# نسخة احتياطية للملفات المرفوعة
tar -czf uploads_backup_$(date +%Y%m%d).tar.gz /var/www/glory77/wwwroot/uploads/
```

## ✅ التحقق من النشر

### 1. فحص الحالة
```bash
# حالة الخدمة
sudo systemctl status glory77.service

# فحص المنافذ
sudo netstat -tlnp | grep :5000

# فحص العمليات
ps aux | grep dotnet
```

### 2. اختبار التطبيق
- افتح المتصفح وانتقل إلى عنوان السيرفر
- تحقق من تسجيل الدخول
- اختبر الوظائف الأساسية

## 🆘 استكشاف الأخطاء

### مشاكل شائعة:

#### 1. خطأ اتصال قاعدة البيانات
```bash
# تحقق من حالة MySQL
sudo systemctl status mysql

# تحقق من المستخدم والصلاحيات
mysql -u glory77_user -p
```

#### 2. خطأ في الأذونات
```bash
# إعطاء الأذونات الصحيحة
sudo chown -R www-data:www-data /var/www/glory77/
sudo chmod -R 755 /var/www/glory77/
```

#### 3. مشاكل الذاكرة
```bash
# مراقبة استخدام الذاكرة
free -h
top -p $(pgrep dotnet)
```

---

**المشروع الآن جاهز للنشر على خادم الإنتاج! 🎉**

**تاريخ التحديث**: 2025-01-17  
**الإصدار**: Production Ready v1.0  
**حالة CS8103**: ✅ محلولة نهائياً
