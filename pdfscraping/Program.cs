using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace pdfscraping
{
    class Program
    {
        public static string input;
        public static int StartPage = 1, EndPage, Pages = 84;
 
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        static void Main(string[] args)
        {
      
                do
            {
                Console.WriteLine("Enter Start page number: ");
                input = Console.ReadLine();
                StartPage = int.Parse(input);

                if (StartPage <= 72 || StartPage > Pages)
                {
                    Console.WriteLine("Invalid start page number");
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Enter End page number: ");
                        input = Console.ReadLine();
                        EndPage = int.Parse(input);

                        if (EndPage < StartPage || EndPage > Pages)
                        {
                            Console.WriteLine("Invalid End page number");
                        }
                    } while (EndPage < StartPage || EndPage > Pages);
                }
            } while (StartPage <= 0 || StartPage > Pages);

            Console.ReadLine();
            Console.ReadLine();

            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(@"C:\Users\user\Videos\pdfscraping\tender.pdf"))

                for (int i = StartPage; i < EndPage; i++)
            {
                var locationTextExtractionStrategy = new LocationTextExtractionStrategy();

                string textFromPage = PdfTextExtractor.GetTextFromPage(reader, i + 1, locationTextExtractionStrategy);

                textFromPage = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(textFromPage)));

                //Do Something with the text
                text.Append(PdfTextExtractor.GetTextFromPage(reader, i));

            }



            Console.WriteLine(text.ToString());
            Console.ReadLine();


        }
    }
}
