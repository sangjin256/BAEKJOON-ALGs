//무방향 그래프만 적용

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	static List<int>[] adj;
	
	public static void Main(string[] args) {
		AdjacencyList(6, false);
		adj[1].Add(2);
		adj[1].Add(4);
		adj[2].Add(1);
		adj[2].Add(3);
		adj[2].Add(5);
		adj[3].Add(2);
		adj[3].Add(5);
		adj[4].Add(1);
		adj[4].Add(5);
		adj[5].Add(2);
		adj[5].Add(3);
		adj[5].Add(4);
		
		//시작노드는 1로 칠해둔다.
		colors[1] = 1;
		
		for(int i = 1; i <= 5; i++){
			dfs(i);
		}
	}
	
	//현재 노드에 1를 칠하고 이웃노드에 2를 칠하고 그 이웃노드에 X를 칠하고를 반복한다.
	static bool[] visited = new bool[6];
	//1,2를 넣을 배열
	static int[] colors = new int[6];
	static void dfs(int s){
		if(visited[s]) return;
		visited[s] = true;
		foreach(var u in adj[s]){
			if(visited[u]){
				//나중에 쓸때는 string에 저장해서 1번만 출력하기
				if(colors[u] == colors[s]) Console.WriteLine("이분 그래프가 아님");
			}
			if(!visited[u]){
				if(colors[s] == 1){
				//색이 칠해지지 않았으면 색칠한다.
					colors[u] = 2;
				}
				else colors[u] = 1;
			}
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