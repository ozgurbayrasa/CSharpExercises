namespace DotNet
{
    public class CSVReaderd
    {
        public CSVData Read(string path)
        {
            using var reader = new StreamReader(path);

            const string Seperator = ",";
            var columns = reader.ReadLine().Split(Seperator);

            var rows = new List<string[]>();
            
            while (!reader.EndOfStream)
            {
                string[] cellsInRow = reader.ReadLine().Split(Seperator);
                rows.Add(cellsInRow);
            }

            return new CSVData(columns, rows);
        }
    }

    public class CSVData
    {
        public string[] Columns { get; }
        public IEnumerable<string[]> Rows { get; }

        public CSVData(string[] columns, IEnumerable<string[]> rows)
        {
            Columns = columns;
            Rows = rows;
        }
    }
}
