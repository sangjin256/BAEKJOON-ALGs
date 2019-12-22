using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	static int[,] adj;
	//[a,b]일때 a에서 b까지의 거리를 담는 배열
	static int[,] dist;
	public static void Main(string[] args) {
		adj = new int[,]{{0,5,0,9,1},
			   			 {5,0,2,0,0},
			   			 {0,2,0,7,0},
			  			 {9,0,7,0,2},
			   			 {1,0,0,2,0}};
		
		dist = new int[adj.GetLength(0)+1,adj.GetLength(0)+1];
		//행렬의 초깃값은 그래프의 인접행렬에 있는 값과 같음
		//이어진 간선이 없으면 INFINITY 자기자신을 향하면 0
		for(int i = 1; i <= adj.GetLength(0); i++){
			for(int j = 1; j <= adj.GetLength(0); j++){
				if(i == j) dist[i,j] = 0;
				else if(Convert.ToBoolean(adj[i-1,j-1])) dist[i,j] = adj[i-1,j-1];
				//간선이 없으면 int.MaxValue-100이런거 대신에 인접행렬에서 가장 큰 가중치보다 크게 잡는다. 전자의 방법으로 하면 for문을 3번 돌리는 와중에 오버플로우가 일어난다.
				else dist[i,j] = 10;
			}
		}
	
		for(int k = 1; k <= adj.GetLength(0); k++){
			for(int i = 1; i <= adj.GetLength(0); i++){
				for(int j = 1; j <= adj.GetLength(0); j++){
					dist[i,j] = Math.Min(dist[i,j], dist[i,k]+dist[k,j]);
				}
			}
		}
		
		for(int i = 1; i <= adj.GetLength(0); i++){
			for(int j = 1; j <= adj.GetLength(0); j++){
				Console.Write(dist[i,j]);
			}
			Console.WriteLine();
		}
	}
}