using System;
using System.Collections.Generic;
using System.Text;

namespace Inspinia.Helpers
{
    /// <summary>
    /// مساعد للتعامل مع النصوص الكبيرة وتجنب خطأ CS8103
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// دمج عدة نصوص في نص واحد
        /// </summary>
        /// <param name="parts">أجزاء النص المراد دمجها</param>
        /// <returns>النص المدموج</returns>
        public static string CombineStrings(params string[] parts)
        {
            if (parts == null || parts.Length == 0)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var part in parts)
            {
                if (!string.IsNullOrEmpty(part))
                    sb.Append(part);
            }
            return sb.ToString();
        }

        /// <summary>
        /// دمج عدة نصوص مع فاصل
        /// </summary>
        /// <param name="separator">الفاصل بين النصوص</param>
        /// <param name="parts">أجزاء النص المراد دمجها</param>
        /// <returns>النص المدموج مع الفواصل</returns>
        public static string CombineStringsWithSeparator(string separator, params string[] parts)
        {
            if (parts == null || parts.Length == 0)
                return string.Empty;

            return string.Join(separator, parts);
        }

        /// <summary>
        /// تقسيم نص كبير إلى أجزاء أصغر
        /// </summary>
        /// <param name="text">النص المراد تقسيمه</param>
        /// <param name="chunkSize">حجم كل جزء</param>
        /// <returns>قائمة بأجزاء النص</returns>
        public static List<string> SplitIntoChunks(string text, int chunkSize = 1000)
        {
            var chunks = new List<string>();
            
            if (string.IsNullOrEmpty(text))
                return chunks;

            for (int i = 0; i < text.Length; i += chunkSize)
            {
                int length = Math.Min(chunkSize, text.Length - i);
                chunks.Add(text.Substring(i, length));
            }

            return chunks;
        }

        /// <summary>
        /// بناء نص كبير باستخدام StringBuilder
        /// </summary>
        /// <param name="builderAction">الإجراء لبناء النص</param>
        /// <returns>النص المبني</returns>
        public static string BuildLargeString(Action<StringBuilder> builderAction)
        {
            var sb = new StringBuilder();
            builderAction?.Invoke(sb);
            return sb.ToString();
        }

        /// <summary>
        /// تحميل نص من ملف خارجي
        /// </summary>
        /// <param name="filePath">مسار الملف</param>
        /// <returns>محتوى الملف</returns>
        public static string LoadFromFile(string filePath)
        {
            try
            {
                return System.IO.File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                // يمكن إضافة logging هنا
                throw new InvalidOperationException($"فشل في تحميل الملف: {filePath}", ex);
            }
        }

        /// <summary>
        /// حفظ نص كبير في ملف
        /// </summary>
        /// <param name="content">المحتوى المراد حفظه</param>
        /// <param name="filePath">مسار الملف</param>
        public static void SaveToFile(string content, string filePath)
        {
            try
            {
                System.IO.File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"فشل في حفظ الملف: {filePath}", ex);
            }
        }

        /// <summary>
        /// فحص طول النص والتحذير إذا كان كبيراً
        /// </summary>
        /// <param name="text">النص المراد فحصه</param>
        /// <param name="warningThreshold">حد التحذير (افتراضي: 10000 حرف)</param>
        /// <returns>true إذا كان النص كبيراً</returns>
        public static bool IsLargeString(string text, int warningThreshold = 10000)
        {
            return !string.IsNullOrEmpty(text) && text.Length > warningThreshold;
        }

        /// <summary>
        /// تنسيق نص SQL كبير
        /// </summary>
        /// <param name="sqlParts">أجزاء استعلام SQL</param>
        /// <returns>استعلام SQL مدموج</returns>
        public static string BuildSqlQuery(params string[] sqlParts)
        {
            return CombineStringsWithSeparator(" ", sqlParts);
        }

        /// <summary>
        /// بناء HTML كبير
        /// </summary>
        /// <param name="htmlParts">أجزاء HTML</param>
        /// <returns>HTML مدموج</returns>
        public static string BuildHtml(params string[] htmlParts)
        {
            return CombineStrings(htmlParts);
        }
    }
}
