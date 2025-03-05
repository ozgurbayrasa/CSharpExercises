using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;
using System.Collections;

namespace TicketsDataAggregator.PdfReader
{
    internal class PDFReader : IPDFReader
    {
        private IEnumerable<string> _fileNames;

        public PDFReader(IEnumerable<string> fileNames)
        {
            _fileNames = fileNames;
        }

        public IEnumerable<string> GetTextFromFiles()
        {
            foreach (var fileName in _fileNames)
            {
                foreach (var text in GetTextOfPdfFile(fileName))
                {
                    yield return text;
                }
            }
        }

        private IEnumerable<string> GetTextOfPdfFile(string fileName)
        {
            using PdfDocument document = PdfDocument.Open(fileName);
            foreach (Page page in document.GetPages())
            {
                yield return page.Text;
            }
        }
    }
}
