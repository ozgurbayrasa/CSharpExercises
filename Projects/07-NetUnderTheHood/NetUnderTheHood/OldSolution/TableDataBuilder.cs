using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace CsvDataAccess.OldSolution;

public class TableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<Row>();

        foreach (var row in csvData.Rows)
        {
            // Why all dictionaries stored as string-object pairs.
            // Value-types will be boxed which is memory and time waste.
            var newRowData = new Dictionary<string, object>();

            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];
                // Memory waste when null is returned (we have many nulls)
                // Why do we create a space for them?
                newRowData[column] = ConvertValueToTargetType(valueAsString);
            }

            resultRows.Add(new Row(newRowData));
        }

        return new TableData(csvData.Columns, resultRows);
    }

    private object ConvertValueToTargetType(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        if (value == "TRUE")
        {
            return true;
        }
        if (value == "FALSE")
        {
            return false;
        }
        if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal))
        {
            return valueAsDecimal;
        }
        if (int.TryParse(value, out var valueAsInt))
        {
            return valueAsInt;
        }
        return value;
    }
}