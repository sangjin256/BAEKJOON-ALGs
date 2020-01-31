//포드 풀커슨 알고리즘을 이용해 최대 유량을 찾았다면 그 결과에서 최소컷을 찾을 수 있음
//포드 풀커슨 알고리즘을 실행한 이후의 그래프에 대해 A를 소스에서 가중치가 양수인 간선으로
//갈 수 있는 노드의 집합이라 할 때, 최소컷은 원래 그래프에서 A에 속한 노드에서 A에 속하지 않은
//노드로 가는 간선으로 구성되며. 그러한 간선의 용량은 최대 유량을 구할 때 모두 사용되었다.
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
    	AdjInit(6);
        Add(1,2,5);
        Add(1,4,4);
        Add(4,2,3);
        Add(4,5,1);
        Add(2,3,6);
        Add(3,5,8);
        Add(3,6,5);
        Add(5,6,2);

        source = 1; sink = 6;
        MaximumFlow();
        Console.WriteLine(MinCut());
    }
#region FordFulkerson
    static int maxFlow = 0;
    static int MaximumFlow(){
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

        return maxFlow;
    }

    static Queue<int> q = new Queue<int>();
    static void Bfs(){
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

    static void SubWeight(int min){
        for(int i = sink; i != source; i = prev[i]){
            flow[prev[i],i] += min;
            flow[i,prev[i]] -= min;
        }
        maxFlow += min;
    }

    static void AdjInit(int n){
        adj = new List<int>[n+1];
        flow = new int[n+1,n+1];
        capacity = new int[n+1,n+1];
        prev = new int[n+1];
        //최소컷 함수에서 사용
        visited = new bool[n+1];
        for(int i = 1; i <= n; i++){
            adj[i] = new List<int>();
        }
    }

    //a에서 b로 가는 가중치 w인 간선을 추가하는 함수
    //그 반대는 가중치를 0으로 해서 추가한다.
    static void Add(int a, int b, int w){
        adj[a].Add(b);
        adj[b].Add(a);
        capacity[a,b] = w;
        capacity[b,a] = w;
    }
#endregion

    //소스에서 갈수 있는 노드의 집합 A를 만들기 위한 리스트
    static List<int> list = new List<int>();
    static bool[] visited;
    static int MinCut(){
        //먼저 집합 A를 만들어준다.
        Dfs_MC(source);

        int sum = 0;
        foreach(var s in list){
            foreach(var u in adj[s]){
                if(!visited[u]){
                    sum += (flow[s,u]);
                }
            }
        }

        return sum;
    }

    static void Dfs_MC(int s){
        list.Add(s);
        visited[s] = true;
        foreach(var u in adj[s]){
            if((!visited[u]) && (capacity[s,u] - flow[s,u] > 0)){
                Dfs_MC(u);
            }
        }
    }
}