using Aspose.Pdf;
using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            // Initialize license object
            Aspose.Pdf.License license = new Aspose.Pdf.License();
            // Set license
            license.SetLicense("Aspose.Pdf.lic");

            Console.WriteLine("Loading Document...");

            var pdfDocument = LoadDocument();

            var service = new HighlightService();

            Console.WriteLine("Highlighting...");

            var sw = new Stopwatch();
            sw.Start();
            var highlightCount = service.Highlight(pdfDocument, new System.Collections.Generic.List<string> { "lorem", "ip", "et", "ac" });
            sw.Stop();

            Console.WriteLine($"Finished highlighting '{highlightCount}' phrases");
            Console.WriteLine("Saving...");
            pdfDocument.Save(Path.Combine(Directory.GetCurrentDirectory(), "highlighted.pdf"));

            Console.WriteLine("====================");
            Console.WriteLine($"Highlighting took {sw.Elapsed.TotalSeconds} seconds");
        }

        private static Document LoadDocument()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "document.pdf");
            var pdf = new Document(path);

            return pdf;
        }
    }
}
