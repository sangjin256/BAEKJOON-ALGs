//인접 행렬

using System;
using System.IO;
using System.Collections.Generic;

public class ef 
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
		//노드가 1~5의 5개이면 숫자 5까지 들어가야하기 때문에 length를 +1한다.
		adj = new int[length+1, length+1];
	}
}