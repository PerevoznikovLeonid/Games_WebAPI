using System.Text.Json;

namespace GamesWebAPI;

public static class StorageManager
{
    public static IEnumerable<T> ReadFromFile<T>(string path) where T: IEntity
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
            return new List<T>();
        }
        
        var fileText = File.ReadAllText(path);
        var objects = JsonSerializer.Deserialize<List<T>>(fileText);
        return objects ?? throw new JsonException("Error when deserializing from file.");
    }

    public static void WriteToFile<T>(IEnumerable<T> objects, string path) where T: IEntity
    {
        var json = JsonSerializer.Serialize(objects);
        File.WriteAllText(path, json);
    }
}