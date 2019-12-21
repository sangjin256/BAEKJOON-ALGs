/*
# 11725

루트 없는 트리가 주어진다. 이때, 트리의 루트를

1이라고 정했을 때, 각 노드의 부모를 구하는 프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static List<int>[] adj;
	public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        Adj_Initializaion(n);
        for(int i = 1; i < n; i++){
            int[] temp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            Adj_Add(temp[0],temp[1]);
        }

        parent = new int[n+1];
        visited = new int[n+1];
		
		Bfs(1);

        for(int i = 2; i < parent.Length; i++){
            Console.WriteLine(parent[i]);
        }
    }

    //각 노드별로 부모노드를 담는 배열을 생성한다.
    static int[] parent;
    static bool[] visited;

    //bfs를 활용하여 부모노드 번호를 출력한다.
    public static void Bfs(int x){
        Queue<int> q = new Queue<int>();
        q.Push(x);
        visited[x] = true;
        while(q.Count != 0){
            int s = q.Dequeue();
            foreach(var u in adj[s]){
                if(visited[u]) continue;
                visited[u] = true;
                parent[u] = s;
                q.Enqueue(u);
            }
        }
    }
    //인접 리스트 초기화
    public static void Adj_Initializaion(int n){
        adj = new List<int>[n+1];
        for(int i = 1; i < adj.Length; i++){
            adj[i] = new List<int>();
        }
    }

    //양방향 그래프이므로 양쪽 다 받아준다.
    public static void Adj_Add(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
    }
}