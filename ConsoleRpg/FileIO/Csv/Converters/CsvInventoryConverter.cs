using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ConsoleRpg.Services.DataHelpers;

namespace ConsoleRpg.FileIO.Csv.Converters;

// The CsvInventoryConverter is used to turn the inventory string into an Inventories Object automatically.
[Obsolete]
public class CsvInventoryConverter : DefaultTypeConverter
{
    [Obsolete]
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        return InventorySerializer.Deserialize(text!);
    }
}
