using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingAndAsynchrony.Assigments
{
    internal class AwaitAsync
    {
        public async void Test()
        {
            string data = await DownloadDataAsync("test.com", "some content");
            Console.WriteLine(data);
        }

        public async Task<string> DownloadDataAsync(string Url, string content)
        {
            await Task.Delay(1000);
            return $"Content from URL '{Url}' is '{content}'";
        }
    }
}
