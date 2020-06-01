/*
# 11725

루트 없는 트리가 주어진다. 이때, 트리의 루트를

1이라고 정했을 때, 각 노드의 부모를 구하는 프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class ul 
{
    static List<int>[] adj;
	public static void Main(string[] args) {
		
        //초기화
        int n = int.Parse(Console.ReadLine());
        AdjacentInit(n);
        
        for(int i = 1; i < n; i++){
            int[] temp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            Add(temp[0], temp[1]);
        }
        
        parent = new int[n+1];
        visited = new bool[n+1];
        Bfs();
        for(int i = 2; i < n+1; i++){
            Console.WriteLine(parent[i]);
        }
    }

    //부모 노드의 번호를 넣을 배열을 만들어준다.
    static int[] parent;
    static bool[] visited;
    
    //Bfs로 순회한다.
    public static void Bfs(){
        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        visited[1] = true;
        while(q.Count != 0){
            int s = q.Dequeue();
            foreach(var u in adj[s]){
                if(visited[u]) continue;
                parent[u] = s;
                visited[u] = true;
                q.Enqueue(u);
            }
        }
    }

    public static void AdjacentInit(int n){
        adj = new List<int>[n+1];
        for(int i = 1; i < n+1; i++){
            adj[i] = new List<int>();
        }
    }

    public static void Add(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
    }
}