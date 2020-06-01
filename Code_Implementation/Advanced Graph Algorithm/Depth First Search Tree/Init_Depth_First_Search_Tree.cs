//깊이 우선 탐색 트리(Depth First Search Tree) : 연결 그래프에 대한 깊이 우선 탐색을 진행하는 과정에서
//만들어지는 방향성 신장 트리
//무방향 그래프에 대해서는 간선을 두 종류로 나눌 수 있는데,
//트리 간선(Tree Edge)은 깊이 우선 탐색 트리에 포함된 간선을 의미하고
//역방향 간선(Back Edge)은 이미 방문한 노드로 향하는 간선을 의미함
//역방향 간선이 가리키는 노드는 항상 조상 노드임에 유의!
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class qw 
{   
    //기본 그래프
    static List<int>[] adj;

    static bool[] visited;
    //깊이 우선 탐색 트리를 만들 리스트
    static List<int>[] tree;
    //역방향 그래프는 bool 배열로 확인하자(탐색할때마다 체크해야됨)
    static bool[,] back;
    public static void Main(string[] args) {
        AdjInit(7);
        Add(1,2);
        Add(1,4);
        Add(1,6);
        Add(2,3);
        Add(4,6);
        Add(4,5);
        Add(4,7);
        Add(5,7);
        DFSTree(1,0);

        for(int i = 1; i <= 7; i++){
            foreach(var u in tree[i]){
                Console.WriteLine($"{i} -> {u} : {back[i,u]}");
            }
        }
    }

    //깊이 우선 탐색 과정에서 만드는 트리기 때문에 깊이우선탐색을 해준다.
    public static void DFSTree(int s, int e){
        visited[s] = true;
        foreach(var u in adj[s]){
            if(!visited[u]){
                visited[u] = true;
                tree[s].Add(u);
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
        for(int i = 1; i <= n; i++){
            adj[i] = new List<int>();
            tree[i] = new List<int>();
        }
    }
}