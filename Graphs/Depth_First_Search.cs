using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	static List<List<int>> adj = new List<List<int>>();
	public static void Main(string[] args) {
		adj[1].Add(2);
		adj[2].Add(3);
		adj[2].Add(4);
		adj[3].Add(4);
		adj[4].Add(1);
		
		dfs(1);
	}
	
	static bool[] visited = new bool[100];
	static int dfs(int s){
		if(visited[s]) return;
		visited[s] = true;
		//노드 s 처리
		foreach(var u in adj[s]){
			dfs(u);
		}
	}
}