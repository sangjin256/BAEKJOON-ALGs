/*
# 1260

그래프를 DFS로 탐색한 결과와 BFS로 탐색한 결과를 출력하는 프로그램을 작성하시오.

단, 방문할 수 있는 정점이 여러 개인 경우에는 정점 번호가 작은 것을 먼저 방문하고,

더 이상 방문할 수 있는 점이 없는 경우 종료한다. 정점 번호는 1번부터 N번까지이다.
*/

using System;
using System.IO;
using System.Collections.Generic;

public class wm 
{
	//그래프를 표현하기 위해 인접리스트 사용
	static List<int>[] adj;
	//bfs에서 사용하기 위한 큐
	static Queue<int> q = new Queue<int>();
	
	static List<int> dfsarr = new List<int>();
	static List<int> bfsarr = new List<int>();
	
	public static void Main(string[] args) {
		//첫째 줄에 정점의 개수 N(1 ≤ N ≤ 1,000), 간선의 개수 M(1 ≤ M ≤ 10,000), 탐색을 시작할 정점의 번호 V
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		AdjacencyList(arr[0] + 1, false);
		
		//다음 M개의 줄에는 간선이 연결하는 두 정점의 번호
		//입력으로 주어지는 간선은 양방향이다.
		//따라서 반대방향으로도 넣어주자.
		for(int i = 0; i < arr[1]; i++){
			int[] tmp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
			adj[tmp[0]].Add(tmp[1]);
			adj[tmp[1]].Add(tmp[0]);
		}
		
		//정점 번호가 작은 것을 먼저 방문
		for(int i = 1; i < arr[0] + 1; i++){
			adj[i].Sort();
		}
		
		visited_bfs = new bool[arr[0]+1];
		visited_dfs = new bool[arr[0]+1];
		distance = new int[arr[0]+1];
		
		dfs(arr[2]);
		bfs(arr[2]);
		
		foreach(var c in dfsarr){
			Console.Write(c + " ");
		}
		
		Console.WriteLine();
		
		foreach(var c in bfsarr){
			Console.Write(c + " ");
		}
	}
	
	static bool[] visited_dfs;
	public static void dfs(int s){
		if(visited_dfs[s]) return;
		visited_dfs[s] = true;
		dfsarr.Add(s);
		foreach(var u in adj[s]){
			dfs(u);
		}
	}
	
	static bool[] visited_bfs;
	static int[] distance;
	
	public static void bfs(int x){
		visited_bfs[x] = true;
		distance[x] = 0;
		q.Enqueue(x);
		while(q.Count != 0){
			int s = q.Dequeue();
			bfsarr.Add(s);
			foreach(var u in adj[s]){
				if(visited_bfs[u]) continue;
				visited_bfs[u] = true;
				distance[u] = distance[s] + 1;
				q.Enqueue(u);
			}
		}
	}
	
	
	public static void AdjacencyList(int length, bool isWeight){
		if(isWeight == false){
			adj = new List<int>[length];
			
			for(int i = 0; i < length; i++){
				adj[i] = new List<int>();
			}
		}
	}
}