using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ExercisesDotNet
{
    public class AllLinesFromTextFileReader : IDisposable 
    {
        private readonly StreamReader _streamReader;

        public AllLinesFromTextFileReader(string filePath)
        {
            _streamReader =  new StreamReader(filePath);
        }

        public List<string> ReadAllLines()
        {
            var result = new List<string>();
            while (!_streamReader.EndOfStream)
            {
                result.Add(_streamReader.ReadLine());
            }

            return result;
        }

        public void Dispose()
        {
            _streamReader.Dispose();
        }
    }
}
