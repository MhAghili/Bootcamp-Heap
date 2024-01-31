namespace Testpr.Types;

public class Heap<T>
{
    private List<T> elements = new List<T>();
    private IComparer<T> comparer;

    public Heap(IComparer<T> comparer)
    {
        this.comparer = comparer;
    }

    public void Add(T element)
    {
        elements.Add(element);
        Heapify();
    }


    private void Heapify()
    {
        int index = elements.Count - 1;

        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (comparer.Compare(elements[index], elements[parentIndex]) > 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void Swap(int i, int j)
    {
        T temp = elements[i];
        elements[i] = elements[j];
        elements[j] = temp;
    }

    public T GetMax()
    {
        return elements.First();   // return task with highest priority
    }

    public T GetMin()
    {
        return elements.Last();           // return task with lowest priority
    }
}


