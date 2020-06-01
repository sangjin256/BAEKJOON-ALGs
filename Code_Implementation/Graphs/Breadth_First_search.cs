using System;
using System.IO;
using System.Collections.Generic;

public class wj 
{
	//큐에 처리할 노드가 시작 노드와의 거리가 증가하는 순서대로 들어간다.
	static Queue<int> q = new Queue<int>();
	
	static List<int>[] adj;
	
	//bfs가 잘 처리되는지 확인하기 위한 list배열
	static List<int> tmp = new List<int>();
	
	public static void Main(string[] args) {
		AdjacencyList(10, false);
		adj[1].Add(2);
		adj[2].Add(3);
		adj[2].Add(4);
		adj[3].Add(4);
		adj[4].Add(1);
		
		bfs(1);
		
		//확인
		foreach(var c in tmp){
			Console.WriteLine(c);
		}
	}
	
	static bool[] visited = new bool[100];
	static int[] distance = new int[100];
	
	//시작노드에서부터 노드까지의 거리도 구할 수 있다.
	public static void bfs(int x){
		visited[x] = true;
		distance[x] = 0;
		q.Enqueue(x);
		while(q.Count != 0){
			int s = q.Dequeue();
			//노드 s를 처리
			tmp.Add(s);
			foreach(var u in adj[s]){
				if(visited[u]) continue;
				visited[u] = true;
				distance[u] = distance[s] + 1;
				q.Enqueue(u);
			}
		}
	}
	
	//인접 리스트를 초기화해주는 함수. 가중치가 있는 그래프와 없는 그래프를 bool로 받아서 초기화한다.
	public static void AdjacencyList(int length, bool isWeight){
		if(isWeight == false){
			adj = new List<int>[length];
			
			for(int i = 0; i < length; i++){
				adj[i] = new List<int>();
			}
		}
	}
}