using IntegrationApp.Models;
using System.Text.Json;
namespace IntegrationApp.Modules;
//Работа с файлами
public class StorageModule
{
    private const string FilePath = "requests.json";
    public List<Request> Load()
    {
        if (!File.Exists(FilePath))
            return new List<Request>();
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Request>>(json) ?? new List<Request>();
    }
    public void Save(List<Request> requests)
    {
        var json = JsonSerializer.Serialize(requests);
        File.WriteAllText(FilePath, json);
    }
}