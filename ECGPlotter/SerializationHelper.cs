using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ECGPlotter;

//
//  var exampleObject = new ExampleClass { Id = 1, Name = "Example" };
//
//  // 序列化
//  var jsonString = SerializationHelper.Serialize(exampleObject);
//  Console.WriteLine("Serialized: " + jsonString);
//
//  // 反序列化
//  var deserializedObject = SerializationHelper.Deserialize<ExampleClass>(jsonString);
//  Console.WriteLine($"Deserialized: Id={deserializedObject.Id}, Name={deserializedObject.Name}");
//
public static class SerializationHelper
{
    // 序列化方法：将对象转换为JSON字符串
    private static JsonSerializerOptions _options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        // DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        // IgnoreReadOnlyProperties = true,
        // WriteIndented = true
    };

    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, _options);
    }

    public static string Serialize<T>(T obj, JsonSerializerOptions options)
    {
         return JsonSerializer.Serialize(obj, options);
    }

    public static string Serialize<T>(T obj, string jsonFile)
    {
        string json= JsonSerializer.Serialize(obj, _options);
        File.WriteAllText(jsonFile, json);

        return json;
    }

    public static string Serialize<T>(T obj, string jsonFile, JsonSerializerOptions options)
    {
        string json = JsonSerializer.Serialize(obj, options);
        File.WriteAllText(jsonFile, json);

        return json;
    }

    // 反序列化方法：将JSON字符串转换回对象
    public static T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json)!;
    }

    public static T DeserializeFromFile<T>(string jsonFile)
    {
        string json = File.ReadAllText(jsonFile);
        return JsonSerializer.Deserialize<T>(json)!;
    }
}

//泛型
//      var helper = new SerializationHelper<ExampleClass>();
//      var exampleObject = new ExampleClass { Id = 1, Name = "Example" };
//
//      // 序列化
//      var jsonString = helper.Serialize(exampleObject);
//      Console.WriteLine("Serialized: " + jsonString);
//
//      // 反序列化
//      var deserializedObject = helper.Deserialize(jsonString);
//      Console.WriteLine($"Deserialized: Id={deserializedObject.Id}, Name={deserializedObject.Name}");
public class DeSerializer<T>
{
    // 序列化方法：将对象转换为JSON字符串
    private static JsonSerializerOptions _options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        // DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        // IgnoreReadOnlyProperties = true,
        // WriteIndented = true
    };

    public string Serialize(T obj)
    {
        return JsonSerializer.Serialize(obj, _options);
    }

    public string Serialize(T obj, JsonSerializerOptions options)
    {
        return JsonSerializer.Serialize(obj, options);
    }

    public string Serialize(T obj, string jsonFile)
    {
        string json = JsonSerializer.Serialize(obj, _options);
        File.WriteAllText(jsonFile, json);

        return json;
    }

    public string Serialize(T obj, string jsonFile, JsonSerializerOptions options)
    {
        string json = JsonSerializer.Serialize(obj, options);
        File.WriteAllText(jsonFile, json);

        return json;
    }

    // 反序列化方法：将JSON字符串转换回对象
    public T Deserialize(string json)
    {
        return JsonSerializer.Deserialize<T>(json)!;
    }

    public T DeserializeFromFile(string jsonFile)
    {
        string json = File.ReadAllText(jsonFile);
        return JsonSerializer.Deserialize<T>(json)!;
    }

}
