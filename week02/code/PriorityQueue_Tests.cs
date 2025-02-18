using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue<T>
{
    private List<(T Value, int Priority)> queue = new List<(T, int)>();

    public int Count => queue.Count;

    public void Enqueue(T value, int priority)
    {
        queue.Add((value, priority));
    }

    public T Dequeue()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the highest priority
        int highestPriority = queue.Max(item => item.Priority);

        // Find the first item with the highest priority (FIFO for ties)
        var index = queue.FindIndex(item => item.Priority == highestPriority);

        // Remove and return the item
        var item = queue[index];
        queue.RemoveAt(index);
        return item.Value;
    }
}
