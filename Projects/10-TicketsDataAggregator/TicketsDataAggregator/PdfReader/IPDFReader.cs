using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.PdfReader
{
    internal interface IPDFReader
    {
        IEnumerable<string> GetTextFromFiles();
    }
}
