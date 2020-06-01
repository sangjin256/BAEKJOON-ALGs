//일반 경로 커버 : 노드가 하나 이상의 경로에 속할 수 있는 경로 커버
//최소 일반 경로 커버는 최소 노드 서로소 경로 커버보다 작을 수 있는데, 한 노드가
//여러 경로에 사용될 수 있기 때문이다.
//최소 일반 경로 커버는 원래 그래프에 노드 a에서 노드 b로 가는 경로(여러 노드를 거치는 경로도 무방)가
//있는 경우 그래프에 a->b간선을 추가하고 최대 매칭 구하면 됨
//n(원래 그래프의 노드 개수) - c(최대 매칭의 크기) 가 최소 일반 경로 커버의 크기가 됨

//딜워스 정리 : '반사슬'은 그래프의 노드 집합의 일종으로 그래프의 간선을 이용하여
//집합에 속한 노드 간에 경로를 만들 수 없는 경우를 말함. 딜워스 정리에 의하면 DAG에서
//최소 일반 경로 커버의 크기는 최대 반사슬의 크기와 같다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class qy 
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
        Add(1,6);
        Add(1,7);
        Add(1,3);
        Add(1,4);
        Add(2,6);
        Add(2,3);
        Add(2,4);
        Add(2,7);
        Add(3,4);
        Add(5,6);
        Add(5,3);
        Add(5,4);
        Add(5,7);
        Add(6,3);
        Add(6,4);
        Add(6,7);
        //소스와 왼쪽, 오른쪽과 싱크 연결
        for(int i = source+1; i <= sink-1; i++){
            Add(source, i);
            Add(i,sink);
        }
        Console.WriteLine(GeneralPathCover());
        //최소 일반 경로 커버를 구성하는 간선
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
    public static int GeneralPathCover(){
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
        return (sink - 1) - maxPath;
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