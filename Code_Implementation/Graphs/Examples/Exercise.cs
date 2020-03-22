using System;
using System.Collections.Generic;

class Exercise{
    static List<Pair>[] adj;
    static int INF = 400*(400-1)*10000+1;
    static int mn = INF;

    public static void Main(string[] args){
        int[] parts = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));
        int v = parts[0], e = parts[1];
        Init(v);
        for(int i = 0; i < e; i++){
            parts = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));
            adj[parts[0]].Add(new Pair(parts[1],parts[2]));
        }
        Solve(v);
        if(mn == INF) Console.WriteLine(-1);
        else Console.WriteLine(mn);
    }
    
    public static void Init(int n){
        adj = new List<Pair>[n+1];
        for(int i = 1; i <= n; i++){
            adj[i] = new List<Pair>();
        }
    }

    public static bool Dfs(int s, int e){
        foreach(Pair p in adj[s]){
            if(p.b == e) return true;
            Dfs(p.b, e);
        }
        return false;
    }

    public static int Dijkstra(int s, int n){
        int[] distance = new int[n+1];
        for(int i = 1; i <= n; i++){
            distance[i] = INF;
        }
        distance[s] = 0;
        PriorityQueue<Pair> q = new PriorityQueue<Pair>();
        q.Push(new Pair(s, 0));
        while(!q.IsEmpty()){
            int a = q.Pop().b;
            foreach(Pair p in adj[a]){
                if(distance[p.b] == 0){
                    distance[p.b] = distance[a]+p.w;
                    continue;
                }
                if(distance[p.b] > distance[a]+p.w){
                    distance[p.b] = distance[a]+p.w;
                    q.Push(new Pair(p.b, distance[p.b]));
                }
            }
        }

        return distance[s];
    }

    public static void Solve(int v){
        for(int i = 1; i <= v; i++){
            int tmp = Dijkstra(i,v);
            if(tmp != 0 && tmp < mn){
                mn = tmp;
            }
        }
    }
}

class Pair : IComparable<Pair>{
    public int b;
    public int w;
    public Pair(int b, int w){
        this.b = b;
        this.w = w;
    }

    public int CompareTo(Pair p){
        return w - p.w;
    }
}

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

    public void Push(T value){
        if(Count == list.Length){
            T[] tmp = new T[list.Length*2];
            Array.Copy(list, tmp, list.Length);
            list = tmp;
        }

        list[Count++] = value;
        int i = Count - 1;
        while(i > 0 && Comparer.Compare(list[i], list[Parent(i)]) < 0){
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
            //list[0]에 list[--Count]가 대입되었으므로 right == count이면 이미 대입한 값이다.
            if(right < Count && Comparer.Compare(list[left], list[right]) > 0) ind = right;
            if(Comparer.Compare(list[i], list[ind]) >= 0){
                T tmp = list[i];
                list[i] = list[ind];
                list[ind] = tmp;
                i = ind;
            }
            else break;
        }
        return ret;
    }

    public int Parent(int i){
        return (i-1)/2;
    }
}