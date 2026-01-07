using System;
using System.Collections.Generic;

namespace AppCoreV1.AsteronModels;

public partial class CsvdataFile
{
    public int Id { get; set; }

    public string? FilePath { get; set; }

    public string? FileName { get; set; }

    public string? TableName { get; set; }
}
