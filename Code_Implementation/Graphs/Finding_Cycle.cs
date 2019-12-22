//무방향 그래프만 적용

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	static List<int>[] adj;
	
	//사이클이 있는지없는지 판단하는 변수
	static bool isCycle = false;
	
	public static void Main(string[] args) {
		AdjacencyList(6, false);
		adj[1].Add(3);
		adj[1].Add(4);
		adj[3].Add(4);
		adj[3].Add(1);
		adj[4].Add(1);
		adj[4].Add(3);
		
		//무방향 그래프만 적용
		Console.WriteLine("사이클 유무 찾는 방법1 : 이웃이 방문한 노드인지 탐색");
		for(int i = 1; i <= 4; i++){
			dfs(i);
		}
		Console.WriteLine(isCycle ? "사이클 있음" : "사이클 없음");
		
		//무방향 그래프만 적용
		Console.WriteLine("사이클 유무 찾는 방법2 : 각 컴포넌트에 대해 노드와 간선의 개수 세기(노드 개수 c개에 사이클이 없다면 간선의 개수는 정확이 c-1개여야 함)");
		int sum = 0;
		for(int i = 1; i <= 5; i++){
			sum += adj[i].Count;
		}
		if(sum+1 == 5) Console.WriteLine("사이클 없음");
		else Console.WriteLine("사이클 있음");
		
	}
	
	//무방향 그래프로 가정했으므로 바로 전 노드를 기억하기 위해 변수를 만든다.
	static int temp = 0;
	static bool[] visited = new bool[6];
	static void dfs(int s){
		if(visited[s]) return;
		visited[s] = true;
		foreach(var u in adj[s]){
			if(temp != u){
				if(visited[u]) isCycle = true;
			}
			temp = s;
			dfs(u);
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