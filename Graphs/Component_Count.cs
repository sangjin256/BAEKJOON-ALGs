using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	static List<int>[] adj;
	
	public static void Main(string[] args) {
		AdjacencyList(6, false);
		adj[1].Add(3);
		adj[2].Add(5);
		adj[3].Add(4);
		adj[4].Add(1);
		
		//visited배열의 값이 fasle인 값이 있으면 계속 돌림
		//노드가 1부터 시작하므로 0번째 배열은 true로 고정시킴
		visited[0] = true;
		int count = 1;
		for(int i = 1; i < 5; i++){
			dfs(i);
            //bool배열이기 때문에 0도 false도 아니고 Convert.ToBoolean함수를 써줘야한다!!!!!!!!!!
			if(Array.IndexOf(visited, Convert.ToBoolean(0)) != -1){
				count++;
			}
		}
		Console.WriteLine(count);
	}
	
	static bool[] visited = new bool[6];
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