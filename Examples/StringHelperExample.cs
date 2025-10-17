using System;
using Inspinia.Helpers;

namespace Inspinia.Examples
{
    /// <summary>
    /// أمثلة على استخدام StringHelper لتجنب خطأ CS8103
    /// </summary>
    public class StringHelperExample
    {
        /// <summary>
        /// مثال على تقسيم نص كبير
        /// </summary>
        public void ExampleSplitLargeString()
        {
            // بدلاً من كتابة نص كبير في سطر واحد:
            // string largeText = "نص ضخم جداً يحتوي على آلاف الأحرف...";

            // استخدم التقسيم:
            string part1 = "هذا هو الجزء الأول من النص الكبير. ";
            string part2 = "وهذا هو الجزء الثاني الذي يحتوي على معلومات إضافية. ";
            string part3 = "والجزء الثالث يكمل المحتوى المطلوب. ";
            string part4 = "أخيراً، الجزء الرابع ينهي النص بشكل مناسب.";

            string combinedText = StringHelper.CombineStrings(part1, part2, part3, part4);
            
            Console.WriteLine($"طول النص المدموج: {combinedText.Length}");
        }

        /// <summary>
        /// مثال على بناء استعلام SQL كبير
        /// </summary>
        public void ExampleBuildLargeSqlQuery()
        {
            // بدلاً من:
            // string sql = "SELECT * FROM very_long_table_name WHERE condition1 = 'value1' AND condition2 = 'value2' AND condition3 = 'value3'...";

            // استخدم:
            string selectClause = "SELECT id, name, email, phone, address, city, country";
            string fromClause = "FROM customers";
            string whereClause = "WHERE status = 'active'";
            string andClause1 = "AND created_date >= '2023-01-01'";
            string andClause2 = "AND last_login IS NOT NULL";
            string orderClause = "ORDER BY created_date DESC";

            string sqlQuery = StringHelper.BuildSqlQuery(
                selectClause,
                fromClause,
                whereClause,
                andClause1,
                andClause2,
                orderClause
            );

            Console.WriteLine("استعلام SQL المبني:");
            Console.WriteLine(sqlQuery);
        }

        /// <summary>
        /// مثال على بناء HTML كبير
        /// </summary>
        public void ExampleBuildLargeHtml()
        {
            string htmlStart = "<div class='large-content'>";
            string htmlHeader = "<h1>عنوان المحتوى</h1>";
            string htmlParagraph1 = "<p>هذه فقرة تحتوي على محتوى مهم.</p>";
            string htmlParagraph2 = "<p>فقرة أخرى تحتوي على معلومات إضافية.</p>";
            string htmlList = "<ul><li>عنصر أول</li><li>عنصر ثاني</li><li>عنصر ثالث</li></ul>";
            string htmlEnd = "</div>";

            string htmlContent = StringHelper.BuildHtml(
                htmlStart,
                htmlHeader,
                htmlParagraph1,
                htmlParagraph2,
                htmlList,
                htmlEnd
            );

            Console.WriteLine("HTML المبني:");
            Console.WriteLine(htmlContent);
        }

        /// <summary>
        /// مثال على استخدام StringBuilder للنصوص الديناميكية
        /// </summary>
        public void ExampleUsingStringBuilder()
        {
            string dynamicContent = StringHelper.BuildLargeString(sb =>
            {
                sb.AppendLine("بداية المحتوى الديناميكي");
                
                for (int i = 1; i <= 100; i++)
                {
                    sb.AppendLine($"السطر رقم {i}: محتوى ديناميكي");
                }
                
                sb.AppendLine("نهاية المحتوى الديناميكي");
            });

            Console.WriteLine($"تم إنشاء محتوى ديناميكي بطول: {dynamicContent.Length} حرف");
        }

        /// <summary>
        /// مثال على فحص النصوص الكبيرة
        /// </summary>
        public void ExampleCheckLargeStrings()
        {
            string shortText = "نص قصير";

            // بدلاً من إنشاء نص كبير مباشرة، نستخدم طريقة أكثر أماناً
            string longText = StringHelper.BuildLargeString(sb => {
                for (int i = 0; i < 100; i++)
                {
                    sb.Append("هذا نص تجريبي للاختبار. ");
                }
            });

            if (StringHelper.IsLargeString(shortText))
            {
                Console.WriteLine("النص القصير كبير!");
            }
            else
            {
                Console.WriteLine("النص القصير ضمن الحد المقبول");
            }

            if (StringHelper.IsLargeString(longText))
            {
                Console.WriteLine("النص الطويل كبير - يُنصح بتقسيمه");

                var chunks = StringHelper.SplitIntoChunks(longText, 1000);
                Console.WriteLine($"تم تقسيم النص إلى {chunks.Count} جزء");
            }
        }

        /// <summary>
        /// مثال على تحميل النصوص من ملفات خارجية
        /// </summary>
        public void ExampleLoadFromFile()
        {
            try
            {
                // بدلاً من كتابة نص كبير في الكود:
                // string template = "قالب HTML ضخم جداً...";

                // استخدم ملف خارجي:
                string emailTemplate = StringHelper.LoadFromFile("Templates/email-template.html");
                string reportTemplate = StringHelper.LoadFromFile("Templates/report-template.html");

                Console.WriteLine("تم تحميل القوالب بنجاح");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطأ في تحميل الملفات: {ex.Message}");
            }
        }
    }
}
