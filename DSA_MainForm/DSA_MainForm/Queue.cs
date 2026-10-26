using System.Collections;

namespace DSA_MainForm;

public class Queue
{

    private ArrayList _list = new ArrayList();
    private int _front;
    private int _rear;

    public Queue()
    {
    }



    public bool isEmpty()
    {
        return _list.Count == 0;
    }

    public int Peek()
    {
        _front =(int) _list[0];
        return _front;
    }

    public void enqueue(int item)
    {

        _list.Add(item);

    }

    public int getRear()
    {
        _rear = (int)_list[_list.Count - 1];
        return _rear;
    }

    public void dequeue()
    {

        _list.RemoveAt(0);

    }

    public int[] Display()
    {
        int[] arr =(int[]) _list.ToArray(typeof(int));

        return arr;
    }

}
