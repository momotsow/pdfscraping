using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace pdfscraping
{
    class Program
    {
        private static string line;

        //public static object PdfTextExtractor { get; private set; }

        static void Main(string[] args)
        {
            //StreamReader sr = new StreamReader(@"C:\Users\user\Videos\pdfscraping\tender.pdf");

            //line = sr.ReadLine();

            //while (line != null)
            //{
            //    Console.WriteLine(line);
            //    line = sr.ReadLine();
            //}

            try
            {
                StringBuilder text = new StringBuilder();
                //PdfReader pr = new PdfReader(@"C:\Users\user\Videos\pdfscraping\tender.pdf");
                using (PdfReader reader = new PdfReader(@"C:\Users\user\Videos\pdfscraping\tender.pdf"))
                {
                    for (int i = 73; i <= reader.NumberOfPages; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                }
                Console.WriteLine(text.ToString());
            }

            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Console.Read();
                
        }
    }
}
