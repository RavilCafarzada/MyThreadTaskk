using ConsoleApp6;
using Newtonsoft.Json;

    string path = "https://jsonplaceholder.typicode.com/posts";
    var response = await GetInfoAsync(path);

    // Convert to objects
    var myDatas = JsonConvert.DeserializeObject<MyData[]>(response);

    // Specify the IDs
    var specifiedIds = new List<int> { 1, 10, 100 };

    // Filtered the specified IDs
    var filteredObjects = myDatas.Where(obj => specifiedIds.Contains(obj.Id)).ToList();

    string filePath = "mydata.json";

    File.WriteAllText(filePath, JsonConvert.SerializeObject(filteredObjects, Formatting.Indented));

    Console.WriteLine($"Filtered objects with specified IDs have been written to {filePath}");


static async Task<string> GetInfoAsync(string path)
{
    using (HttpClient client = new HttpClient())
    {
        string result = await client.GetStringAsync(path);
        return result;
    }
}
