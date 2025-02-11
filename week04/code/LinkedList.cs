using System;

public class LinkedList
{
    private Node? _head;
    private Node? _tail;

    private class Node
    {
        public int Value;
        public Node? Next;
        public Node? Prev;

        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    public void InsertHead(int value)
    {
        Node newNode = new(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    public void InsertTail(int value)
    {
        Node newNode = new(value);
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    public void RemoveHead()
    {
        if (_head is null) return;
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
            if (_head != null)
                _head.Prev = null;
        }
    }

    public void RemoveTail()
    {
        if (_tail is null) return;
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            if (_tail != null)
                _tail.Next = null;
        }
    }

    public void Remove(int value)
    {
        Node? current = _head;
        while (current != null)
        {
            if (current.Value == value)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;
                
                return;
            }
            current = current.Next;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        Node? current = _head;
        while (current != null)
        {
            if (current.Value == oldValue)
            {
                current.Value = newValue;
                return;
            }
            current = current.Next;
        }
    }

    public void Reverse()
    {
        Node? current = _head;
        Node? temp = null;
        
        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }
        
        if (temp != null)
            _head = temp.Prev;
    }

    public void PrintList()
    {
        Node? current = _head;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}
