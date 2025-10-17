using System;
using System.IO;
using Inspinia.Tools;

namespace Inspinia.Tools
{
    /// <summary>
    /// برنامج لتشغيل أداة كشف النصوص الكبيرة
    /// </summary>
    public class RunStringDetector
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("🔍 أداة كشف النصوص الكبيرة - Glory77");
            Console.WriteLine("=====================================");
            Console.WriteLine();

            try
            {
                // الحصول على مسار المشروع
                var projectPath = GetProjectPath(args);
                Console.WriteLine($"📁 فحص المشروع: {projectPath}");
                Console.WriteLine();

                // إنشاء أداة الفحص
                var detector = new LargeStringDetector(
                    warningThreshold: 1000,  // تحذير للنصوص أكبر من 1000 حرف
                    errorThreshold: 5000     // خطأ للنصوص أكبر من 5000 حرف
                );

                // فحص المشروع
                Console.WriteLine("🔄 جاري فحص الملفات...");
                var results = detector.ScanProject(projectPath);

                // طباعة النتائج
                detector.PrintReport(results);

                // إنشاء تقرير
                var reportPath = Path.Combine(projectPath, "large-strings-report.md");
                detector.GenerateReport(results, reportPath);

                // اقتراحات للحل
                if (results.Count > 0)
                {
                    Console.WriteLine("💡 اقتراحات للحل:");
                    Console.WriteLine("1. استخدم StringHelper.CombineStrings() لتقسيم النصوص");
                    Console.WriteLine("2. انقل النصوص الكبيرة إلى ملفات منفصلة");
                    Console.WriteLine("3. استخدم Resources للنصوص الثابتة");
                    Console.WriteLine("4. استخدم StringBuilder للنصوص الديناميكية");
                    Console.WriteLine();
                    Console.WriteLine("📖 راجع README.md للمزيد من التفاصيل");
                }

                Console.WriteLine();
                Console.WriteLine("✅ انتهى الفحص بنجاح");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ خطأ: {ex.Message}");
                Console.WriteLine();
                Console.WriteLine("الاستخدام:");
                Console.WriteLine("  dotnet run --project Tools/RunStringDetector.cs [مسار المشروع]");
                Console.WriteLine();
                Console.WriteLine("إذا لم يتم تحديد مسار، سيتم استخدام المجلد الحالي");
            }
        }

        /// <summary>
        /// الحصول على مسار المشروع
        /// </summary>
        private static string GetProjectPath(string[] args)
        {
            if (args.Length > 0 && Directory.Exists(args[0]))
            {
                return Path.GetFullPath(args[0]);
            }

            // البحث عن ملف .csproj في المجلد الحالي أو المجلدات الأب
            var currentDir = Directory.GetCurrentDirectory();
            var searchDir = currentDir;

            for (int i = 0; i < 5; i++) // البحث في 5 مستويات كحد أقصى
            {
                var csprojFiles = Directory.GetFiles(searchDir, "*.csproj");
                if (csprojFiles.Length > 0)
                {
                    return searchDir;
                }

                var parentDir = Directory.GetParent(searchDir);
                if (parentDir == null)
                    break;

                searchDir = parentDir.FullName;
            }

            // إذا لم يتم العثور على ملف .csproj، استخدم المجلد الحالي
            return currentDir;
        }
    }
}
