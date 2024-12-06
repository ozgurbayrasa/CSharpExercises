
using System.Diagnostics.Tracing;

namespace Coding.Exercise
{
    public class Exercise
    {
        public List<string> ProcessAll(List<string> words)
        {
            var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };

            List<string> result = words;
            foreach (var stringsProcessor in stringsProcessors)
            {
                result = stringsProcessor.Process(result);
            }
            return result;
        }

        public class StringsProcessor
        {
            public List<string> Process(List<string> words)
            {

                List<string> result = new List<string>();

                foreach (string word in words)
                {
                    result.Add(ProcessSingle(word));
                }

                return result;
            }

            protected virtual string ProcessSingle(string word)
            {
                return word;
            }
        }

        public class StringsTrimmingProcessor : StringsProcessor
        {
            protected override string ProcessSingle(string word)
            {
                int halfLength = word.Length / 2;
                return word.Substring(0, halfLength);
            }
        }

        public class StringsUppercaseProcessor : StringsProcessor
        {
            protected override string ProcessSingle(string word)
            {
                return word.ToUpper();
            }
        }
    }

    //your code goes here
}
