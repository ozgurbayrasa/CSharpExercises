using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.Providors
{
    public class FileProvidor : IFileProvider
    {
        private readonly string  _directoryName;

        public FileProvidor(string directoryName)
        {
            _directoryName = directoryName;
        }

        public string[] GetFilesFromDirectory()
        {
            string[] fileEntries = Directory.GetFiles(_directoryName);
            return fileEntries;
        }
    }
}
