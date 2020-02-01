//간선 서로소 경로의 최대 개수를 찾는 문제
//이는 각 간선이 최대 하나의 경로에만 포함될 수 있다는 뜻이다.
//간선 서로소 경로는 각 간선의 용량이 1인 그래프의 최대 유량과 같다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class Lecture 
{
    //x -> y로 가는 간선만 추가해준다.
    static List<int>[] adj;
    //x -> y로 가는 간선 용량
    static int[,] capacity;
    //x -> y로 현재 흐르고 있는 유량
    static int[,] flow;
    //prev[i] = j는 i의 이전 노드가 j라는 뜻이다.
    static int[] prev;

    static int source, sink;
    public static void Main(string[] args) {
        source = 1; sink = 6;
        AdjInit(sink);
        Add(1,2);
        Add(1,4);
        Add(2,4);
        Add(4,3);
        Add(4,5);
        Add(3,2);
        Add(3,5);
        Add(3,6);
        Add(5,6);
        Console.WriteLine(MaxDisjointPath());
    }

    static int maxPath = 0;
    public static int MaxDisjointPath(){
        while(true){
            Array.Clear(prev, 0, prev.Length);
            
            Bfs();
            
            if(prev[sink] == 0) break;

            int min = 1000;
            for(int i = sink; i != source; i = prev[i]){
                min = Math.Min(min, capacity[prev[i],i] - flow[prev[i],i]);
            }

            SubWeight(min);
        }

        return maxPath;
    }

    static Queue<int> q = new Queue<int>();
    public static void Bfs(){
        q.Enqueue(source);
        while(q.Count != 0){
            int s = q.Dequeue();
            foreach(var u in adj[s]){
                if((prev[u] == 0) && (capacity[s,u] - flow[s,u] > 0)){
                    prev[u] = s;
                    q.Enqueue(u);
                    if(u == sink) break;
                }
            }
        }
    }

    public static void SubWeight(int min){
        for(int i = sink; i != source; i = prev[i]){
            flow[prev[i],i] += min;
            flow[i,prev[i]] -= min;
        }
        maxPath += min;
    }

    //어쩌피 용량은 전부 1이므로 w값은 매개변수로 받지 않는다.
    public static void Add(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
        capacity[a,b] = 1;
        capacity[b,a] = 1;
    }
    public static void AdjInit(int n){
        adj = new List<int>[n+1];
        capacity = new int[n+1,n+1];
        flow = new int[n+1,n+1];
        prev = new int[n+1];
        for(int i = 1; i <= n; i++){
            adj[i] = new List<int>();
        }
    }
}