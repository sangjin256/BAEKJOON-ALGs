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

    //루트 노드를 넣을 변수 생성
    //책과 동일하게 시험하기 위해 root는 5로 두었다.
    static int root = 5;

    //조상을 넣어줄 배열
    static int[] parent;
    public static void Main(string[] args) {
        AdjInit(8);
        Add(1,2);
        Add(1,3);
        Add(2,3);
        Add(2,4);
        Add(3,4);
        Add(4,5);
        Add(5,6);
        Add(5,7);
        Add(6,7);
        Add(7,8);

        DFSTree(root,0);

        for(int i = 1; i < 8; i++){
            Console.WriteLine(i + " : " + IsArticulationPoint(i));
            foreach(var u in tree[i]){
                Console.WriteLine($"{i} -> {u} : {IsBridge(i,u)}");
            }
        }
    }

    //단절점 찾는 함수
    //a가 단절점이면 true 아니면 false를 반환
    static bool IsArticulationPoint(int a){
        
        //a가 루트노드일 때, 자식이 2개 이상이면 단절점이다.
        if((a == root) && (tree[a].Count >= 2)){
            return true;
        }
        
        //깊이우선탐색트리에서 트리 간선으로 이루어진 자식이 없으면 단절점이 아니다.
        int count = 0;
        foreach(var u in tree[a]){
            if(back[a,u] == false) continue;
            count++;
        }
        if(tree[a].Count == count) return false;
        
        foreach(var u in tree[a]){
            if(Bfs(u, parent[a]) == true) return true;
        }
        return false;
    }
    //단절점 찾기 위한 Bfs. a의 자식 노드 중 그 노드의 서브트리에서 a의 조상으로 가는 역방향 간선이
    //없는 노드가 있는 경우 단절점이다. 없으면 isPoint가 false를 반환한다.
    static Queue<int> q = new Queue<int>();    
    static bool Bfs(int n, int parent){
        q.Enqueue(n);
        while(q.Count != 0){
            int s = q.Dequeue();
            foreach(var u in tree[s]){
                if(back[s,parent] == true){
                    return false;
                }
                if(back[s,u] == true) continue;
                q.Enqueue(u);
            }
        }
        return true;
    }
    //단절선 찾는 함수
    //a -> b가 단절선이면 true를 반환

    static bool IsBridge(int a, int b){
        Array.Clear(visited, 0, visited.Length);
        //a->b간선이 역방향 간선이면 단절선이 아니다.
        if(back[a,b] == true) return false;

        q.Enqueue(b);
        while(q.Count != 0){
            int s = q.Dequeue();
            foreach(var u in tree[s]){
                if(back[s,a] == true || back[s,parent[a]] == true){
                    return false;
                }
                if(back[s,u] == true) continue;
                q.Enqueue(u);
            }
        }

        return true;
    }

#region SetDFSTree
    public static void DFSTree(int s, int e){
        visited[s] = true;
        foreach(var u in adj[s]){
            if(!visited[u]){
                tree[s].Add(u);
                parent[u] = s;
                visited[u] = true;
                DFSTree(u,s);
            }
            else if((u != e) && (!back[u,s])){
                //이미 역방향 간선이 만들어져 있으면 다시 반대방향 간선을 만들지 않는다.
                tree[s].Add(u);
                back[s,u] = true;
            }
        }
    }

    public static void Add(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
    }
    public static void AdjInit(int n){
        adj = new List<int>[n+1];
        tree = new List<int>[n+1];
        back = new bool[n+1,n+1];
        visited = new bool[n+1];
        parent = new int[n+1];
        for(int i = 1; i <= n; i++){
            adj[i] = new List<int>();
            tree[i] = new List<int>();
        }
    }
#endregion

}