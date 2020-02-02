//오일러 서브그래프 : 그래프의 모든 노드를 포함하고 있으며 간선 중 일부를 포함하면서 모든 노드의 차수가
//짝수가 되는 서브그래프를 의미
//공식으로 k를 그래프의 깊이우선탐색 트리의 역방향 간선의 개수라고 할 때, 오일러 서브그래프는 항상 2^k개 존재한다.
//이때 k = m(간선의 개수) - (n(노드의 개수) - 1)이다.
//증명 : 깊이 우선 탐색 트리의 역방향 간선의 고정된 부분집합을 생각해보자. 이 간선을 포홤하는 오일러 서브그래프를 만들기 위해
//모든 노드의 차수가 짝수가 되도록 트리 간선의 부분집합을 선택해야 한다. 이를 위해 트리를 말단에서부터 위쪽으로 살펴보면서
//트리 간선이 가리키는 노드의 차수가 그 간선을 추가함으로써 짝수가 될 때에 만 간선을 서브트리에 추가한다. 그러면 모든 차수의
//합이 짝수이므로 루트 노드의 차수도 짝수가 된다.
//이중연결 그래프(Biconnected Graph) : 연결 그래프의 임의의 노드 하나를 삭제하더라도 연결 그래프라는 성질을 유지하는 그래프
//어떤 노드를 삭제함으로써 그래프가 연결 그래프가 아니게 되는 경우 이 노드를 단절점(Articulation point)라고 함
//간선을 제거함으로써 그래프가 연결 그래프가 아니게 되는 경우 이 간선을 단절선(Bridge)이라고 함
//깊이우선탐색트리를 만들고,
//간선 a->b가 단절선인 경우 이 간선이 트리 간선이며 b의 서브트리에서 a나 a의 조상으로 가는 역방향 간선이 없는 경우와 같다.
//단절점을 찾는 과정은 다음과 같다.
//노드 x가 트리의 루트라면 이 노드가 단절점인 경우는 자식이 둘 이상인 경우와 같고,
//x가 루트가 아니라면 자식 노드 중 그 노드의 서브트리에서 x의 조상으로 가는 역방향 간선이 없는 노드가 있는 경우와 같다.

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class Lecture 
{   
    //기본 그래프
    static List<int>[] adj;

    static bool[] visited;
    //깊이 우선 탐색 트리를 만들 리스트
    static List<int>[] tree;
    //역방향 그래프는 bool 배열로 확인하자(탐색할때마다 체크해야됨)
    static bool[,] back;
    public static void Main(string[] args) {
        AdjInit(8);
        Add(1,2);
        Add(1,5);
        Add(2,5);
        Add(2,3);
        Add(2,6);
        Add(3,7);
        Add(3,4);
        Add(4,7);
        Add(4,8);
        Add(6,7);
        Add(7,8);

        DFSTree(1,0);

        Console.WriteLine(EulerianSubgraphCount());
    }

    public static int EulerianSubgraphCount(){
        return (int)Math.Pow(2, backCount);
    }

    //역방향 간선의 총 개수를 넣을 변수
    static int backCount = 0;
    public static void DFSTree(int s, int e){
        visited[s] = true;
        foreach(var u in adj[s]){
            if(!visited[u]){
                visited[u] = true;
                tree[s].Add(u);
                DFSTree(u,s);
            }            
            else if((u != e) && (!back[u,s])){
                tree[s].Add(u);
                back[s,u] = true;
                backCount++;
            }
        }
    }

    static void Add(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
    }

    static void AdjInit(int n){
        adj = new List<int>[n+1];
        visited = new bool[n+1];
        tree = new List<int>[n+1];
        back = new bool[n+1,n+1];
        for(int i = 1; i <= n; i++){
            adj[i] = new List<int>();
            tree[i] = new List<int>();
        }
    }
}