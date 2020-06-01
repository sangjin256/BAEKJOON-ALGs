//노드 서로소 경로의 최대 개수를 찾는 문제
//소스와 싱크를 제외한 모든 노드는 최대 하나의 경로에만 포함될 수 있으며
//따라서 간선 서로소 경로보다 개수가 작을 수 있다.
//이 문제를 풀기 위해 각각의 노드를 두 개의 노드로 나누고 첫번째 노드에는 들어오는 간선, 두번째
//노드에는 나가는 간선을 연결하며, 첫 번째 노드에서 두 번째 노드로 가는 간선을 추가함
//첫번째 노드와 두번째 노드를 나누기 위해 노드의 원래 숫자를 첫번째 노드로 두고 두번째 노드는
//노드*(싱크+1)을 해서 만든다.
//노드 서로소 경로도 간선의 용량은 1로 한다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class qs 
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
    //노드를 두 개의 노드로 나눠서 첫번째 노드에는 들어오는 간선, 두번째 노드에는
    //나가는 간선, 첫번째 와 두번째 노드로 가는 간선도 만들어야한다.
    public static void Add(int a, int b){
        if((a != source) && (b != sink)){
            adj[a].Add(a*(sink+1));
            adj[a*(sink+1)].Add(b);
            capacity[a,a*(sink+1)] = 1;
            capacity[a*(sink+1),a] = 1;
            capacity[a*(sink+1),b] = 1;
            capacity[b,a*(sink+1)] = 1;
        }
        else if(b == sink){
            adj[a*(sink+1)].Add(b);
            adj[b].Add(a*(sink+1));
            capacity[a*(sink+1),b] = 1;
            capacity[b,a*(sink+1)] = 1;
        }
        else{
            adj[a].Add(b);
            adj[b].Add(a);
            capacity[a,b] = 1;
            capacity[b,a] = 1;
        }
    }
    public static void AdjInit(int n){
        adj = new List<int>[n*(sink+1)+1];
        capacity = new int[n*(sink+1)+1,n*(sink+1)+1];
        flow = new int[n*(sink+1)+1,n*(sink+1)+1];
        prev = new int[n*(sink+1)+1];
        for(int i = 1; i <= n*(sink+1); i++){
            adj[i] = new List<int>();
        }
    }
}