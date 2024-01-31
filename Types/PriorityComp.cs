namespace Testpr.Types;

class TaskPriorityComparer : IComparer<Task?>
{
    public int Compare(Task? x, Task? y)
    {
        if (x == null || y == null)
            return 0;
        return ((int)y.Priority).CompareTo((int)x.Priority);
    }
}


