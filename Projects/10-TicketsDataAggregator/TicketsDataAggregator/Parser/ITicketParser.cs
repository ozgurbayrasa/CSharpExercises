using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.Parser
{
    internal interface ITicketParser
    {
        void Parse(string ticketPdfText);
        void Print();
    }
}
