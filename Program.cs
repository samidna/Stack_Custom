using System.Collections;

Stack<int> stack = new Stack<int>();
//Console.WriteLine(stack.Peek());
//stack.Push(1);
//stack.Push(2);
//stack.Push(3);
//stack.Push(4);
//stack.Pop();
//foreach (int item in stack)
//{
//    Console.WriteLine(item);
//}
int[] arr = { 1, 2, 3, 4, 5, 6 };
MyStack<int> ms = new MyStack<int>();
//ms.Push(1);
//ms.Push(2);
//ms.Push(3);
//ms.Push(4);
//ms.Push(5);
//Console.WriteLine(ms.Capacity);
//Console.WriteLine(ms.Count);
//Console.WriteLine(ms.Pop());
foreach (var item in ms)
{
    Console.WriteLine(item);
}
//Console.WriteLine(ms.Peek());





class MyStack<T> : IEnumerable
{
    private T[] _arr;
    public int Count { get; private set; }
    private int Capacity { get; set; }

    public MyStack()
    {
        Capacity = 0;
        _arr = new T[Capacity];
    }
    public MyStack(int capacity)
    {
        Capacity = capacity;
        _arr = new T[Capacity];
    }
    public MyStack(ICollection collection)
    {
        Capacity = collection.Count;
        Count = Capacity;
        _arr = new T[Capacity];
        collection.CopyTo(_arr, 0);
    }
    public void Push(T item)
    {
        if (Capacity == 0)
        {
            Capacity = 4;
            Array.Resize(ref _arr, Capacity);
        }
        else if (Capacity == Count)
        {
            Capacity *= 2;
            Array.Resize(ref _arr, Capacity);
        }
        _arr[Count] = item;
        Count++;
    }
    public T Pop()
    {
        T item = _arr[Count-1];
        Count--;
        return item;
    }
    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _arr[Count - 1];
    }
    public IEnumerator GetEnumerator()
    {
        for (int i = Count-1; i >= 0; i--)
        {
            yield return _arr[i];
        }
    }
}
