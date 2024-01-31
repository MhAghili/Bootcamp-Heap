using Testpr.Types;
using System.Text.Json;

List<Testpr.Types.Task> tasks = new();


// Read From Json:
string jsonContent = File.ReadAllText("Data/Task.json"); //using vscode,

var jsonTasks = JsonSerializer.Deserialize<List<JsonTask>>(jsonContent);
if (jsonTasks != null)
{
    foreach (var jsonTask in jsonTasks)
    {
        var task = new Testpr.Types.Task(jsonTask.Title, jsonTask.Description, jsonTask.DueDate, jsonTask.CompletedDate, jsonTask.Priority);
        tasks.Add(task);
    }
}


var maxHeap = tasks.ToHeap(new TaskPriorityComparer());     // ToHeap method:

Testpr.Types.Task topPriorityTask = maxHeap.GetMax();

Testpr.Types.Task lowestPriorityTask = maxHeap.GetMin();

Console.WriteLine($"Top task:  {topPriorityTask.Title}\nLowest task:  {lowestPriorityTask.Title}  ");





// ToHeap extention method:
public static class HeapLINQ
{
    public static Heap<T> ToHeap<T>(this IEnumerable<T> source, IComparer<T> comparer)
    {

        var heap = new Heap<T>(comparer);

        foreach (var item in source)
        {
            heap.Add(item);
        }

        return heap;
    }
}

