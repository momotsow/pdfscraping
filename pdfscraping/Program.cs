using System;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace pdfscraping
{
    class Program
    {
        public static int endPage;
        public static int startPage = 1;
        public static int pages = 84;
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(@"C:\Users\user\Videos\pdfscraping\tender.pdf"))

                do
                {
                    Console.WriteLine("Enter your start page: ");
                    int startPage = Convert.ToInt32(Console.ReadLine());

                    if (startPage <= 73 || startPage > pages)
                    {
                        Console.WriteLine("Your start page is not valid ");
                    }
                    else
                    {
                            Console.WriteLine("Enter your end page: ");
                            int endPage = Convert.ToInt32(Console.ReadLine());

                            if (endPage < startPage || endPage > pages)
                            {
                                Console.WriteLine("Your end page is not valid ");
                            }
                            else
                            {
                                for (int i = startPage; i < endPage; i++)
                                {
                                    var locationTextExtractionStrategy = new LocationTextExtractionStrategy();

                                    string textFromPage = PdfTextExtractor.GetTextFromPage(reader, i + 1, locationTextExtractionStrategy);

                                    textFromPage = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(textFromPage)));

                                    //Do Something with the text
                                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                                }
                                Console.WriteLine(text.ToString());
                            }
                        
                    }

                }
                while (startPage <= 0 || startPage > pages);

            
            /////////////////////////////////////////////////////////////////WORKS/////////////////////////////////////////////////////////////////////////////////
            //try
            //{
            //    StringBuilder text = new StringBuilder();
            //    using (PdfReader reader = new PdfReader(@"C:\Users\user\Videos\pdfscraping\tender.pdf"))
            //    {
            //        for (int i = 73; i <= reader.NumberOfPages; i++)
            //        {
            //            text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
            //        }
            //    }
            //    Console.WriteLine(text.ToString());

            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine("The file could not be read ");
            //    Console.WriteLine(e.Message);
            //}

            //Console.Read();

            //////////////////////////////////////////////////////WORKS////////////////////////////////////////////////////////////////////////////////////////

        }
    }
}
