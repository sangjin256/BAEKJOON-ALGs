using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	static int[,] adj;
	public static void Main(string[] args) {
		AdjacencyMatrix(10);
	}
	//노드의 개수가 나오면 length에 입력해서 초기화
	//adj[a,b]는 a에서 b로 가는 간선의 유무를 나타냄
	//가중치x그래프에서는 간선이 있으면 1, 없으면 0
	//가중치o그래프에서는 간선이 있으면 가중치를 적고 없으면 0
	public static void AdjacencyMatrix(int length){
		adj = new int[length, length];
	}
}