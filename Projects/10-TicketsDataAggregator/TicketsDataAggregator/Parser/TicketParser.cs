using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.Parser
{
    internal class TicketParser : ITicketParser
    {
        private readonly Dictionary<string, CultureInfo> CultureMapper = new Dictionary<string, CultureInfo>
        {
            ["com"] = new CultureInfo("en-US"),
            ["fr"] = new CultureInfo("fr-FR"),
            ["jp"] = new CultureInfo("ja-JP")
        };

        private readonly string[] stringSeperators = { "Title:", "Date:", "Time:", "Visit us:" };

        public void Parse(string ticketPdfText)
        {

            string[] splittedtext = ticketPdfText.Split(stringSeperators, StringSplitOptions.RemoveEmptyEntries);

            string webAdress = splittedtext.Last();
            CultureInfo culture = CultureMapper[webAdress.Split(".", StringSplitOptions.RemoveEmptyEntries).Last()];

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "parsed_tickets.txt");

            using StreamWriter writer = new(filePath, true); 
            
                for (int i = 1; i < splittedtext.Length - 1; i += 3)
                {
                    string title = splittedtext[i];
                    string date = splittedtext[i + 1];
                    string hour = splittedtext[i + 2];

                    DateOnly dateObj = DateOnly.Parse(date, culture);
                    TimeOnly timeObj = TimeOnly.Parse(hour, culture);

                   
                    string formattedTitle = title.PadRight(40);

                    
                    string formattedDate = dateObj.ToString(CultureInfo.InvariantCulture);
                    string formattedTime = timeObj.ToString(CultureInfo.InvariantCulture);

                    writer.WriteLine($"{formattedTitle} | {formattedDate} | {formattedTime}");
                }
            

        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
