//최대 매칭 : 두 노드의 조합으로 이루어진 최대 크기의 집합으로, 하나의 조합을 이루는 두 노드는
//간선으로 연결되어 있어야 하며, 각 노드는 최대 하나의 조합에만 속할 수 있다.
//일반적인 그래프에서는 복잡하지만 '이분 그래프'에서는 최대 매칭 문제를 최대 유량 문제로 변환 가능

//이분 그래프에서 전체 노드를 두 개의 그룹으로 나누고 모든 간선이 왼쪽 그룹과 오른쪽 그룹의 노드를 잇도록 설정
//소스와 싱크 노드를 추가해 소스에서 왼쪽 그룹으로 가는 간선을 추가하고 오른쪽 그룹에서 싱크로 가는 간선도 추가한다.
//그렇게 최대 유량을 구하면 그것이 최대 매칭이 된다.
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

public class qu 
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
        //source는 그래프의 최소 숫자보다 작게, sink는 그래프의 최대 숫자보다 크게 만든다.
        source = 0; sink = 9;
        AdjInit(sink);
        Add(1,5);
        Add(2,7);
        Add(3,5);
        Add(3,6);
        Add(3,8);
        Add(4,7);

        //sorce와 왼쪽 그룹, 오른쪽 그룹과 sink를 연결한다.
        Add(source,1);
        Add(source,2);
        Add(source,3);
        Add(source,4);
        Add(5,sink);
        Add(6,sink);
        Add(7,sink);
        Add(8,sink);
        Console.WriteLine(MaximumMatching());
    }

    static int maxPath = 0;
    public static int MaximumMatching(){
        while(true){
            //source가 0이어서 prev[]값이 source인것과 없는 것이 동일해지므로
            //시작할때 prev값을 0으로 초기화하지 말고 -1로 초기화한다.
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
        //source가 최소값인 1보다 더 작아졌으므로 0부터 초기화한다.
        for(int i = 0; i <= n; i++){
            adj[i] = new List<int>();
        }
    }
}