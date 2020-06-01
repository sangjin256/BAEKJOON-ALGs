//인접 리스트

using System;
using System.IO;
using System.Collections.Generic;

public class eg 
{
	//인접 리스트(Adjacency list)로 표현 (가중치 x)
	static List<int>[] adj;

	//인접 리스트로 표현 (가중치 o)
	static List<(int, int)>[] adj_w;
	
	public static void Main(string[] args) {
		AdjacencyList(10, false);
		adj[1].Add(2);
		adj[2].Add(3);
		adj[2].Add(4);
		adj[3].Add(4);
		adj[4].Add(1);
		
		AdjacencyList(10, true);
        //(b,w)는 b로 가는 가중치가 w인 간선을 의미
		adj_w[1].Add((2,5));
		adj_w[2].Add((3,7));
		adj_w[2].Add((4,6));
		adj_w[3].Add((4,5));
		adj_w[4].Add((1,2));
	}
	
	//인접 리스트를 초기화해주는 함수. 가중치가 있는 그래프와 없는 그래프를 bool로 받아서 초기화한다.
	public static void AdjacencyList(int length, bool isWeight){
		if(isWeight == false){
			adj = new List<int>[length];
			
			for(int i = 0; i < length; i++){
				adj[i] = new List<int>();
			}
		}
		else {
			adj_w = new List<(int, int)>[length];
			
			for(int i = 0; i < length; i++){
				adj_w[i] = new List<(int, int)>();
			}
		}
	}
}