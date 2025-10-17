using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Inspinia.Tools
{
    /// <summary>
    /// أداة للكشف عن النصوص الكبيرة في المشروع التي قد تسبب خطأ CS8103
    /// </summary>
    public class LargeStringDetector
    {
        private readonly int _warningThreshold;
        private readonly int _errorThreshold;
        
        public LargeStringDetector(int warningThreshold = 1000, int errorThreshold = 5000)
        {
            _warningThreshold = warningThreshold;
            _errorThreshold = errorThreshold;
        }

        /// <summary>
        /// فحص مجلد المشروع للبحث عن النصوص الكبيرة
        /// </summary>
        /// <param name="projectPath">مسار المشروع</param>
        /// <returns>قائمة بالملفات التي تحتوي على نصوص كبيرة</returns>
        public List<LargeStringResult> ScanProject(string projectPath)
        {
            var results = new List<LargeStringResult>();
            
            // البحث في ملفات C#
            var csFiles = Directory.GetFiles(projectPath, "*.cs", SearchOption.AllDirectories)
                .Where(f => !f.Contains("\\bin\\") && !f.Contains("\\obj\\") && !f.Contains("\\node_modules\\"))
                .ToArray();

            foreach (var file in csFiles)
            {
                try
                {
                    var fileResults = ScanFile(file);
                    results.AddRange(fileResults);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"خطأ في فحص الملف {file}: {ex.Message}");
                }
            }

            return results;
        }

        /// <summary>
        /// فحص ملف واحد للبحث عن النصوص الكبيرة
        /// </summary>
        /// <param name="filePath">مسار الملف</param>
        /// <returns>قائمة بالنصوص الكبيرة في الملف</returns>
        public List<LargeStringResult> ScanFile(string filePath)
        {
            var results = new List<LargeStringResult>();
            var content = File.ReadAllText(filePath);
            var lines = File.ReadAllLines(filePath);

            // البحث عن النصوص المحاطة بعلامات اقتباس
            var stringPattern = @"""([^""\\]|\\.)*""";
            var matches = Regex.Matches(content, stringPattern, RegexOptions.Multiline);

            foreach (Match match in matches)
            {
                var stringValue = match.Value;
                var length = stringValue.Length - 2; // طرح علامتي الاقتباس

                if (length >= _warningThreshold)
                {
                    var lineNumber = GetLineNumber(content, match.Index);
                    var severity = length >= _errorThreshold ? Severity.Error : Severity.Warning;
                    
                    results.Add(new LargeStringResult
                    {
                        FilePath = filePath,
                        LineNumber = lineNumber,
                        StringLength = length,
                        StringPreview = GetStringPreview(stringValue),
                        Severity = severity,
                        Suggestion = GetSuggestion(length)
                    });
                }
            }

            // البحث عن نصوص متعددة الأسطر
            var multilinePattern = @"@""([^""]|"""")*""";
            var multilineMatches = Regex.Matches(content, multilinePattern, RegexOptions.Multiline | RegexOptions.Singleline);

            foreach (Match match in multilineMatches)
            {
                var stringValue = match.Value;
                var length = stringValue.Length - 3; // طرح @""

                if (length >= _warningThreshold)
                {
                    var lineNumber = GetLineNumber(content, match.Index);
                    var severity = length >= _errorThreshold ? Severity.Error : Severity.Warning;
                    
                    results.Add(new LargeStringResult
                    {
                        FilePath = filePath,
                        LineNumber = lineNumber,
                        StringLength = length,
                        StringPreview = GetStringPreview(stringValue),
                        Severity = severity,
                        Suggestion = GetSuggestion(length)
                    });
                }
            }

            return results;
        }

        /// <summary>
        /// الحصول على رقم السطر من موضع في النص
        /// </summary>
        private int GetLineNumber(string content, int position)
        {
            return content.Take(position).Count(c => c == '\n') + 1;
        }

        /// <summary>
        /// الحصول على معاينة للنص
        /// </summary>
        private string GetStringPreview(string fullString)
        {
            const int previewLength = 100;
            if (fullString.Length <= previewLength)
                return fullString;
            
            return fullString.Substring(0, previewLength) + "...";
        }

        /// <summary>
        /// الحصول على اقتراح لحل المشكلة
        /// </summary>
        private string GetSuggestion(int length)
        {
            if (length < 2000)
                return "يُنصح بتقسيم النص إلى أجزاء أصغر باستخدام StringHelper.CombineStrings()";
            else if (length < 5000)
                return "يجب تقسيم النص إلى أجزاء أو نقله إلى ملف منفصل باستخدام StringHelper.LoadFromFile()";
            else
                return "يجب نقل النص إلى ملف منفصل أو استخدام Resources - النص كبير جداً";
        }

        /// <summary>
        /// طباعة تقرير النتائج
        /// </summary>
        public void PrintReport(List<LargeStringResult> results)
        {
            if (!results.Any())
            {
                Console.WriteLine("✅ لم يتم العثور على نصوص كبيرة في المشروع");
                return;
            }

            Console.WriteLine($"🔍 تم العثور على {results.Count} نص كبير:");
            Console.WriteLine();

            var groupedResults = results.GroupBy(r => r.Severity);

            foreach (var group in groupedResults)
            {
                var icon = group.Key == Severity.Error ? "❌" : "⚠️";
                var severityName = group.Key == Severity.Error ? "خطأ" : "تحذير";
                
                Console.WriteLine($"{icon} {severityName} ({group.Count()} ملف):");
                
                foreach (var result in group.OrderBy(r => r.FilePath).ThenBy(r => r.LineNumber))
                {
                    Console.WriteLine($"  📁 {Path.GetFileName(result.FilePath)}:{result.LineNumber}");
                    Console.WriteLine($"     📏 الطول: {result.StringLength} حرف");
                    Console.WriteLine($"     💡 الاقتراح: {result.Suggestion}");
                    Console.WriteLine($"     👀 المعاينة: {result.StringPreview}");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// إنشاء ملف تقرير
        /// </summary>
        public void GenerateReport(List<LargeStringResult> results, string outputPath)
        {
            var report = new System.Text.StringBuilder();
            report.AppendLine("# تقرير النصوص الكبيرة - Glory77");
            report.AppendLine($"تاريخ الفحص: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            report.AppendLine();

            if (!results.Any())
            {
                report.AppendLine("✅ لم يتم العثور على نصوص كبيرة في المشروع");
            }
            else
            {
                report.AppendLine($"🔍 تم العثور على {results.Count} نص كبير:");
                report.AppendLine();

                var errors = results.Where(r => r.Severity == Severity.Error).ToList();
                var warnings = results.Where(r => r.Severity == Severity.Warning).ToList();

                if (errors.Any())
                {
                    report.AppendLine($"## ❌ أخطاء ({errors.Count})");
                    foreach (var error in errors)
                    {
                        report.AppendLine($"- **{Path.GetFileName(error.FilePath)}:{error.LineNumber}** - {error.StringLength} حرف");
                        report.AppendLine($"  - الاقتراح: {error.Suggestion}");
                        report.AppendLine();
                    }
                }

                if (warnings.Any())
                {
                    report.AppendLine($"## ⚠️ تحذيرات ({warnings.Count})");
                    foreach (var warning in warnings)
                    {
                        report.AppendLine($"- **{Path.GetFileName(warning.FilePath)}:{warning.LineNumber}** - {warning.StringLength} حرف");
                        report.AppendLine($"  - الاقتراح: {warning.Suggestion}");
                        report.AppendLine();
                    }
                }
            }

            File.WriteAllText(outputPath, report.ToString());
            Console.WriteLine($"📄 تم حفظ التقرير في: {outputPath}");
        }
    }

    /// <summary>
    /// نتيجة فحص نص كبير
    /// </summary>
    public class LargeStringResult
    {
        public string FilePath { get; set; }
        public int LineNumber { get; set; }
        public int StringLength { get; set; }
        public string StringPreview { get; set; }
        public Severity Severity { get; set; }
        public string Suggestion { get; set; }
    }

    /// <summary>
    /// مستوى الخطورة
    /// </summary>
    public enum Severity
    {
        Warning,
        Error
    }
}
