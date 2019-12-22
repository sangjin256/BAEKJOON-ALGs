using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	static List<int>[] adj;
	
	public static void Main(string[] args) {
		AdjacencyList(5, false);
		adj[1].Add(2);
		adj[2].Add(4);
		adj[4].Add(1);
		
		dfs(1);
		
		//노드가 1부터 순서대로 들어간다고 가정
		for(int i = 1; i < adj.Length; i++){
			if(visited[i] == false){
				Console.WriteLine("연결 그래프가 아님");
				return;
			}
		}
		
		Console.WriteLine("연결그래프 맞음");
	}
	
	static bool[] visited = new bool[100];
	static void dfs(int s){
		if(visited[s]) return;
		visited[s] = true;
		//노드 s 처리
		foreach(var u in adj[s]){
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