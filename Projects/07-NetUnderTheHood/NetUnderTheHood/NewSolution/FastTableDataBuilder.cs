using System.Reflection;
using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<FastRow>();

        foreach (var row in csvData.Rows)
        {
            // Why all dictionaries stored as string-object pairs.
            // Value-types will be boxed which is memory and time waste.

            var newRowData = new FastRow();

            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];

                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                else if (valueAsString == "TRUE")
                {
                    newRowData.AssignCell(column,true);
                }
                else if (valueAsString == "FALSE")
                {
                    newRowData.AssignCell(column, false);
                }
                else if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                {
                    newRowData.AssignCell(column, valueAsDecimal);
                }
                else if (int.TryParse(valueAsString, out var valueAsInt))
                {
                    newRowData.AssignCell(column, valueAsInt);
                }
                else
                {
                    newRowData.AssignCell(column, valueAsString);
                }

            }

            resultRows.Add(newRowData);
        }

        return new FastTableData(csvData.Columns, resultRows);
    }

    private void ConvertValueToTargetTypeAndAssignToRowCell(string value, FastRow fastRow, string columnName)
    {
        
    }
}
