using System.IO;

namespace GlobalHelpers
{
    public static class ConfigureDictionaries
    {
       private const string DataDirectory =
           @"C:\FNCL\DataFiles\";

       private const string TOP_SIMULTATION_DIRECTORY = @"C:\FNCL\Simulations\";

        private const string DATA_DIRECTORY_NAME = "DataFiles";
        private const string SIMULTATIONS_DIRECTORY = "Simulations";
        private static string dataDirectory;

        static ConfigureDictionaries()
        {
        }

        public static void
            InitializeDictionaries()
        {
            dataDirectory = SetDataDirectory();
            ConfigureMaterials(GetFullPath(Materials.DEFAULT_FILE), GetFullPath(Materials.USER_FILE));
            ConfigureFuelSpecifications(GetFullPath(FuelAssembly.DEFAULT_FILE));
        }

        private static string SetDataDirectory()
        {
#if DEBUG
            return DataDirectory;
#else
            //DirectoryInfo parentDir = Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            return  Path.Combine(GetTopInstallDirectory(), DATA_DIRECTORY_NAME);
#endif
        }

        private static string GetTopInstallDirectory()
        {
            DirectoryInfo parentDir = Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            return parentDir.FullName;
        }

        private static void ConfigureMaterials(string materialsFile, string userMaterialFile)
        {
            MaterialManager.InitializeDictionary(materialsFile, userMaterialFile);
        }

        private static void ConfigureFuelSpecifications(string fuelFile)
        {
            FuelAssemblyManager.InitializeDictionary(fuelFile);
        }

        private static string GetFullPath(string file)
        {
            return Path.Combine(dataDirectory, file);
        }

        public static string GetStartingMcnpSaveDir()
        {
#if DEBUG
            return TOP_SIMULTATION_DIRECTORY;
#else
            return Path.Combine(GetTopInstallDirectory(), SIMULTATIONS_DIRECTORY);
#endif
        }

        public static string GetDataDirectory()
        {
            return dataDirectory;
        }
    }
}
