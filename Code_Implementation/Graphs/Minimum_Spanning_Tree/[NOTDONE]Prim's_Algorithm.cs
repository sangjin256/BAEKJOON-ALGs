//우선순위 큐를 이용해야함
using System;
using System.Collections.Generic;

class PriorityQueue<T>{
    private T[] list;
    public int Count;
    public System.Collections.Generic.Comparer Comparer;
    public PriorityQueue(){
        list = new T[1024];
        Count = 0;
        Comparer = System.Collections.Comparer.Default;
    }

    public bool IsEmpty(){
        return Count == 0;
    }

    public void Push(T data){
        if(Count == list.Length){
            T[] tmp = new T[list.Length*2];
            Array.Copy(list, tmp, list.Length);
            list = tmp;
        }

        list[Count++] = data;
        int i = Count - 1;
        while(i > 0 && Comparer.Comparer(list[i], list[Parent(i)]) < 0){
            T tmp = list[i];
            list[i] = list[Parent(i)];
            list[Parent(i)] = tmp;
            i = Parent(i);
        }
    }

    public T Pop(){
        T ret = list[0];
        list[0] = list[--Count];
        int i = 0;
        while(true){
            int left = (i*2)+1;
            if(left >= Count) break;
            int right = left+1;
            int ind = left;
            if(right < Count && Comparer.Comparer(list[left], list[right]) > 0) ind = right;
            if(Comparer.Comparer(list[i], list[ind]) >= 0){
                T tmp = list[i];
                list[i] = list[ind];
                list[ind] = tmp;
                i = ind;
            }
            else break;
        }
        return ret;
    }

    private int Parent(int i){
        return (i-1)/2;
    }
}