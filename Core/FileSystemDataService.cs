using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core
{
    public class FileSystemDataService : IDataService
    {
        private const string DataFolderName = "Data";


        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly string _dataFolderPath;

        public FileSystemDataService()
        {
            _dataFolderPath = Path.Combine(Directory.GetCurrentDirectory(), DataFolderName);
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        public TData? LoadData<TData>(string dataName)
        {
            var dataFilePath = Path.Combine(_dataFolderPath, $"{dataName}.json");

            var rawFileContents = File.ReadAllText(dataFilePath);

            var fileContents = JsonSerializer.Deserialize<TData>(rawFileContents, _jsonSerializerOptions);

            return fileContents;
        }
    }
}
