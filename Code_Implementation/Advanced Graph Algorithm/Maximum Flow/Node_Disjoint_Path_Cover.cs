//노드 서로소 경로 커버 : 모든 노드가 정확히 하나의 경로에만 속하는 경우.
//최소 노드 서로소 경로 커버를 구하기 위해 매칭 그래프를 만든다.
//원래 그래프의 각 노드에 대응되는 노드드를 두 개 추가하는데, 각각은 왼쪽 노드와
//오른쪽 노드가 됨. 원래 그래프의 각 간선에 대해 왼쪽 노드에서 오른쪽 노드로 가는 간선도
//추가함. 그리고 소스와 싱크를 추가해서 왼쪽을 소스와, 싱크를 오른쪽과 연결한다.
//매칭 그래프의 최대 매칭에 대응되는 간선은 원래 그래프의 최소 노드 서로소 경로 커비를
//구성하는 간선이 된다. 즉, 최소 노드 서로소 경로 커버의 크기는 n-c가 되며, n은 원래 그래프의
//노드 개수, c는 최대 매칭의 크기이다.
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
        source = 0; sink = 8;
        AdjInit(sink);
        Add(1,5);
        Add(2,6);
        Add(3,4);
        Add(5,6);
        Add(6,3);
        Add(6,7);
        //소스와 왼쪽, 오른쪽과 싱크 연결
        for(int i = source+1; i <= sink-1; i++){
            Add(source, i);
            Add(i,sink);
        }
        Console.WriteLine(MaximumMatching());
        //최소 노드 서로소 경로 커버를 구성하는 간선
        for(int i = source+1; i <= sink-1; i++){
            foreach(var u in adj[i]){
                if(capacity[i,u] - flow[i,u] == 0){
                    if(u > sink){
                        int temp = u/(sink+1);
                        Console.WriteLine($"{i} -> {temp}");
                    }
                }
            }
        }
    }

    static int maxPath = 0;
    public static int MaximumMatching(){
        while(true){
            Array.Fill(prev, -1);

            Bfs();

            if(prev[sink] == -1) break;

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
                if((prev[u] == -1) && (capacity[s,u] - flow[s,u] > 0)){
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
            adj[a].Add(b*(sink+1));
            adj[b*(sink+1)].Add(a);
            capacity[a,b*(sink+1)] = 1;
            capacity[b*(sink+1),a] = 1;
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
        for(int i = 0; i <= n*(sink+1); i++){
            adj[i] = new List<int>();
        }
    }
}