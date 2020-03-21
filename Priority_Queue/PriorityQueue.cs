using System;
using System.Collections.Generic;

class PriorityQueue<T>{
    private T[] list;
    public int Count;
    public System.Collections.Generic.Comparer<T> Comparer;

    public PriorityQueue(){
        list = new T[1024];
        Count = 0;
        Comparer = System.Collections.Generic.Comparer<T>.Default;
    }

    public bool IsEmpty(){
        return Count == 0;
    }

    public void Enqueue(T value){
        if(Count == list.Length){
            T[] tmp = new T[list.Length * 2];
            Array.Copy(list, tmp, list.Length);
            list = tmp;
        }
        list[Count++] = value;
        int i = Count - 1;
        while(i > 0 && Comparer.Comparer(list[i], list[parent(i)]) < 0){
            T tmp = list[i];
            list[i] = list[parent(i)];
            list[Parent(i)] = tmp;
            i = Parent(i);
        }
    }

    public T Dequeue(){
        T ret = list[0];
        list[0] = list[--Count];
        int i = 0;
        while(true){
            int left = (i*2)+1;
            if(left >= Count) break;
            int right = left+1;
            int ind = left;
            if(right < Count && Comparer.Compare(list[left], list[right]) > 0) ind = right;
            if(Comparer.Compare(list[i], list[ind]) >= 0){
                T tmp = list[i];
                list[i] = list[ind];
                list[ind] = tmp;
                i = ind;
            }
        }
        return ret;
    }

    private int Parent(int i){
        return (i-1)/2;
    }
}