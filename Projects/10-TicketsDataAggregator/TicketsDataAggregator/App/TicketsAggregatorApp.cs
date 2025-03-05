using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDataAggregator.Parser;
using TicketsDataAggregator.PdfReader;
using TicketsDataAggregator.Providors;

namespace TicketsDataAggregator.App
{
    public class TicketsAggregatorApp
    {
        public void Run()
        {
            FileProvidor fileProvider = new FileProvidor("Tickets");

            string[] files = fileProvider.GetFilesFromDirectory();

            PDFReader pdfReader = new PDFReader(files);
            TicketParser ticketParser = new TicketParser();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "parsed_tickets.txt");

            File.WriteAllText(filePath, string.Empty);

            foreach (var pdfText in pdfReader.GetTextFromFiles())
            {
                ticketParser.Parse(pdfText);
            }

            Console.WriteLine("File Generated: " + filePath);
            Console.ReadKey();
        }

    }
}
