namespace ComplexDataModel.Office;

using ComplexDataModel.Core.Extensions;

public class OfficeConfig
{
    public string directory;

    public string Directory
    {
        get => directory;
        set
        {
            directory = value;
            Directory.EnsureDirectoryExists();
        }
    }
}