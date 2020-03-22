using System;
using System.Collections.Generic;

public class UD{
    static List<Pair>[] adj;
    static int[] distance;
    static int INF = 50000*1000+2;
    public static void Main(string[] args){
        int tests = int.Parse(Console.ReadLine());
        for(int i = 0; i < tests; i++){
            int[] parts = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            int n = parts[0];
            int m = parts[1];
            int t = parts[2];
            parts = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            int s = parts[0];
            int g = parts[1];
            int h = parts[2];
            Init(n);
            for(int i = 0; i < m; i++){
                parts = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
                Add(parts[0],parts[1],parts[2],g,h);
            }
            Dijkstra(s, n);

            List<int> l = new List<int>();
            for(int i = 0; i < t; i++){
                int d = int.Parse(Console.ReadLine());
                if(distance[d]%2==1) l.Add(d);
            }
            l.Sort();
            foreach(var i in l){
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }

    public void Dijkstra(int s, int n){
        for(int i = 1; i <= n; i++){
            distance[i] = INF;
        }
        distance[s] = 0;
        PriorityQueue<Pair> q = new PriorityQueue<Pair>();
        q.Push(new Pair(s,0));
        while(!q.IsEmpty()){
            int a = q.Pop().b;
            foreach(Pair p in adj[a]){
                if(distance[p.b] > distance[a]+p.w){
                    distance[p.b] = distance[a]+p.w;
                    q.Push(new Pair(p.b, distance[p.b]));
                }
            }
        }
    }

    public static void Init(int n){
        distance = new int[n+1];
        adj = new List<Pair>[n+1];
        for(int i = 1; i <= n; i++){
            adj[i] = new List<Pair>();
        }
    }

    public static void Add(int a, int b, int w, int g, int h){
        if((a==h&&b==g) || (a==g&&b==h)){
            adj[a].Add(new Pair(b, w*2-1));
            adj[b].Add(new Pair(a, w*2-1));
        }
        else{
            adj[a].Add(new Pair(b, w*2));
            adj[b].Add(new Pair(a, w*2));
        }
    }
}

class Pair : IComparable<Pair>{
    public int b, w;

    public Pair(int b, int w){
        this.b = b;
        this.w = w;
    }

    public int CompareTo(Pair p){
        return w - p.w;
    }
}

public class PriorityQueue<T>{
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
            T[] tmp = new T[list.Length * 2];
            Array.Copy(list, tmp, list.Length);
            list = tmp;
        }
        list[Count++] = value;
        int i = Count - 1;
        while(i > 0 && Comparer.Compare(list[i], list[parent(i)]) < 0){
            T tmp = list[i];
            list[i] = list[parent(i)];
            list[parent(i)] = tmp;
            i = parent(i);
        }
    }

    //가장 말단 노드를 루트 노드에 복사시켜서 그 노드가 다시 맞는 자리로 찾아가도록 한다.
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

    private int parent(int i){
        return (i-1)/2;
    }
}