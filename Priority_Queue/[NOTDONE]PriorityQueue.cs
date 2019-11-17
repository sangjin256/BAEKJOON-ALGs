using System;
using System.IO;
using System.Collections.Generic;

public class PriorityQueue<T> : IEnumerable<T>
{
    private List<T> data;
    public int Count{
        get{
            return data.Count;
        }
    }

    public PriorityQueue(){
        this.data = new List<T>();
    }

    public void Enqueue(T item){
        data.Add(item);
        data.Sort((x,y) => y.Item1.CompareTo(x.Item1));
    }

    public T Dequeue(){
        T value = data[0];
        data.RemoveAt(0);
        return value;
    }

    public IEnumerable<T> GetEnumerator(){
        return data.GetEnumerator();
    }

    IEnumerable IEnumerable.GetEnumerator(){
        return GetEnumerator();
    }

}
